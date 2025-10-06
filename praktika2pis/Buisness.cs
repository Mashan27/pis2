using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    /// <summary>
    /// Класс для представления бизнеса
    /// </summary>
    public class Buisness
    {
        public string Name { get; set; }
        public int CountEmployees { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта
        /// </summary>
        public override string ToString()
        {
            return $"Название компании: {Name}, Количество сотрудников: {CountEmployees}";
        }
    }
}
