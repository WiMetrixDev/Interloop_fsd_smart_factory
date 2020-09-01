using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wimetrix_warehouse_mangement_system.SPTS.CutReport.view_cutreport
{
    class cutreport_model
    {
        public String Order { get; set; }
        public String Style { get; set; }
        public String Article { get; set; }
        public String Size { get; set; }
        public String Color { get; set; }
        public String Lot { get; set; }
        public String Bundle { get; set; }     
        public String Quantity { get; set; }

        public cutreport_model(String order, String lot, String bundle, String size, String quantity, String article, String style, String color)
        {
            this.Order = order;
            this.Lot = lot;
            this.Bundle = bundle;
            this.Size = size;
            this.Style = style;
            this.Quantity = quantity;
            this.Article = article;
            this.Color = color;
        }
    }
}
