using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZdravoKorporacija.Validacija
{
    public class ValidacijaPrilikomZakazivanja : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
           
                if (!s.Equals(""))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Popunite polje datum.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }

        }
    }
}
