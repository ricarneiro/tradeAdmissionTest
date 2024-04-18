using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAdmissionTest.Categories.CategoriesCreators.Abstracts;
using TradeAdmissionTest.Contracts;

namespace TradeAdmissionTest.Categories.CategoriesCreators
{
    public class ExpiredCategoryCreator : ACategoryCreator
    {
        public override int NumOrder { get => 1; }

        public override ICategory CreateCategory(ITrade trade, DateTime refDate)
        {
            if (trade.NextPaymentDate < refDate.AddDays(30)) 
            {
                return new Expired();
            }
            return null;
        }
    }
}
