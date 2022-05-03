using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belchfaa
{
    internal class CurrentData
    {
        public static int posistion;
        public static double historyTotal;
        public static string historyTime;
        public static OracleDataReader currentDr;
        public static List<int> medIds =new List<int>();
        public static List<int> medAmounts =new List<int>();

    }
}
