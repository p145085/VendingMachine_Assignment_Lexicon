using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_Assignment_Lexicon
{
    public interface IVending
    {
        protected void Purchase();
        protected void ShowAll();
        protected void Details();
        protected void InsertMoney();
        protected void EndTransaction();
    }
}
