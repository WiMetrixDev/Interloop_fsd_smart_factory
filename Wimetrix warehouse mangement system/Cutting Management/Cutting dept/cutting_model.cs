using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Cutting_Management.Cutting_dept
{
    class cutting_model
    {
        public String Order { get; set; }
        public String Roll { get; set; }
        public String Consumption_KG { get; set; }
        public String Remaining_KG { get; set; }
        public String Issuance { get; set; }

    public cutting_model(String Order, String Roll,String Consumption,String Left, String Issuance)
        {
            this.Order = Order;
            this.Roll = Roll;
            this.Consumption_KG = Consumption;
            this.Remaining_KG = Left;
            this.Issuance = Issuance;
        }
    }
}
