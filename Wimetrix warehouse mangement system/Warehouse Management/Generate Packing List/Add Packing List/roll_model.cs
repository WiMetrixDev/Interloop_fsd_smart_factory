using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Generate_Packing_List.Add_Packing_List
{
    class roll_model
    {
        public String Roll { get; set; }
        public String Weight { get; set; }

        public roll_model(string roll, string weight)
        {
            Roll = roll;
            Weight = weight;
        }
    }
}
