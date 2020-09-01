using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.SPTS.Workers.View_Worker
{
    class workers_model
    {
        public String Worker_ID { get; set; }
        public String Name { get; set; }
        public String Line { get; set; }

        public workers_model(String Worker_ID, String Name,String Line)
        {
            this.Worker_ID = Worker_ID;
            this.Name = Name;
            this.Line = Line;
        }
    }
}
