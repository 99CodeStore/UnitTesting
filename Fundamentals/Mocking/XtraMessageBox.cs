using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Mocking
{
    public interface IXtraMessageBox
    {
        void Show(string s, string houseKeeperstatements, MessageBoxButtons ok);
    }


    public class XtraMessageBox : IXtraMessageBox
    {
        public void Show(string s, string houseKeeperstatements, MessageBoxButtons ok)
        {

        }
    }

    public enum MessageBoxButtons
    {
        OK
    }
}
