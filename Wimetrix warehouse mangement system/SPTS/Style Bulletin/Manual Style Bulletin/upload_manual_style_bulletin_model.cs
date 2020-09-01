using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.Manual_Style_Bulletin
{
    class upload_manual_style_bulletin_model
    {
        public String Order { get; set; }
        public String Style { get; set; }
        public String Article { get; set; }
        public String Operation_ID { get; set; }
        public String Operation_Description { get; set; }
        public String SMV { get; set; }
        public String PieceRate { get; set; }
        public String opsequence { get; set; }

        public upload_manual_style_bulletin_model(String Order, String Style, String Article, String Operation_ID, String Operation_Description, String SMV, String PieceRate, String opsequence)
        {
            this.Order = Order;
            this.Style = Style;
            this.Article = Article;
            this.Operation_ID = Operation_ID;
            this.Operation_Description = Operation_Description;
            this.SMV = SMV;
            this.PieceRate = PieceRate;
            this.opsequence = opsequence;

        }

    }
}
