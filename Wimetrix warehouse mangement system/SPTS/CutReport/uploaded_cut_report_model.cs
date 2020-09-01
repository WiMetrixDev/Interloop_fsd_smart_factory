using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.SPTS.CutReport
{
    class uploaded_cut_report_model
    {
        public String Order { get; set; }
        public String Lot { get; set; }
        public String Bundle { get; set; }
        public String Size { get; set; }
        public String Quantity { get; set; }
        public String Article { get; set; }
        public String Style { get; set; }
        public String Color { get; set; }
        public String status { get; set; }

        public  uploaded_cut_report_model(String order,String lot,String bundle, String size, String quantity, String article,String style,String color, String status)
        {
            this.Order = order;
            this.Lot = lot;
            this.Bundle = bundle;
            this.Size = size;
            this.Style = style;
            this.Quantity = quantity;
            this.Article = article;
            this.Color = color;
            this.status = status;

        }

    }
}
