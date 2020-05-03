using eShopSolution.ViewModels.Catalog;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.ProductImage;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest Request);

        Task<int> Update(ProductUpdateRequest Request);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);

        Task<int> Delete(int ProductId);


        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<string> SaveFile(IFormFile file);

        Task<int> AddImages(int productid, ProductImageCreateRequest Request);

        Task<int> RemoveImages(int imageId);

        Task<int> UpdateImages(int imageId, ProductImageUpdateRequest Request);

        Task<List<ProductImageViewModel>> getListImage(int productId);
    }
}
