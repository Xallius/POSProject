using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class MENU : Form
    {
        public int ordernumber = 1;

        public MENU()
        {
            InitializeComponent();


        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CHECKOUT C = new CHECKOUT();
            C.ShowDialog();
        }

        //milktea
        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                if (numericUpDown11.Value == 0)
                {
                    MessageBox.Show("Please input a number!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice=0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown11.Value));
                cmd.Parameters.AddWithValue("@itemnum", 1);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 0, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown11.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown11.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
                cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();

                ordernumber++;
            }
            if (radioButton5.Checked == true)
            {

                if (numericUpDown11.Value == 0)
                {
                    MessageBox.Show("Please input a number!");
                    return;
                }

                
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown11.Value));
                cmd.Parameters.AddWithValue("@itemnum", 2);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 1, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown11.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown11.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
                cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();

                ordernumber++;
            }
            if (radioButton4.Checked == true)
            {

                if (numericUpDown11.Value == 0)
                {
                    MessageBox.Show("Please input a number!");
                    return;
                }


                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown11.Value));
                cmd.Parameters.AddWithValue("@itemnum", 3);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 2, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown11.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown11.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();

                ordernumber++;
            }
            if (radioButton3.Checked == true)
            {

                if (numericUpDown11.Value == 0)
                {
                    MessageBox.Show("Please input a number!");
                    return;
                }


                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown11.Value));
                cmd.Parameters.AddWithValue("@itemnum", 4);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 3, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown11.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown11.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton2.Checked == true)
            {
                if (numericUpDown11.Value == 0)
                {
                    MessageBox.Show("Please input a number!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown11.Value));
                cmd.Parameters.AddWithValue("@itemnum", 5);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 4, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown11.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown11.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
        }
        //fruit tea
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                if (numericUpDown12.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown12.Value));
                cmd.Parameters.AddWithValue("@itemnum", 6);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 5, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown12.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown12.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton6.Checked == true)
            {
                if (numericUpDown12.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown12.Value));
                cmd.Parameters.AddWithValue("@itemnum", 7);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 6, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown12.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown12.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton7.Checked == true)
            {
                if (numericUpDown12.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown12.Value));
                cmd.Parameters.AddWithValue("@itemnum", 8);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 7, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown12.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown12.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton8.Checked == true)
            {
                if (numericUpDown12.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown12.Value));
                cmd.Parameters.AddWithValue("@itemnum", 9);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 8, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown12.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown12.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton9.Checked == true)
            {
                if (numericUpDown12.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown12.Value));
                cmd.Parameters.AddWithValue("@itemnum", 10);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 9, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown12.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown12.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown1.Value));
            cmd.Parameters.AddWithValue("@itemnum", 11);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 10, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown1.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown1.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown2.Value));
            cmd.Parameters.AddWithValue("@itemnum", 12);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 11, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown2.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown2.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown3.Value));
            cmd.Parameters.AddWithValue("@itemnum", 13);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 12, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown3.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown3.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (numericUpDown6.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown6.Value));
            cmd.Parameters.AddWithValue("@itemnum", 14);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 13, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown6.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown6.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

            if (numericUpDown5.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown5.Value));
            cmd.Parameters.AddWithValue("@itemnum", 15);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 14, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown5.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown5.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown4.Value));
            cmd.Parameters.AddWithValue("@itemnum", 16);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 15, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown4.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown4.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (numericUpDown8.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown8.Value));
            cmd.Parameters.AddWithValue("@itemnum", 17);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 16, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown8.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown8.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {

            if (numericUpDown9.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown9.Value));
            cmd.Parameters.AddWithValue("@itemnum", 18);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 17, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown9.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown9.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString()); 
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            if (numericUpDown7.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown7.Value));
            cmd.Parameters.AddWithValue("@itemnum", 19);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 18, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown7.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown7.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (numericUpDown10.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown10.Value));
            cmd.Parameters.AddWithValue("@itemnum", 20);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 19, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown10.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown10.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (numericUpDown13.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown13.Value));
            cmd.Parameters.AddWithValue("@itemnum", 21);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 20, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown13.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown13.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            if (numericUpDown14.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown14.Value));
            cmd.Parameters.AddWithValue("@itemnum", 22);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 21, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown14.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown14.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            if (numericUpDown15.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown15.Value));
            cmd.Parameters.AddWithValue("@itemnum", 23);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 22, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown15.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown15.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            if (numericUpDown16.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown16.Value));
            cmd.Parameters.AddWithValue("@itemnum", 24);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 23, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown16.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown16.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            if (numericUpDown17.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown17.Value));
            cmd.Parameters.AddWithValue("@itemnum", 25);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 24, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown17.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown17.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            if (numericUpDown18.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown18.Value));
            cmd.Parameters.AddWithValue("@itemnum", 26);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 25, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown18.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown18.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            if (radioButton15.Checked == true)
            {
                if (numericUpDown19.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown19.Value));
                cmd.Parameters.AddWithValue("@itemnum", 27);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 26, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown19.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown19.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton11.Checked == true)
            {

                if (numericUpDown19.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown19.Value));
                cmd.Parameters.AddWithValue("@itemnum", 28);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 27, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown19.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown19.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton12.Checked == true)
            {
                if (numericUpDown19.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown19.Value));
                cmd.Parameters.AddWithValue("@itemnum", 29);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 28, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown19.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown19.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton13.Checked == true)
            {
                if (numericUpDown19.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown19.Value));
                cmd.Parameters.AddWithValue("@itemnum", 30);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 29, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown19.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown19.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            if (radioButton18.Checked == true)
            {
                if (numericUpDown20.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown20.Value));
                cmd.Parameters.AddWithValue("@itemnum", 31);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 30, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown20.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown20.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton16.Checked == true)
            {
                if (numericUpDown20.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown20.Value));
                cmd.Parameters.AddWithValue("@itemnum", 32);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 31, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown20.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown20.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }

        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {
            if (radioButton17.Checked == true)
            {
                if (numericUpDown21.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown21.Value));
                cmd.Parameters.AddWithValue("@itemnum", 33);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 32, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown21.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown21.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
            if (radioButton14.Checked == true)
            {
                if (numericUpDown21.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown21.Value));
                cmd.Parameters.AddWithValue("@itemnum", 34);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 33, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown21.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown21.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {

            if (numericUpDown22.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown22.Value));
            cmd.Parameters.AddWithValue("@itemnum", 35);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 34, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown22.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown22.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            if (numericUpDown23.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown23.Value));
            cmd.Parameters.AddWithValue("@itemnum", 36);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 35, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown23.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown23.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {
            if (radioButton20.Checked == true)
            {
                if (numericUpDown24.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }
                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown24.Value));
                cmd.Parameters.AddWithValue("@itemnum", 37);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 36, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown24.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown24.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }

            if (radioButton19.Checked == true)
            {

                if (numericUpDown24.Value == 0)
                {
                    MessageBox.Show("Please input value!");
                    return;
                }

                string itemname = "", quantity = "", amount = "", unitprice = "";
                int totalprice = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection conn = new MySqlConnection(myConn);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                //updates quantity to how much item(s) is requested
                cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown24.Value));
                cmd.Parameters.AddWithValue("@itemnum", 38);
                cmd.ExecuteNonQuery();
                //grabs the item requested
                cmd.CommandText = "Select * from menu LIMIT 37, 1";

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                    itemname = rdr.GetString("fooditem").ToString();
                    quantity = rdr.GetString("quantity").ToString();
                    amount = rdr.GetString("price").ToString();
                    //if value isn't 0 yet, calculates price according to numericUpDown's value
                    while (numericUpDown24.Value != 0)
                    {
                        totalprice += rdr.GetInt32("price");
                        numericUpDown24.Value--;
                    }
                    string orderstring = ordernumber.ToString();
                    amount = totalprice.ToString();
                    string[] row = { orderstring, itemname, quantity, amount };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
                rdr.Close();

                //inserts ordered item into salesinvoice
               cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
                cmd.Parameters.AddWithValue("@quantity2", quantity);
                cmd.Parameters.AddWithValue("@fooditem", itemname);
                cmd.Parameters.AddWithValue("@total", totalprice.ToString());
                cmd.Parameters.AddWithValue("@unitprice", unitprice);
                cmd.Parameters.AddWithValue("@ordernum", ordernumber);
                cmd.ExecuteNonQuery();
                conn.Close();
                ordernumber++;
            }
        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {
            if (numericUpDown25.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown25.Value));
            cmd.Parameters.AddWithValue("@itemnum", 39);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 38, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown25.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown25.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox85_Click(object sender, EventArgs e)
        {
            if (numericUpDown26.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown26.Value));
            cmd.Parameters.AddWithValue("@itemnum", 40);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 39, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown26.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown26.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox88_Click(object sender, EventArgs e)
        {
            if (numericUpDown27.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown27.Value));
            cmd.Parameters.AddWithValue("@itemnum", 41);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 40, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown27.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown27.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void pictureBox91_Click(object sender, EventArgs e)
        {
            if (numericUpDown28.Value == 0)
            {
                MessageBox.Show("Please input value!");
                return;
            }
            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //updates quantity to how much item(s) is requested
            cmd.CommandText = "update menu set quantity=@quantity where itemnum=@itemnum";
            cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(numericUpDown28.Value));
            cmd.Parameters.AddWithValue("@itemnum", 42);
            cmd.ExecuteNonQuery();
            //grabs the item requested
            cmd.CommandText = "Select * from menu LIMIT 41, 1";

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                unitprice = rdr.GetString("price").ToString();
                itemname = rdr.GetString("fooditem").ToString();
                quantity = rdr.GetString("quantity").ToString();
                amount = rdr.GetString("price").ToString();
                //if value isn't 0 yet, calculates price according to numericUpDown's value
                while (numericUpDown28.Value != 0)
                {
                    totalprice += rdr.GetInt32("price");
                    numericUpDown28.Value--;
                }
                string orderstring = ordernumber.ToString();
                amount = totalprice.ToString();
                string[] row = { orderstring, itemname, quantity, amount };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
            rdr.Close();

            //inserts ordered item into salesinvoice
           cmd.CommandText = "insert into salesinvoice(quantity, fooditem, total, unitprice, ordernum)values(@quantity2, @fooditem, @total, @unitprice, @ordernum)";
            cmd.Parameters.AddWithValue("@quantity2", quantity);
            cmd.Parameters.AddWithValue("@fooditem", itemname);
            cmd.Parameters.AddWithValue("@total", totalprice.ToString());
            cmd.Parameters.AddWithValue("@unitprice", unitprice);
            cmd.Parameters.AddWithValue("@ordernum", ordernumber);
            cmd.ExecuteNonQuery();
            conn.Close();
            ordernumber++;
        }

        private void label53_Click(object sender, EventArgs e)
        {
            string getSession;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand insertTO = new MySqlCommand();
            insertTO.Connection = Conn;
            insertTO.CommandText = "select max(getSession) from loginhistory";
            Conn.Open();
            getSession = insertTO.ExecuteScalar().ToString();

            insertTO.CommandText = "update loginhistory set timeout=@timeout where getSession=@getSession";
            insertTO.Parameters.AddWithValue("@timeout", DateTime.Now.ToShortTimeString());
            insertTO.Parameters.AddWithValue("@getSession", Convert.ToInt32(getSession));
            insertTO.ExecuteNonQuery();

            this.Hide();
            LOGIN ad = new LOGIN();
            ad.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("please click on an item to void.");
            }
            string ordernumstring = "";
            while (listView1.SelectedItems.Count > 0)
            {
                ordernumstring = listView1.SelectedItems[0].SubItems[0].Text;
                listView1.Items.Remove(listView1.SelectedItems[0]);
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection Conn = new MySqlConnection(myConn);
                Conn.Open();
                MySqlCommand deleteOD = new MySqlCommand();
                deleteOD.Connection = Conn;
                deleteOD.CommandText = "delete from salesinvoice where ordernum=@ordernum";
                deleteOD.ExecuteNonQuery();
                Conn.Close();
            }

        }

    }
}
