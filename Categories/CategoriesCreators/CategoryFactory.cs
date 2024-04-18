using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAdmissionTest.Categories.CategoriesCreators.Abstracts;
using TradeAdmissionTest.Contracts;

namespace TradeAdmissionTest.Categories.CategoriesCreators
{
    public static class CategoryFactory
    {
        private static List<ACategoryCreator> creators = null;

        public static ICategory CreateCategory(ITrade trade, DateTime refDate)
        {
            if (creators == null)
            {
                Setup();                
            }

            foreach (var creator in creators.OrderBy(o => o.NumOrder))
            {
                var category = creator.CreateCategory(trade, refDate);
                if (category != null) return category;
            }
            throw new Exception("Category not found");
        }

        private static void Setup()
        {
            //It is possible to create a loop using Reflection getting all classes who inherits from ACategoryCreator.
            creators = new List<ACategoryCreator>()
            {
                new ExpiredCategoryCreator(),
                new HighRiskCategoryCreator(),
                new MediumRiskCategoryCreator(),
            };
        }
    }
}
