using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Asset_Track
{
    class asset_allocation_log_model
    {
        public String Machine { get; set; }
        public String Date { get; set; }
        public String From { get; set; }
        public String To { get; set; }
       

        public asset_allocation_log_model(String machine, String Date, String To,String From)
        {
            this.Machine = machine;
            this.Date = Date;
            this.To = To;
            this.From = From;

        }
    }
}
