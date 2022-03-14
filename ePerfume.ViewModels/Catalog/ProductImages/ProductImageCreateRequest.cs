using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.ViewModels.Catalog.ProductImages
{
    public class ProductImageCreateRequest
    {
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SoftOrder { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
