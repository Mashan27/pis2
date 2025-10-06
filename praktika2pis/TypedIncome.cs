using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    public class TypedIncome : Income
    {
        // Новые поля:
        public string OperationType { get; set; }        // Тип операции
        public string Category { get; set; }             // Категория дохода
        public bool IsCompleted { get; set; }            // Завершена ли операция

        public override string ToString()
        {
            string status = IsCompleted ? "Завершено" : "В процессе";
            return $"ТИПИЗИРОВАННЫЙ: Дата:{Date.ToShortDateString()} | {Source} | {Amount} руб. | " +
                   $"Тип операции: {OperationType} | Категория: {Category} | Статус: {status}";
        }
    }
}
