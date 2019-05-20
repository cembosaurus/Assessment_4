using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckApp.Models
{
    public class CheckDTO
    {
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public string AmountInWords { get; set; }
        public DateTime? Date { get; set; }
    }
}
