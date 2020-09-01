using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.SPTS.Style_Bulletin.View_Style_Bulletin
{
    class style_bulletin_model
    {
        public String Style_ID { get; set; }
        public String Order { get; set; }
        public String StyleCode { get; set; }
        public String Article { get; set; }
        public String Operation_ID { get; set; }
        public String Operation_Description { get; set; }
        public String SMV { get; set; }
        public String PieceRate { get; set; }
        public String opsequence { get; set; }
        public style_bulletin_model(String Style_ID ,String Order, String Style, String Article, String Operation_ID, String Operation_Description, String SMV, String PieceRate, String opsequence)
        {
            this.Style_ID = Style_ID;
            this.Order = Order;
            this.StyleCode = Style;
            this.Article = Article;
            this.Operation_ID = Operation_ID;
            this.Operation_Description = Operation_Description;
            this.SMV = SMV;
            this.PieceRate = PieceRate;
            this.opsequence = opsequence;

        }
    }
}
