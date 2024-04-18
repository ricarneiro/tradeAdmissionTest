using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAdmissionTest.Categories.CategoriesCreators.Abstracts;
using TradeAdmissionTest.Contracts;

namespace TradeAdmissionTest.Categories.CategoriesCreators
{
    public class HighRiskCategoryCreator : ACategoryCreator
    {
        public override int NumOrder { get => 2; }

        public override ICategory CreateCategory(ITrade trade, DateTime refDate)
        {
            if (trade.Value > 1000000 && trade.ClientSector == "Private") 
            {
                return new HighRisk();
            }
            return null;
        }
    }
}
