using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HelperLibrary
{
   public static class alerts
    {
        public static void messageBox(string title, string message )
        {
            MessageBox.Show(message + "\nContact Admin" ,
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        }
        public static void ConformationMessageBox(string title, string message)
        {
            MessageBox.Show(message ,
            title,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

    }
}
