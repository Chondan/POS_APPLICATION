using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Fruit
{
    public partial class pos : Form
    {
        public pos()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader rd = null;


        class goods
        {
            public int id;
            public string name;
            public double price;
            public Bitmap pic;
            public int count;

        }
        List<goods> menu = new List<goods>();
        List<goods> cart = new List<goods>();

        void connect()
        {
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Fruit.accdb;";
            cmd.Connection = conn;
            
        }
        void calculate()
        {
            int price = 0;
            foreach (var crt in cart)
            {
                price += Convert.ToInt32(crt.price)*Convert.ToInt32(crt.count);
                


            }
            textBox1.Text = price.ToString();
            


        }
        void all_menu()
        {
            connect();
            conn.Open();
            menu.Clear();
            if (category == 1)
            {
                cmd.CommandText = "SELECT Fruits.Name, Fruits.Price, Fruits.ID, Fruits.Category FROM Fruits WHERE(((Fruits.Category) = "+ 1 +")) ORDER BY Fruits.ID";
            }
            else
            {
                cmd.CommandText = "SELECT Fruits.Name, Fruits.Price, Fruits.ID, Fruits.Category FROM Fruits WHERE(((Fruits.Category) = "+ 2 +")) ORDER BY Fruits.ID";
            }
            //cmd.CommandText = "SELECT * FROM Fruits order by ID ";
            rd = cmd.ExecuteReader();
            
            while (rd.Read())
            {
                goods tmp = new goods();
                tmp.id = (int) rd["ID"];
                tmp.name = rd["Name"].ToString();
                tmp.price = (double) rd["Price"];
                tmp.pic = new Bitmap(new Bitmap("image\\" + rd["ID"].ToString() + ".JPG"), 100, 80);
                menu.Add(tmp);

            }
            conn.Close();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0;i < menu.Count;i++)
            {
                int col = i % 5;
                int row = i/5;

                
                //e.Graphics.FillRectangle(Brushes.Cyan, 0, 0, 80, 80);
                e.Graphics.DrawImage(menu[i].pic, col*100,row*100);
                e.Graphics.FillRectangle(Brushes.LightPink, col * 100, (row) * 100 + 80, 50, 20);
                e.Graphics.DrawString(menu[i].name, Font, Brushes.Black, col * 100, (row)*100 + 83);
                e.Graphics.FillRectangle(Brushes.LightBlue, col * 100 + 50, (row) * 100 + 80, 50, 20);
                e.Graphics.DrawString(menu[i].price.ToString(), Font, Brushes.Black, col * 100 + 75, (row) * 100 + 83);
                
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString();
            label2.Text = e.Y.ToString();
        }

        private void Pos_Load(object sender, EventArgs e)
        {
            all_menu();
            textBox2.Focus();
            if (menu.Count%5 != 0)
            {
                pictureBox1.Height = ((menu.Count / 5) + 1) * 100;


            }
            else
            {
                pictureBox1.Height = ((menu.Count / 5) + 0) * 100;
            }
            flowLayoutPanel2.Controls.Add(pictureBox1);
            //MessageBox.Show(menu.Count.ToString());


        }
        void setPicturebox()
        {

            if (menu.Count % 5 != 0)
            {
                pictureBox1.Height = ((menu.Count / 5) + 1) * 100;


            }
            else
            {
                pictureBox1.Height = ((menu.Count / 5) + 0) * 100;
            }

        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int pos_x;
            int pos_y;

            pos_x = e.X;
            pos_y = e.Y;

            int indexx;
            indexx = (((pos_x/100)+1)+((pos_y/100))*5)-1;
            if (indexx < menu.Count)
            {


                pictureBox2.Image = menu[indexx].pic;

                int check = 0;
                foreach (var lst in cart)
                {
                    if (lst.id == menu[indexx].id)
                    {
                        check = 1;
                        //MessageBox.Show("Oops");
                        lst.count = lst.count + 1; //Quantity
                                                   //MessageBox.Show("Quantity" + lst.count.ToString());
                        break;

                    }
                    else
                    {

                        check = 0;

                    }

                }

                if (check == 0)
                {
                    menu[indexx].count = 1;
                    cart.Add(menu[indexx]);

                }
                //MessageBox.Show("Item" + cart.Count.ToString());
                Refresh();
                pictureBox3.Height = 100 * cart.Count;
                pictureBox3.Width = 101;
                flowLayoutPanel1.Controls.Add(pictureBox3);
                label6.Text = menu[indexx].name;
                calculate();
                change();
            }
            
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            int x = 0; int y = 0;
            
            foreach (var crt in cart)
            {
                e.Graphics.DrawImage(crt.pic, y*100, x * 100);
                e.Graphics.FillRectangle(Brushes.LightPink, y * 100, (x) * 100 + 80, 50, 20);
                e.Graphics.DrawString(crt.name, Font, Brushes.Black, y * 100, (x) * 100 + 83);
                e.Graphics.FillRectangle(Brushes.LightGreen, y * 100 + 50, (x) * 100 + 80, 50, 20);
                e.Graphics.DrawString('X' + crt.count.ToString(), Font, Brushes.Black, y * 100 + 75, (x) * 100 + 83);
                x = x + 1;




            }
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            //label4.Text = e.Y.ToString();
            //label5.Text = e.X.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                int x = 0;
                foreach (var crt in cart)
                {
                    x = x + 1;
                    if (crt.name == label6.Text)
                    {
                        indexx = x - 1;
                    }



                }
                cart[indexx].count += 1;
                calculate();
                change();
                Refresh();
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = e.Y.ToString();
            label5.Text = e.X.ToString();
        }
        public int indexx;
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            int pos_x;
            int pos_y;

            pos_x = e.X;
            pos_y = e.Y;

            
            indexx = (((pos_x / 100) + 1) + ((pos_y / 100)) * 1) - 1;
            pictureBox2.Image = cart[indexx].pic;
            label6.Text = cart[indexx].name;

            calculate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                int z = 0;
                foreach (var crt in cart)
                {
                    z += 1;
                    if (crt.name == label6.Text)
                    {
                        indexx = z - 1;
                    }
                }
                if (cart[indexx].count == 0)
                {
                    cart.RemoveAt(indexx);
                    Refresh();

                }
                else
                {
                    cart[indexx].count -= 1;
                    if (cart[indexx].count == 0)
                    {
                        cart.RemoveAt(indexx);
                        pictureBox2.Image = null;
                        label6.Text = "";
                        pictureBox3.Height = 101 * cart.Count;
                        Refresh();

                    }

                }

            }
            Refresh();
            calculate();
            change();

        }
        void change()
        {
            if (textBox2.Text != "")
            {
                textBox3.Text = (Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox1.Text)).ToString();

            }
            //MessageBox.Show(dateTimePicker1.Value.ToString());


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {
                    textBox3.Text = (Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox1.Text)).ToString();
                }

                catch
                {

                }
            }
            else
            {
                //textBox3.Text = (0.0 - Convert.ToDouble(textBox1.Text)).ToString();

            }

        }
        void clearing()
        {


            cart.Clear();
            pictureBox2.Image = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label6.Text = "";
            textBox4.Clear();
            textBox4.BackColor = default(Color);
            Refresh();
        }

        public int promo;
        public string promoid;
 
        private void BtSubmit_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string Str = textBox2.Text.Trim();
                double Num;
                bool isNum = double.TryParse(Str, out Num);
                if (isNum)
                {

                    if (textBox2.Text != "")
                    {
                        if (Convert.ToDouble(textBox2.Text) > Convert.ToDouble(textBox1.Text))
                        {
                            connect();
                            conn.Open();
                            double total = Convert.ToDouble(textBox1.Text);
                            double rcv = Convert.ToDouble(textBox2.Text);
                            double chn = Convert.ToDouble(textBox3.Text);
                            cmd.CommandText = "INSERT INTO [Transaction](Transaction_ID,[DateTime],Revenue,Recieve,Change) SELECT '" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker1.Value.ToString() + "'," + Convert.ToDouble(textBox1.Text) + "," + rcv + "," + chn + "";
                            cmd.ExecuteNonQuery();
                            var a = dateTimePicker1.Value;
                            var aPlusMonth = a.AddMonths(3);
                            var next3Month = new DateTime(aPlusMonth.Year, aPlusMonth.Month, aPlusMonth.Day, aPlusMonth.Hour, aPlusMonth.Minute, aPlusMonth.Second);
                            if (total > 500 && total < 1000)
                            {
                                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                                var stringChars = new char[8];
                                var random = new Random();

                                for (int i = 0; i < stringChars.Length; i++)
                                {
                                    stringChars[i] = chars[random.Next(chars.Length)];
                                }

                                var finalString = new String(stringChars);
                                cmd.CommandText = "SELECT Promotion.Promotion_ID, Promotion.Release_Date, Promotion.Expire_Date, Promotion.Discount " +
                                    "FROM Promotion WHERE(((Promotion.Promotion_ID) = '" + finalString + "'))";
                                OleDbDataReader dr = cmd.ExecuteReader();
                                DataTable dt = new DataTable();
                                dt.Load(dr);



                                MessageBox.Show("CHANGE : " + textBox3.Text + " THB" + "\n" + "You got 30 THB discount for next time purchase");
                                while (dt.Rows.Count == 0)
                                {
                                    cmd.CommandText = "INSERT INTO [Promotion](Promotion_ID,Release_Date,Expire_Date,Discount) SELECT '" + finalString + "','" + dateTimePicker1.Value + "','" + next3Month + "'," + 30.0;
                                    cmd.ExecuteNonQuery();
                                    break;
                                }
                                promoid = finalString;


                            }
                            else if (total > 1000)
                            {
                                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                                var stringChars = new char[8];
                                var random = new Random();

                                for (int i = 0; i < stringChars.Length; i++)
                                {
                                    stringChars[i] = chars[random.Next(chars.Length)];
                                }

                                var finalString = new String(stringChars);
                                cmd.CommandText = "SELECT Promotion.Promotion_ID, Promotion.Release_Date, Promotion.Expire_Date, Promotion.Discount " +
                                    "FROM Promotion WHERE(((Promotion.Promotion_ID) = '" + finalString + "'))";
                                OleDbDataReader dr = cmd.ExecuteReader();
                                DataTable dt = new DataTable();
                                dt.Load(dr);


                                MessageBox.Show("CHANGE : " + textBox3.Text + " THB" + "\n" + "You got 70 THB discount for next time purchase");
                                while (dt.Rows.Count == 0)
                                {
                                    cmd.CommandText = "INSERT INTO [Promotion](Promotion_ID,Release_Date,Expire_Date,Discount) SELECT '" + finalString + "','" + dateTimePicker1.Value + "','" + next3Month + "'," + 70.0;
                                    cmd.ExecuteNonQuery();
                                    break;
                                }
                                promoid = finalString;

                            }
                            else
                            {

                                MessageBox.Show("CHANGE : " + textBox3.Text + " THB");
                                promoid = "";
                            }
                            printDocument1.Print();


                            foreach (var crt in cart)
                            {
                                int fid = crt.id;
                                int quan = crt.count;
                                cmd.CommandText = "INSERT INTO [Log]([Transaction_ID],ID,Quantity) SELECT '" + dateTimePicker1.Value.ToString() + "'," + fid + "," + quan + "";
                                cmd.ExecuteNonQuery();

                            }
                            conn.Close();



                            //MessageBox.Show("Invoic".Length.ToString());
                            conn.Open();
                            cmd.CommandText = "SELECT Promotion.Promotion_ID, Promotion.Release_Date, Promotion.Expire_Date, Promotion.Discount " +
                                "FROM Promotion WHERE(((Promotion.Promotion_ID) = '" + textBox4.Text + "'))";
                            //MessageBox.Show(cmd.CommandText);

                            OleDbDataReader dr2 = cmd.ExecuteReader();
                            DataTable dt2 = new DataTable();
                            dt2.Load(dr2);

                            if (dt2.Rows.Count == 1)
                            {
                                cmd.CommandText = "DELETE FROM Promotion WHERE Promotion_ID='" + textBox4.Text + "'";
                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();

                            clearing();
                        }
                        else
                        {
                            MessageBox.Show("Not enough money");



                        }
                    }
                }
                else
                {

                    MessageBox.Show("Wrong Input");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                int z = 0;
                foreach (var crt in cart)
                {
                    z += 1;
                    if (crt.name == label6.Text)
                    {
                        indexx = z - 1;
                    }
                }
                cart.RemoveAt(indexx);
                pictureBox2.Image = null;
                label6.Text = "";
                calculate();
                Refresh();




            }
        }
        public int xx = 300;
        public int yy = 600;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new
            System.Drawing.Printing.PaperSize("custom", xx, yy);


            Font f = label4.Font;
            Font fnt = new Font("Courier New", 8, FontStyle.Bold);
            Graphics g = e.Graphics;
            g.DrawString("Receipt", fnt, Brushes.Black, (xx-"Invoice".Length*8) / 2, 10);

            g.DrawString(dateTimePicker1.Value.ToString(), fnt, Brushes.Black, ((xx - dateTimePicker1.Value.ToString().Length*8) / 2)+10, 30);

            //g.DrawString("Invoice", label4.Font, Brushes.Black, (pictureBox1.Width - "Invoice".Length) / 2, 10);
            //g.DrawString(dateTimePicker1.Value.ToString(), label4.Font, Brushes.Black, (pictureBox1.Width - dateTimePicker1.Value.ToString().Length) / 2, 30);
          
            int i = 0;
            foreach (var crt in cart)
            {
                g.DrawString(crt.name + " x" + crt.count, f, Brushes.Black, xx / 8, 50 + (20*i));
                g.DrawString((crt.price*crt.count).ToString()+" THB", f, Brushes.Black, (3 * xx / 4)-((crt.count*crt.price).ToString().Length-1)*8, 50+(20*i));

                //g.DrawString(crt.name + " x" + crt.count, f, Brushes.Black, pictureBox1.Width / 4, 50 + (20 * i));
                //g.DrawString((crt.price * crt.count).ToString() + " THB", f, Brushes.Black, (3 * pictureBox1.Width / 4) - ((crt.count * crt.price).ToString().Length - 1) * 8, 50 + (20 * i));
                i += 1;

            }
            g.DrawString("Total", fnt, Brushes.Black, xx / 8, 50 + (20 * i));
            g.DrawString(textBox1.Text + " THB", fnt, Brushes.Black, (3 * xx / 4) - (textBox1.Text.Length - 1) * 8, 50 + (20 * i));
            i += 1;
            g.DrawString("Receive", fnt, Brushes.Black, xx / 8, 50 + (20 * i));
            g.DrawString(textBox2.Text + " THB", fnt, Brushes.Black, (3 * xx / 4) - (textBox2.Text.Length - 1) * 8, 50 + (20 * i));
            i += 1;
            g.DrawString("Change", fnt, Brushes.Black, xx / 8, 50 + (20 * i));
            g.DrawString(textBox3.Text + " THB", fnt, Brushes.Black, (3 * xx / 4) - (textBox3.Text.Length - 1) * 8, 50 + (20 * i));
            i += 1;
            g.DrawString("Discount", fnt, Brushes.Black, xx / 8, 50 + (20 * i));
            g.DrawString(discount + " THB", fnt, Brushes.Black, (3 * xx / 4) - (discount.ToString().Length - 1) * 8, 50 + (20 * i));
            i += 1;
            if (promoid != "")
            {
                BarcodeLib.Barcode bar = new BarcodeLib.Barcode();
                bar.Width = 200;
                bar.Height = 80;
                Image b = bar.Encode(BarcodeLib.TYPE.CODE128, promoid);
                g.DrawImage(b, (xx-200)/2, 50 + (20 * i),200,80);
                i += 1;
                g.DrawString("Discount Barcode", fnt, Brushes.Black, (xx - "Discount Barcode".Length * 8) / 2, 40 + (20 * i) + 80);

            }
            
        }
        public int category = 1;
        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.SandyBrown;
            button5.BackColor = default(Color);
            category = 1;
            pictureBox1.Image = null;
            all_menu();
            setPicturebox();
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.BackColor = default(Color);
            button5.BackColor = Color.SandyBrown;
            category = 2;
            pictureBox1.Image = null;
            all_menu();
            setPicturebox();
            Refresh();
        }
        public double discount;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            conn.Close();
            calculate();
            conn.Open();
            cmd.CommandText = "SELECT Promotion.Promotion_ID, Promotion.Release_Date, Promotion.Expire_Date, Promotion.Discount " +
                    "FROM Promotion WHERE(((Promotion.Promotion_ID) = '" + textBox4.Text  + "'))";
            //MessageBox.Show(cmd.CommandText);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);


           
                if (dt.Rows.Count == 1)
                {
                    if ((Convert.ToDateTime(dt.Rows[0][1]).Date  != dateTimePicker1.Value.Date))
                    {
                        int res = DateTime.Compare(dateTimePicker1.Value, Convert.ToDateTime(dt.Rows[0][2]));
                        if (res < 0)
                        {

                            discount = Convert.ToDouble(dt.Rows[0][3]);
                            textBox1.Text = (Convert.ToDouble(textBox1.Text) - discount).ToString();
                            textBox4.BackColor = Color.LightGreen;


                        }
                        else
                        {
                            MessageBox.Show("Your Promotion's code is expired");
                            discount = 0;
                            textBox1.Text = (Convert.ToDouble(textBox1.Text) - discount).ToString();
                            textBox4.BackColor = Color.Red;
                        }
                    }
                    else
                    {

                        textBox4.BackColor = Color.Red;
                        MessageBox.Show("Cannot use on the same day");

                    }

                }
                else
                {
                    textBox4.BackColor = Color.Red;

                }
            
            if (textBox4.Text == "")
            {

                textBox4.BackColor = default(Color);
            }
            conn.Close();

        }
    }
}
