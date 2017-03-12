using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinCRM.Models
{
    public class Registry: BaseModel 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public string Vat { get; set; }
    }
}
