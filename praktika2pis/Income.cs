using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    class Income
    {
        public DateTime date { get; set; }
        public string source { get; set; }
        public int amount { get; set; }

        public override string ToString()
        {
            return $"Дата:{date.ToShortDateString()} источник:{source} сумма:{amount}";
        }
    }
}
