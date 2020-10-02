using System.Collections.Generic;

namespace Example1_Refactoring.Models
{
    public class Invoice
    {
        public string Customer { get; set; }
        public List<Performance> Performances { get; set; }
    }    
}
