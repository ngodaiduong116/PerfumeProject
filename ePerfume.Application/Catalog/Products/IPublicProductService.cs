using ePerfume.ViewModels.Catalog.Products;
using ePerfume.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PageResult<ProductViewModel>> GetAllByCategoryId(string languaeId, GetPublicProductPagingRequest request);
    }
}
