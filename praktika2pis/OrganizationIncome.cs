using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2pis
{
    public class OrganizationIncome : Income
    {
        // Новые поля:
        public string OrganizationName { get; set; }      // Название организации
        public string TaxId { get; set; }                // ИНН
        public string BankAccount { get; set; }          // Расчетный счет

        public override string ToString()
        {
            return $"ОРГАНИЗАЦИЯ: Дата:{Date.ToShortDateString()} | {Source} | {Amount} руб. | " +
                   $"Организация: {OrganizationName} | ИНН: {TaxId} | Счет: {BankAccount}";
        }
    }
}
