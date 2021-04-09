using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstdraft_desktop_ui
{
    public class FirstdraftUiUtility
    {   
        public static string getSuffix(String file_name)
        {
            int pos = file_name.LastIndexOf('.') + 1;
            //int num = Int32.Parse(file_name.Substring(pos));
            String file_sub_string = file_name.Substring(pos);
            //String suffix = file_name.Substring(0, pos) + num.ToString();

            return file_sub_string;
        }
    }
}
