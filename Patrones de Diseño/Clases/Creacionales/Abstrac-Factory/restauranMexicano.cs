using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patron_abstrac_factory
{
    public class restauranMexicano : Restauran
    {
        public override Menu mostrarmenu()
        {
            return new MenuMexico();
        }
    }
}
