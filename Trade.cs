using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAdmissionTest.Categories.CategoriesCreators;
using TradeAdmissionTest.Contracts;

namespace TradeAdmissionTest
{
    public class Trade : ITrade
    {
        public double Value { get; private set; }

        public string ClientSector { get; private set; }

        public DateTime NextPaymentDate { get; private set; }

        public ICategory Category { get; private set; }

        public Trade(string line, DateTime refDate)
        {
            string[] cols = SliptAndValidate(line);
            Value = double.Parse(cols[0]);
            ClientSector = cols[1];
            NextPaymentDate = DateTime.Parse(cols[2], new CultureInfo("en-US"));
            Category = CategoryFactory.CreateCategory(this, refDate);
        }

        private string[] SliptAndValidate(string line)
        {
            try
            {
                string[] cols = line.Split(' ');
                double testValue;
                DateTime dateNext;
                //It was better if I had a Value Object for each property, but I will follow the instructions
                if (cols.Any(s => s == null)) throw new ArgumentException("The line was invalid. Sample: 2000000 Private 12/29/2025");
                if (cols.Length != 3) throw new ArgumentException("The line was invalid. Please use spaces between data. Sample: 2000000 Private 12/29/2025");
                if (!double.TryParse(cols[0], out testValue)) throw new ArgumentException("The line was invalid. The first col must be a number.");
                if (!DateTime.TryParse(cols[2], new CultureInfo("en-US"), out dateNext)) throw new ArgumentException("The line was invalid. The last col must be a datetime in american format.");
                return cols;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on split an validate data. Please restart.", ex);
            }
        }
    }
}
