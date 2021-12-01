using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_abstrac_factory
{
    public class restauranChino : Restauran
    {
        public override Menu mostrarmenu()
        {
            return new MenuChina();
        }
    }
}
