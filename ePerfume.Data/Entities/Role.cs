using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePerfume.Data.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Desccription { get; set; }
    }
}
