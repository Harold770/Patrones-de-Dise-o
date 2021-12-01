using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_abstrac_factory
{
    public abstract class Menu
    {
        protected string mimenu;

        public object MenuRestauran
        {
            get
            {
                return mimenu;
            }
        }
    }
}
