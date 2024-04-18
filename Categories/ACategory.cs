using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeAdmissionTest.Contracts;

namespace TradeAdmissionTest.Categories
{
    public class ACategory : ICategory
    {
        public string Name { get; protected set; }
        public int Value { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
