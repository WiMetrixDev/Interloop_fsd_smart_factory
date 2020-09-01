using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.SPTS.Operations.View_operations
{
    class operation_model
    {
        public String operation_ID { get; set; }
        public String Description { get; set; }

        public operation_model(String operation_ID,String Description)
        {
            this.operation_ID = operation_ID;
            this.Description = Description;
        }

    }
}
