using ePerfume.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}