using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Configuration_files
{
    class departments
    {
        Dictionary<int, string> department_mapping = new Dictionary<int, string>()
    {   { 103, "110" },
        { 104, "111" },
        { 105, "112" },
        { 106, "113" },
    };

        public String get_mapping(int s)
        {
            String value = "";
            foreach (KeyValuePair<int, string> item in department_mapping)
            {
                if (item.Key == s)
                {
                    value = item.Value;
                }
            }
            return value;
        }



    }
}
