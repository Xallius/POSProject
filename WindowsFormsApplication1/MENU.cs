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
            string fooditem="", unitprice="", ordernum="";
            int total=0, quantity=0, total2=0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand checkCMD = new MySqlCommand();
            checkCMD.Connection = Conn;
            Conn.Open();
            checkCMD.CommandText = "Select * from salesinvoice";
            MySqlDataReader rdr = checkCMD.ExecuteReader();

            while (rdr.Read())
            {
                total = rdr.GetInt32(2);
                quantity = rdr.GetInt32(0);
                fooditem = rdr.GetString(1);
                unitprice = rdr.GetString(3);
                ordernum = rdr.GetString(4);
                total2 += total;
                string[] row = { ordernum, quantity.ToString(), fooditem, total.ToString() };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
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

            if (listView1.Items.Count == 0)

            {
                MessageBox.Show("Cannot proceed to checkout without ordered items!");
                return;
            }
            else{
            this.Hide();
            CHECKOUT C = new CHECKOUT();
            C.ShowDialog();
            }
        }

        //milktea
        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //Wintermelon
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

                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Wintermelon");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Wintermelon is out of stock!");
                    return;
                }
                reader.Close();
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
            //Taro
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Taro");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Taro is out of stock!");
                    return;
                }
                reader.Close();
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
            //Chocolate Milktea
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Chocolate");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Chocolate Milktea is out of stock!");
                    return;
                }
                reader.Close();
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
            //Hokaido
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Hokaido");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Hokaido is out of stock!");
                    return;
                }
                reader.Close();
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
            //Okinawa
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Okinawa");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Okinawa is out of stock!");
                    return;
                }
                reader.Close();
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
            //Lychee
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Lychee");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Lychee is out of stock!");
                    return;
                }
                reader.Close();
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
                        if (checkBox1.Checked)
                        {
                            totalprice += 10;
                        }
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
            //Green Apple
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Green Apple");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Green Apple is out of stock!");
                    return;
                }
                reader.Close();
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
                        if (checkBox1.Checked)
                        {
                            totalprice += 10;
                        }
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
            //Mango
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Mango");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Blueberry is out of stock!");
                    return;
                }
                reader.Close();
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
                        if (checkBox1.Checked)
                        {
                            totalprice += 10;
                        }
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
            //Blueberry
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Blueberry");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Blueberry is out of stock!");
                    return;
                }
                reader.Close();
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
                        if (checkBox1.Checked)
                        {
                            totalprice += 10;
                        }
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
            //Strawberry
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Strawberry");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Strawberry is out of stock!");
                    return;
                }
                reader.Close();
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
                        if (checkBox1.Checked)
                        {
                            totalprice += 10;
                        }
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
        //Cookies and Cream
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Cookies and Cream");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Cookies and Cream is out of stock!");
                return;
            }
            reader.Close();
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

        //Triple Chocolate
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Triple Chocolate");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Triple Chocolate is out of stock!");
                return;
            }
            reader.Close();
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

        //Strawberry Milkshake
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Strawberry Milkshake");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Strawberry Milkshake is out of stock!");
                return;
            }
            reader.Close();
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

        //Buco Pandan
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Buco Pandan");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Buco Pandan is out of stock!");
                return;
            }
            reader.Close();
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

        //Coffee Crumble
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Coffee Crumble");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Coffee Crumble is out of stock!");
                return;
            }
            reader.Close();
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

        //Pink/Blue/Lemonade
        private void pictureBox21_Click(object sender, EventArgs e)
        {

            string itemname = "", quantity = "", amount = "", unitprice = "";
            int totalprice = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection conn = new MySqlConnection(myConn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Pink/Blue/Lemonade");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Pink/Blue/Lemonade is out of stock!");
                return;
            }
            reader.Close();
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
        //Orange Juice
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Orange Juice");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Orange Juice is out of stock!");
                return;
            }
            reader.Close();
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
        //Green Cucumber
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Green Cucumber");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Green Cucumber is out of stock!");
                return;
            }
            reader.Close();
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

        //Softdrinks in Can
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Softdrinks in Can");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Softdrinks in Can is out of stock!");
                return;
            }
            reader.Close();
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

        //Bottled Water
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Bottled Water");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Bottled Water is out of stock!");
                return;
            }
            reader.Close();
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

        //basic life support burger meal
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Basic Life Support Burger Meal");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Basic Life Support Burger Meal is out of stock!");
                return;
            }
            reader.Close();
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

        //advance life support burger meal
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Advanced Life Support Burger Meal");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Advanced Life Support Burger Meal is out of stock!");
                return;
            }
            reader.Close();
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

        //vital signs stable burger meal
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Vital Signs Stable Burger Meal");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Vital Signs Stable Burger Meal is out of stock!");
                return;
            }
            reader.Close();
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
        //Myocardial infraction burger meal
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Myocardial Infraction Burger Meal");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Myocardial Infraction Burger Meal is out of stock!");
                return;
            }
            reader.Close();
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
        //diet as tolerated burger meal
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Diet as Tolerated Burger Meal");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Diet as Tolerated Burger Meal is out of stock!");
                return;
            }
            reader.Close();
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
        //keep veins open burger meal
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Keep Veins Open Burger Meal");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Keep Veins Open Burger Meal is out of stock!");
                return;
            }
            reader.Close();
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
            //basic check up meal
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Basic Check-up Meal");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Basic Check-up Meal is out of stock!");
                    return;
                }
                reader.Close();
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
            //emergency check-up meal
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Emergency Check-up Meal");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Emergency Check-up Meal is out of stock!");
                    return;
                }
                reader.Close();
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
            //diagnostic check-up meal
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Diagnostic Check-up Meal");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Diagnostic Check-up Meal is out of stock!");
                    return;
                }
                reader.Close();
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
            //executive check-up meal
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Executive Check-up Meal");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Executive Check-up Meal is out of stock!");
                    return;
                }
                reader.Close();
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
            //hawaiian pizza meduim
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Hawaiian Pizza Medium");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Hawaiian Pizza Medium is out of stock!");
                    return;
                }
                reader.Close();
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
            //hawaiian pizza large
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Hawaiian Pizza Large");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Hawaiian Pizza Large is out of stock!");
                    return;
                }
                reader.Close();
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
            //pepperoni pizza medium
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Pepperoni Pizza Medium");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Pepperoni Pizza Medium is out of stock!");
                    return;
                }
                reader.Close();
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
            //pepperoni pizza large
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Pepperoni Pizza Large");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Pepperoni Pizza Large is out of stock!");
                    return;
                }
                reader.Close();
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
        //carbonara
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Carbonara");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Carbonara is out of stock!");
                return;
            }
            reader.Close();
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
        //spaghetti
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Spaghetti");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Spaghetti is out of stock!");
                return;
            }
            reader.Close();
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
            //cardio-pulmonary meal
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Cardio-pulmonary Meal");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Cardio-pulmonary Meal is out of stock!");
                    return;
                }
                reader.Close();
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
            //complete bed rest meal
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
                //check if item is present in inventory
                cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                cmd.Parameters.AddWithValue("@inventoryitem", "Complete Bed Rest Meal");
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Complete Bed Rest Meal is out of stock!");
                    return;
                }
                reader.Close();
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
        //shoestring fries
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Shoestring Fries");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Shoestring Fries is out of stock!");
                return;
            }
            reader.Close();
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
        //chicken popcorn
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Chicken Popcorn");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Chicken Popcorn is out of stock!");
                return;
            }
            reader.Close();
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
        //beefy cheesy nachos
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Beefy Cheesy Nachos");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Beefy Cheesy Nachos is out of stock!");
                return;
            }
            reader.Close();
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
        //sweet and spicy wings
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
            //check if item is present in inventory
            cmd.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            cmd.Parameters.AddWithValue("@inventoryitem", "Sweet and Spicy Wings");
            MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                MessageBox.Show("Sweet and Spicy Wings is out of stock!");
                return;
            }
            reader.Close();
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
          DialogResult result = MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo);
          if(result == DialogResult.Yes)
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
          else
          {
            return;
          }
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
                deleteOD.Parameters.AddWithValue("@ordernum", ordernumstring);
                deleteOD.ExecuteNonQuery();
                Conn.Close();
            }

        }

    }
}
