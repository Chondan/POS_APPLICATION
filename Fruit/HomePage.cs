using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fruit
{
    
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
     

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void BtOrder_Click(object sender, EventArgs e)
        {
            pos pos = new pos();
            pos.Show();
        }
    }
}
