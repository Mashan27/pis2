using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    internal class Buisness
    {
        public string name { get; set; }
        public int countEmployers { get; set; }

        public override string ToString()
        {
            return $"Название компании: {name}, Количество сотрудников: {countEmployers}";
        }
    }
}
