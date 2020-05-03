using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.ProductImage;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDBContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(EShopDBContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(ProductCreateRequest Request)
        {
            var product = new Product()
            {
                Price           = Request.Price,
                OriginalPrice   = Request.OriginalPrice,
                Stock           = Request.Stock,
                ViewCount       = 0,
                DateCreated     = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name            = Request.Name,
                        Description     = Request.Description,
                        Details         = Request.Details,
                        SeoDescription  = Request.SeoDescription,
                        SeoAlias        = Request.SeoAlias,
                        SeoTitle        = Request.SeoTitle,
                        LanguageId      = Request.LanguageId,
                    }
                }
            };
            if (Request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = Request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(Request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1,

                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product: {ProductId}");
            }

            var Images =  _context.ProductImages.Where(x => x.ProductId == ProductId);
            foreach (var Image in Images)
            {
                await _storageService.DeleteFileAsync(Image.ImagePath);
            }

            _context.Products.Remove(product);
            
            return await _context.SaveChangesAsync();
        }





        public async Task<int> Update(ProductUpdateRequest Request)
        {
            var product = await _context.Products.FindAsync(Request.id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == Request.id && x.LanguageId == Request.LanguageId);
            if (product==null || productTranslations == null) throw new EShopException($"Cant find this product : {Request.id}");

            productTranslations.Name = Request.Name;
            productTranslations.SeoAlias = Request.SeoAlias;
            productTranslations.Description = Request.Description;
            productTranslations.Details = Request.Details;
            productTranslations.SeoDescription = Request.SeoDescription;
            productTranslations.SeoTitle = Request.SeoTitle;
            if (Request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.IsDefault == true && x.ProductId == Request.id);

                if (thumbnailImage != null)
                {

                    thumbnailImage.FileSize = Request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(Request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                };

                
               
            }
            return await _context.SaveChangesAsync();

            
         }
        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"cant not find product :{productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0 ;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"cant not find product :{productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

  
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p ,pt,pic};
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                   .Take(request.pageSize)
                   .Select(x => new ProductViewModel()
                   {
                       Id = x.p.Id,
                       Name = x.pt.Name,
                       DateCreated = x.p.DateCreated,
                       Description = x.pt.Description,
                       Details = x.pt.Details,
                       LanguageId = x.pt.LanguageId,
                       OriginalPrice = x.p.OriginalPrice,
                       Price = x.p.Price,
                       SeoAlias = x.pt.SeoAlias,
                       SeoDescription = x.pt.SeoDescription,
                       SeoTitle = x.pt.SeoTitle,
                       Stock = x.p.Stock,
                       ViewCount = x.p.ViewCount

                   }).ToListAsync();

            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var orginalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid() }{Path.GetExtension(orginalFileName) }";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> AddImages(int productid, ProductImageCreateRequest Request)
        {
            var Images = new ProductImage()
            {
                ProductId = productid,
                Caption = Request.Caption,
                IsDefault = Request.IsDefault,
                SortOrder = Request.SortOrder,
                DateCreated = DateTime.Now,

            };
            if (Request.ImageFile !=null)
            {
                Images.ImagePath = await this.SaveFile(Request.ImageFile);
                Images.FileSize = Request.ImageFile.Length;
            };
            _context.ProductImages.Add(Images);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImages(int imageId, ProductImageUpdateRequest Request)
        {
            var Images = await _context.ProductImages.FindAsync(imageId);
            if (Images == null)
            {
                throw new EShopException($"Can not find this Image with Id {imageId }");
            }

            Images.Caption = Request.Caption;
            Images.IsDefault = Request.IsDefault;
            Images.SortOrder = Request.SortOrder;

            if (Request.ImageFile != null)
            {
                Images.ImagePath = await this.SaveFile(Request.ImageFile);
                Images.FileSize = Request.ImageFile.Length;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImageViewModel>> getListImage(int productId)
        {

            var data = await _context.ProductImages.Where(i => i.Id == productId)
                .Select(p => new ProductImageViewModel() { 
                    Caption = p.Caption,
                    DateCreated = p.DateCreated,
                    FileSize = p.FileSize,
                    Id = p.Id,
                    ImagePath = p.ImagePath,
                    IsDefault = p.IsDefault,
                    ProductId = p.ProductId,
                    SortOrder = p.SortOrder,
                
                }).ToListAsync();
    
            return data;
        }



        public async Task<int> RemoveImages(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
            {
                throw new EShopException($"Can not find this Image with Id {imageId }");
            }
            _context.ProductImages.Remove(productImage);
           return await  _context.SaveChangesAsync();
        }
    }
}
