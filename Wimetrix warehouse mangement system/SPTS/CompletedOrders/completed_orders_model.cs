using System;

namespace Wimetrix_warehouse_mangement_system.SPTS.CompletedOrders
{
    class completed_orders_model
    {

        public Boolean isSelected { get; set; }
        public String orderID { get; set; }
        public String styleCode { get; set; }
        public String Article { get; set; }
        public int TotalOperations { get; set; }
        public int CompletedOperations { get; set; }
        public String CompletePercentage { get; set; }
        public bool? isTransfered { get; set; }

        public completed_orders_model(Boolean isSelected, String orderID, String styleCode, String Article, int TotalOperations, int CompletedOperations, String CompletePercentage)
        {
            this.isSelected = isSelected;
            this.orderID = orderID;
            this.styleCode = styleCode;
            this.Article = Article;
            this.TotalOperations = TotalOperations;
            this.CompletedOperations = CompletedOperations;
            this.CompletePercentage = CompletePercentage;
            this.isTransfered = null;
        }

    }
}