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
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panelhome.Enabled == true)
            {

                panelhome.Show();
                pictureBox8.Show();

                panelreport.Hide();
                listView1.Hide();
                label2.Hide();
                textBox1.Hide();
                label3.Hide();
                textBox2.Hide();
                pictureBox9.Hide();
                button2.Hide();
                button10.Hide();
                label4.Hide();

                panelsettings.Hide();
                groupBox1.Hide();
                listView2.Hide();

                panelinvent.Hide();
                groupBox2.Hide();
                listView3.Hide();

                panelhistory.Hide();
                listView4.Hide();
                label17.Hide();
                textBox9.Hide();
                pictureBox13.Hide();
                button9.Hide();


            }
        }

        //salesrep
        private void pictureBox17_Click(object sender, EventArgs e)
        {
             if (panelreport.Enabled == true)
            {
                panelreport.Show();
                listView1.Show();
                label2.Show();
                textBox1.Show();
                label3.Show();
                textBox2.Show();
                pictureBox9.Show();
                button2.Show();
                button10.Show();
                label4.Show();

                panelhome.Hide();
                pictureBox8.Hide();

                panelsettings.Hide();
                groupBox1.Hide();
                listView2.Hide();

                panelinvent.Hide();
                groupBox2.Hide();
                listView3.Hide();

                panelhistory.Hide();
                listView4.Hide();
                label17.Hide();
                textBox9.Hide();
                pictureBox13.Hide();
                button9.Hide();
            }
             listView1.Items.Clear();
             string transactionnum, fooditem, unitprice, quantity, crewlog, date, totalprice, ordernum;
             string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
             MySqlConnection Conn = new MySqlConnection(myConn);
             Conn.Open();
             MySqlCommand displaySR = new MySqlCommand();
             displaySR.Connection = Conn;
             displaySR.CommandText = "select * from salesreport";
             MySqlDataReader rdr = displaySR.ExecuteReader();
             while (rdr.Read())
             {
                 transactionnum = rdr.GetString(0).ToString();
                 fooditem = rdr.GetString(1).ToString();
                 unitprice = rdr.GetString(2).ToString();
                 quantity = rdr.GetString(3).ToString();
                 crewlog = rdr.GetString(4).ToString();
                 date = rdr.GetString(5).ToString();
                 totalprice = rdr.GetString(6).ToString();
                 ordernum = rdr.GetString(7).ToString();
                 //should've been placed directly to array rather than placing it in a variable
                 string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date, totalprice };

                 var listViewItem = new ListViewItem(row);
                 listView1.Items.Add(listViewItem);
             }
        }

        //inventory
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (panelinvent.Enabled == true)
            {
                panelinvent.Show();
                groupBox2.Show();
                listView3.Show();

                panelreport.Hide();
                listView1.Hide();
                label2.Hide();
                textBox1.Hide();
                label3.Hide();
                textBox2.Hide();
                pictureBox9.Hide();
                button2.Hide();
                button10.Hide();
                label4.Hide();

                panelhome.Hide();
                pictureBox8.Hide();

                panelsettings.Hide();
                groupBox1.Hide();
                listView2.Hide();



                panelhistory.Hide();
                listView4.Hide();
                label17.Hide();
                textBox9.Hide();
                pictureBox13.Hide();
                button9.Hide();

            }

            string inventoryitem, category, stockstring;
            int stocknum=0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            Conn.Open();
            MySqlCommand inventCMD = new MySqlCommand();
            inventCMD.CommandText = "Select * from inventory";
            inventCMD.Connection = Conn;

            listView3.Items.Clear();

            MySqlDataReader rdr = inventCMD.ExecuteReader();

            while (rdr.Read())
            {
                inventoryitem = rdr.GetString(0).ToString();
                category = rdr.GetString(1).ToString();
                stockstring = rdr.GetInt32(2).ToString();
                stocknum = rdr.GetInt32(2);
                string[] row = { inventoryitem, category, stockstring };
                var listViewItem = new ListViewItem(row);
                listView3.Items.Add(listViewItem);

            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (panelsettings.Enabled == true)
            {
                 panelsettings.Show();
                groupBox1.Show();
                listView2.Show();

                panelinvent.Hide();
                groupBox2.Hide();
                listView3.Hide();

                panelreport.Hide();
                listView1.Hide();
                label2.Hide();
                textBox1.Hide();
                label3.Hide();
                textBox2.Hide();
                pictureBox9.Hide();
                button2.Hide();
                button10.Hide();
                label4.Hide();

                panelhome.Hide();
                pictureBox8.Hide();



                panelinvent.Hide();
                groupBox2.Hide();
                listView3.Hide();

                panelhistory.Hide();
                listView4.Hide();
                label17.Hide();
                textBox9.Hide();
                pictureBox13.Hide();
                button9.Hide();
            }
            listView2.Items.Clear();

            string username, fname, lname, address, contact;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand displayAS = new MySqlCommand();
            displayAS.Connection = Conn;
            displayAS.CommandText = "select * from users";
            Conn.Open();
            MySqlDataReader rdr = displayAS.ExecuteReader();
            while (rdr.Read())
            {
                username = rdr.GetString(0);
                fname = rdr.GetString(3);
                lname = rdr.GetString(4);
                address = rdr.GetString(5);
                contact = rdr.GetString(6);

                string[] row = { username, fname, lname, address, contact };
                var listViewItem = new ListViewItem(row);
                listView2.Items.Add(listViewItem);
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (panelhistory.Enabled == true)
            {
                panelhistory.Show();
                listView4.Show();
                label17.Show();
                textBox9.Show();
                pictureBox13.Show();
                button9.Show();

                 panelsettings.Hide();
                groupBox1.Hide();
                listView2.Hide();

                panelinvent.Hide();
                groupBox2.Hide();
                listView3.Hide();

                panelreport.Hide();
                listView1.Hide();
                label2.Hide();
                textBox1.Hide();
                label3.Hide();
                textBox2.Hide();
                pictureBox9.Hide();
                button2.Hide();
                button10.Hide();
                label4.Hide();

                panelhome.Hide();
                pictureBox8.Hide();

                panelsettings.Hide();
                groupBox1.Hide();
                listView2.Hide();

                panelinvent.Hide();
                groupBox2.Hide();
                listView3.Hide();


            }
            listView4.Items.Clear();
            string username, crewname, timein, timeout, date;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand displayLH = new MySqlCommand();
            displayLH.Connection = Conn;
            Conn.Open();
            displayLH.CommandText = "select * from loginhistory";
            MySqlDataReader rdr = displayLH.ExecuteReader();
            while (rdr.Read())
            {
                username = rdr.GetString(3);
                crewname = rdr.GetString(4);
                timein = rdr.GetString(1);
                timeout = rdr.GetString(2);
                date = rdr.GetString(0);

                string[] row = { username, crewname, timein, timeout, date };
                var listViewItem = new ListViewItem(row);
                listView4.Items.Add(listViewItem);
            }

        }

        private void panelsettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //inventory update button
        private void button6_Click(object sender, EventArgs e)
        {
            string comboboxstring = comboBox1.Text;
            string stockstring = textBox11.Text.ToString();
            int stocknum = Convert.ToInt32(stockstring);
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            Conn.Open();
            MySqlCommand updateINV = new MySqlCommand();
            updateINV.Connection = Conn;
            updateINV.CommandText = "update inventory set inventoryitem=@inventoryitem, category=@category, stocknum=@stocknum where inventoryitem=@inventoryitem";
            updateINV.Parameters.AddWithValue("@inventoryitem", comboBox2.Text);
            updateINV.Parameters.AddWithValue("@category", comboboxstring);
            updateINV.Parameters.AddWithValue("@stocknum", stocknum);
            updateINV.ExecuteNonQuery();

            MessageBox.Show(comboBox2.Text + " is updated!");

            string inventoryitem, category, stockstring2;
            int stocknum2 = 0;
            MySqlCommand inventCMD = new MySqlCommand();
            inventCMD.CommandText = "Select * from inventory";
            inventCMD.Connection = Conn;

            listView3.Items.Clear();

            MySqlDataReader rdr = inventCMD.ExecuteReader();

            while (rdr.Read())
            {
                inventoryitem = rdr.GetString(0).ToString();
                category = rdr.GetString(1).ToString();
                stockstring2 = rdr.GetInt32(2).ToString();
                stocknum2 = rdr.GetInt32(2);
                string[] row = { inventoryitem, category, stockstring2 };
                var listViewItem = new ListViewItem(row);
                listView3.Items.Add(listViewItem);

            }
        }

        //item clicks from inventory
        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string inventoryitem="", category="", stockstring="";
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);

            if (listView3.SelectedItems.Count > 0)
            {
                inventoryitem = listView3.SelectedItems[0].SubItems[0].Text;
            }


            Conn.Open();
            MySqlCommand setLabels = new MySqlCommand();
            setLabels.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
            setLabels.Connection = Conn;
            setLabels.Parameters.AddWithValue("@inventoryitem", inventoryitem);
            MySqlDataReader rdr = setLabels.ExecuteReader();
            while (rdr.Read())
            {
                inventoryitem = rdr.GetString(0).ToString();
                category = rdr.GetString(1).ToString();
                stockstring = rdr.GetInt32(2).ToString();
            }

            comboBox2.Text = inventoryitem;
            textBox11.Text = stockstring;
            comboBox1.Text = category;
        }

        //inventory delete button
        private void button5_Click(object sender, EventArgs e)
        {
            string inventoryitem, category, stockstring;
            int stocknum = 0;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand deleteInv = new MySqlCommand();
            deleteInv.Connection = Conn;
            Conn.Open();
            deleteInv.CommandText = "delete from inventory where inventoryitem=@inventoryitem";
            deleteInv.Parameters.AddWithValue("@inventoryitem", comboBox2.Text);
            deleteInv.ExecuteNonQuery();

            MessageBox.Show(comboBox2.Text + " is deleted.");

            MySqlCommand inventCMD = new MySqlCommand();
            inventCMD.CommandText = "Select * from inventory";
            inventCMD.Connection = Conn;

            listView3.Items.Clear();

            MySqlDataReader rdr = inventCMD.ExecuteReader();

            while (rdr.Read())
            {
                inventoryitem = rdr.GetString(0).ToString();
                category = rdr.GetString(1).ToString();
                stockstring = rdr.GetInt32(2).ToString();
                stocknum = rdr.GetInt32(2);
                string[] row = { inventoryitem, category, stockstring };
                var listViewItem = new ListViewItem(row);
                listView3.Items.Add(listViewItem);

            }
        }

        //inventory create button
        private void button7_Click(object sender, EventArgs e)
        {
            string inventoryitem, category;
            string comboboxstring = comboBox1.Text;
            string stockstring = textBox11.Text.ToString();
            int stocknum = Convert.ToInt32(stockstring);
            try
            {
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection Conn = new MySqlConnection(myConn);
                MySqlCommand newItem = new MySqlCommand();
                newItem.Connection = Conn;
                Conn.Open();
                newItem.CommandText = "insert into inventory(inventoryitem, category, stocknum) values(@inventoryitem, @category, @stocknum)";
                newItem.Parameters.AddWithValue("@inventoryitem", comboBox2.Text);
                newItem.Parameters.AddWithValue("@category", comboboxstring);
                newItem.Parameters.AddWithValue("@stocknum", stocknum);
                newItem.ExecuteNonQuery();

                MessageBox.Show(comboBox2.Text + " added!");

                MySqlCommand inventCMD = new MySqlCommand();
                inventCMD.CommandText = "Select * from inventory";
                inventCMD.Connection = Conn;

                listView3.Items.Clear();

                MySqlDataReader rdr = inventCMD.ExecuteReader();

                while (rdr.Read())
                {
                    inventoryitem = rdr.GetString(0).ToString();
                    category = rdr.GetString(1).ToString();
                    stockstring = rdr.GetInt32(2).ToString();
                    stocknum = rdr.GetInt32(2);
                    string[] row = { inventoryitem, category, stockstring };
                    var listViewItem = new ListViewItem(row);
                    listView3.Items.Add(listViewItem);

                }
            }
            catch (Exception wa)
            {
                MessageBox.Show(comboBox2.Text + " already exists! Please use Update button.");
            }


        }

        //inserts tiemout session
        private void label28_Click(object sender, EventArgs e)
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

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username="", password, fname, lname, address, contact;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);

            if (listView2.SelectedItems.Count > 0)
            {
                username = listView2.SelectedItems[0].SubItems[0].Text;
            }

            MySqlCommand setAccount = new MySqlCommand();
            setAccount.Connection = Conn;
            Conn.Open();
            setAccount.CommandText = "select * from users where username=@username";
            setAccount.Parameters.AddWithValue("@username", username);
            MySqlDataReader rdr = setAccount.ExecuteReader();
            while (rdr.Read())
            {
                password = rdr.GetString(1);
                fname = rdr.GetString(3);
                lname = rdr.GetString(4);
                address = rdr.GetString(5);
                contact = rdr.GetString(6);

                textBox3.Text = fname;
                textBox4.Text = lname;
                richTextBox1.Text = address;
                textBox5.Text = username;
                textBox7.Text = password;
                textBox6.Text = contact;
            }
            Conn.Close();
        }

        //account settings update button
        private void button4_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            string username = "", password, fname, lname, address, contact;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand updateAC = new MySqlCommand();
            Conn.Open();
            updateAC.Connection = Conn;
            updateAC.CommandText = "update users set username=@username, password=@password, fname=@fname, lname=@lname, address=@address, contact=@contact where username=@username";
            updateAC.Parameters.AddWithValue("@username", textBox5.Text);
            updateAC.Parameters.AddWithValue("@password", textBox7.Text);
            updateAC.Parameters.AddWithValue("@fname", textBox3.Text);
            updateAC.Parameters.AddWithValue("@lname", textBox4.Text);
            updateAC.Parameters.AddWithValue("@address", richTextBox1.Text);
            updateAC.Parameters.AddWithValue("@contact", textBox6.Text);
            updateAC.ExecuteNonQuery();
            MySqlCommand setAccount = new MySqlCommand();
            setAccount.Connection = Conn;
            setAccount.CommandText = "select * from users";
            MySqlDataReader rdr = setAccount.ExecuteReader();
            while (rdr.Read())
            {
                username = rdr.GetString(0);
                password = rdr.GetString(1);
                fname = rdr.GetString(3);
                lname = rdr.GetString(4);
                address = rdr.GetString(5);
                contact = rdr.GetString(6);
                string[] row = { username, fname, lname, address, contact };
                var listViewItem = new ListViewItem(row);
                listView2.Items.Add(listViewItem);
            }

            MessageBox.Show("User is updated!");
        }

        private void update_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            string username = "", password, fname, lname, address, contact;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand deleteAS = new MySqlCommand();
            deleteAS.Connection = Conn;
            Conn.Open();
            deleteAS.CommandText = "delete from users where username=@username";
            deleteAS.Parameters.AddWithValue("@username", textBox5.Text);
            deleteAS.ExecuteNonQuery();

            MySqlCommand setAccount = new MySqlCommand();
            setAccount.Connection = Conn;

            setAccount.CommandText = "select * from users";
            MySqlDataReader rdr = setAccount.ExecuteReader();
            while (rdr.Read())
            {
                username = rdr.GetString(0);
                password = rdr.GetString(1);
                fname = rdr.GetString(3);
                lname = rdr.GetString(4);
                address = rdr.GetString(5);
                contact = rdr.GetString(6);
                string[] row = { username, fname, lname, address, contact };
                var listViewItem = new ListViewItem(row);
                listView2.Items.Add(listViewItem);
            }
            MessageBox.Show("User is deleted.");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string []refreshments = {"Wintermelon",  "Triple Chocolate", "Taro", "Strawberry Milkshake", "Pink/Blue/Lemonade", "Hokaido", "Lychee", "Green Apple", "Strawberry", "Buco Pandan" , "Coffee Crumble" , "Green Cucumber" , "Bottled Water", "Mango" , "Blueberry" , "Cookies and Cream", "Chocolate" , "Softdrinks in Can" , "Orange Juice" , "Okinawa"};
            string Refresh = comboBox2.Text.ToString();
            bool refExists = refreshments.Contains(Refresh);
            if (refExists == true)
            {
                comboBox1.Text = "Refreshments";
            }
            string[] sBurgers = { "Basic Life Support Burger Meal", "Advance Life Support Burger Meal", "Vital Sings Stable Burger Meal", "Myrocardial Infraction Burger Meal", "Diet as Tolerated Burger Meal", "Keep Veins Open Burger Meal" };
            string sBurgerString = comboBox2.Text.ToString();
            bool sBurgerExists = sBurgers.Contains(sBurgerString);
            if (sBurgerExists == true)
            {
                comboBox1.Text = "Signature Burgers";
            }
        }
    }
}
