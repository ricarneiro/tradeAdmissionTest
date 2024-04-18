using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAdmissionTest.Contracts;

namespace TradeAdmissionTest.Categories.CategoriesCreators.Abstracts
{
    public abstract class ACategoryCreator
    {
        public ACategoryCreator()
        {
        }

        public abstract ICategory CreateCategory(ITrade trade, DateTime refDate);
    }
}
