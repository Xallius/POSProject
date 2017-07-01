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
            int addprice = 0;
            //all fields have value (both from and to)
            if (comboBox3.Text != null && textBox2.Text != null && comboBox8.Text != null && textBox1.Text != null)
            {
                if (textBox8.Text != null && textBox10.Text != null)
                {
                    string monthCon = comboBox3.Text;
                    string monthCon2 = comboBox8.Text;
                    switch (monthCon)
                    {
                        case "January":
                            monthCon = "1";
                            break;
                        case "February":
                            monthCon = "2";
                            break;
                        case "March":
                            monthCon = "3";
                            break;
                        case "April":
                            monthCon = "4";
                            break;
                        case "May":
                            monthCon = "5";
                            break;
                        case "June":
                            monthCon = "6";
                            break;
                        case "July":
                            monthCon = "7";
                            break;
                        case "August":
                            monthCon = "8";
                            break;
                        case "September":
                            monthCon = "9";
                            break;
                        case "October":
                            monthCon = "10";
                            break;
                        case "November":
                            monthCon = "11";
                            break;
                        case "December":
                            monthCon = "12";
                            break;
                    }
                    switch (monthCon2)
                    {
                        case "January":
                            monthCon2 = "1";
                            break;
                        case "February":
                            monthCon2 = "2";
                            break;
                        case "March":
                            monthCon2 = "3";
                            break;
                        case "April":
                            monthCon2 = "4";
                            break;
                        case "May":
                            monthCon2 = "5";
                            break;
                        case "June":
                            monthCon2 = "6";
                            break;
                        case "July":
                            monthCon2 = "7";
                            break;
                        case "August":
                            monthCon2 = "8";
                            break;
                        case "September":
                            monthCon2 = "9";
                            break;
                        case "October":
                            monthCon2 = "10";
                            break;
                        case "November":
                            monthCon2 = "11";
                            break;
                        case "December":
                            monthCon2 = "12";
                            break;
                    }
                    DateTime date2;
                    listView1.Items.Clear();
                    string transactionnum, fooditem, unitprice, quantity, crewlog, totalprice, ordernum;
                    string dateIn = comboBox3.Text + "/" + textBox8.Text + "/" + textBox2.Text;
                    string dateIn2 = comboBox8.Text + "/" + textBox10.Text + "/" + textBox1.Text;
                    MessageBox.Show(dateIn);
                    string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                    MySqlConnection Conn = new MySqlConnection(myConn);
                    Conn.Open();
                    MySqlCommand searchDate = new MySqlCommand();
                    searchDate.Connection = Conn;
                    searchDate.CommandText = "select * from salesreport where date between @date and @date2";
                    searchDate.Parameters.AddWithValue("@date", Convert.ToDateTime(dateIn));
                    searchDate.Parameters.AddWithValue("@date2", Convert.ToDateTime(dateIn2));
                    MySqlDataReader rdr = searchDate.ExecuteReader();

                    while (rdr.Read())
                    {
                        transactionnum = rdr.GetString(0).ToString();
                        fooditem = rdr.GetString(1).ToString();
                        unitprice = rdr.GetString(2).ToString();
                        quantity = rdr.GetString(3).ToString();
                        crewlog = rdr.GetString(4).ToString();

                        string getdate = rdr.GetString(5);
                        date2 = Convert.ToDateTime(getdate);
                        string date3 = date2.ToString("d");
                        totalprice = rdr.GetString(6).ToString();
                        addprice += rdr.GetInt32(6);
                        ordernum = rdr.GetString(7).ToString();
                        string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date3, totalprice };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                        label29.Text = addprice.ToString();
                    }
                }
                else if (textBox10.Text == null)
                {
                    MessageBox.Show("please enter a day!");
                    return;
                }
            }
            else if (comboBox3.Text != null && textBox2.Text != null)
            {
                if (textBox8.Text != null)
                {
                    string monthCon = comboBox3.Text;
                    switch (monthCon)
                    {
                        case "January":
                            monthCon = "1";
                            break;
                        case "February":
                            monthCon = "2";
                            break;
                        case "March":
                            monthCon = "3";
                            break;
                        case "April":
                            monthCon = "4";
                            break;
                        case "May":
                            monthCon = "5";
                            break;
                        case "June":
                            monthCon = "6";
                            break;
                        case "July":
                            monthCon = "7";
                            break;
                        case "August":
                            monthCon = "8";
                            break;
                        case "September":
                            monthCon = "9";
                            break;
                        case "October":
                            monthCon = "10";
                            break;
                        case "November":
                            monthCon = "11";
                            break;
                        case "December":
                            monthCon = "12";
                            break;
                    }
                    DateTime date2;
                    listView1.Items.Clear();
                    string transactionnum, fooditem, unitprice, quantity, crewlog, totalprice, ordernum;
                    string dateIn= comboBox3.Text + "/" + textBox8.Text + "/" + textBox2.Text;
                    MessageBox.Show(dateIn);
                    string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                    MySqlConnection Conn = new MySqlConnection(myConn);
                    Conn.Open();
                    MySqlCommand searchDate = new MySqlCommand();
                    searchDate.Connection = Conn;
                    searchDate.CommandText = "select * from salesreport where date=@date";
                    searchDate.Parameters.AddWithValue("@date", Convert.ToDateTime(dateIn));
                    MySqlDataReader rdr = searchDate.ExecuteReader();

                    while (rdr.Read())
                    {
                        transactionnum = rdr.GetString(0).ToString();
                        fooditem = rdr.GetString(1).ToString();
                        unitprice = rdr.GetString(2).ToString();
                        quantity = rdr.GetString(3).ToString();
                        crewlog = rdr.GetString(4).ToString();

                        string getdate = rdr.GetString(5);
                        date2 = Convert.ToDateTime(getdate);
                        string date3 = date2.ToString("d");
                        totalprice = rdr.GetString(6).ToString();
                        addprice += rdr.GetInt32(6);

                        ordernum = rdr.GetString(7).ToString();
                        string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date3, totalprice };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                        label29.Text = addprice.ToString();
                    }
                }
                    //if day doesnt have value
                else if (textBox8.Text == null)
                {
                    MessageBox.Show("Please enter day number!");
                    return;
                }
            }

            
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
                
                label3.Hide();
                comboBox3.Hide();
                textBox8.Hide();
                textBox2.Hide();
                textBox10.Hide();
                textBox1.Hide();
                comboBox8.Hide();
                pictureBox9.Hide();
                button2.Hide();
                
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
                label3.Show();
                comboBox3.Show();
                textBox8.Show();
                textBox2.Show();
                textBox10.Show();
                textBox1.Show();
                comboBox8.Show();
                pictureBox9.Show();
                button2.Show();
                
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
            int addprice = 0;
            DateTime date2;
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

                string getdate = rdr.GetString(5);
                date2 = Convert.ToDateTime(getdate);
                string date3 = date2.ToString("d");
                totalprice = rdr.GetString(6).ToString();
                addprice += rdr.GetInt32(6);
                ordernum = rdr.GetString(7).ToString();
                string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date3, totalprice };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                label29.Text = addprice.ToString();
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
                label3.Hide();
                comboBox3.Hide();
                textBox8.Hide();
                textBox2.Hide();
                textBox10.Hide();
                textBox1.Hide();
                comboBox8.Hide();
                pictureBox9.Hide();
                button2.Hide();
                
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

            rdr.Close();
            Conn.Close();
            foreach (ColumnHeader sColumnHeader in listView3.Columns)
            {
                foreach (ListViewItem item in listView3.Items)
                {
                    if (item.SubItems[2].Text == "10")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "9")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "8")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "7")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "6")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "5")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "4")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "3")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "2")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "1")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "0")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Blue;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Blue;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Blue;
                    }
                }
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
                label3.Hide();
                comboBox3.Hide();
                textBox8.Hide();
                textBox2.Hide();
                textBox10.Hide();
                textBox1.Hide();
                comboBox8.Hide();
                pictureBox9.Hide();
                button2.Hide();
                
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
                comboBox3.Hide();
                textBox8.Hide();
                textBox2.Hide();
                textBox10.Hide();
                textBox1.Hide();
                comboBox8.Hide();
                label3.Hide();
                pictureBox9.Hide();
                button2.Hide();
                
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
            rdr.Close();
            Conn.Close();
            foreach (ColumnHeader sColumnHeader in listView3.Columns)
            {
                foreach (ListViewItem item in listView3.Items)
                {
                    if (item.SubItems[2].Text == "10")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "9")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "8")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "7")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "6")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "5")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "4")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "3")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "2")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "1")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "0")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Blue;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Blue;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Blue;
                    }
                }
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
            rdr.Close();
            Conn.Close();
            foreach (ColumnHeader sColumnHeader in listView3.Columns)
            {
                foreach (ListViewItem item in listView3.Items)
                {
                    if (item.SubItems[2].Text == "10")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "9")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "8")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "7")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "6")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "5")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "4")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "3")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "2")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "1")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Red;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Red;
                    }
                    else if (item.SubItems[2].Text == "0")
                    {
                        listView3.Items[item.Index].UseItemStyleForSubItems = false;
                        listView3.Items[item.Index].SubItems[2]
                                                    .BackColor = Color.Blue;
                        listView3.Items[item.Index].SubItems[1]
                                                    .BackColor = Color.Blue;
                        listView3.Items[item.Index].SubItems[0]
                                                    .BackColor = Color.Blue;
                    }
                }
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

                rdr.Close();
                Conn.Close();

                foreach (ColumnHeader sColumnHeader in listView3.Columns)
                {
                    foreach (ListViewItem item in listView3.Items)
                    {
                        if (item.SubItems[2].Text == "10")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "9")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "8")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "7")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "6")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "5")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "4")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "3")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "2")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "1")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Red;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Red;
                        }
                        else if (item.SubItems[2].Text == "0")
                        {
                            listView3.Items[item.Index].UseItemStyleForSubItems = false;
                            listView3.Items[item.Index].SubItems[2]
                                                        .BackColor = Color.Blue;
                            listView3.Items[item.Index].SubItems[1]
                                                        .BackColor = Color.Blue;
                            listView3.Items[item.Index].SubItems[0]
                                                        .BackColor = Color.Blue;
                        }
                    }
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
             DialogResult result = MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo);
             if (result == DialogResult.Yes)
             {

                 /*string getSession;
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
                 insertTO.ExecuteNonQuery();*/

                 this.Hide();
                 LOGIN ad = new LOGIN();
                 ad.ShowDialog();
             }
             else
             {
                 return;
             }
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
            if (textBox5.Text == "admin")
            {
                MessageBox.Show("cannot delete admin account!");
                return;
            }
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
            string[] sSandwich = { "Basic Check-up Meal", "Emergency Check-up Meal", "Diagnostic Check-up Meal", "Executive Check-up Meal" };
            string sSandwichString = comboBox2.Text.ToString();
            bool sSandwichExists = sSandwich.Contains(sSandwichString);
            if (sSandwichExists == true)
            {
                comboBox1.Text = "Signature Sandwich";
            }
            string[] pizzapasta = { "Hawaiian Pizza Medium", "Hawaiian Pizza Large", "Pepperoni Pizza Medium", "Pepperoni Pizza Large", "Carbonara", "Spaghetti" };
            string pizzapastastring = comboBox2.Text.ToString();
            bool pizzapastaexists = pizzapasta.Contains(pizzapastastring);
            if (pizzapastaexists == true)
            {
                comboBox1.Text = "Pizza and Pasta";
            }
            string[] ricemeal = { "Cardio-pulmonary Meal", "Complete Bed Rest Meal" };
            string ricemealstring = comboBox2.Text.ToString();
            bool ricemealexists = ricemeal.Contains(ricemealstring);
            if (ricemealexists == true)
            {
                comboBox1.Text = "Rice Meals";
            }
            string[] sides = { "Shoestring Fries", "Chicken Popcorn", "Beefy Cheesy Nachos", "Sweet and Spicy Wings" };
            string sidesstring = comboBox2.Text.ToString();
            bool sidesexists = sides.Contains(sidesstring);
            if (sidesexists == true)
            {
                comboBox1.Text = "Sides";
            }
        }

        //sales report print button
        private void button10_Click(object sender, EventArgs e)
        {

        }

        //sales report refresh button
        private void button2_Click(object sender, EventArgs e)
        {
            int addprice = 0;
            DateTime date2;
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

                string getdate = rdr.GetString(5);
                date2 = Convert.ToDateTime(getdate);
                string date3 = date2.ToString("d");
                totalprice = rdr.GetString(6).ToString();
                addprice += rdr.GetInt32(6);
                ordernum = rdr.GetString(7).ToString();
                string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date3, totalprice };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                label29.Text = addprice.ToString();
            }
        }

        //login history refresh button
        private void button9_Click(object sender, EventArgs e)
        {
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

        //login history search button
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            string username, crewname, timein, timeout, date;
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand displayLH = new MySqlCommand();
            displayLH.Connection = Conn;
            Conn.Open();
            displayLH.CommandText = "select * from loginhistory where user=@user";
            displayLH.Parameters.AddWithValue("@user", textBox9.Text);
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

        //login history user search enter key
        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listView4.Items.Clear();
                string username, crewname, timein, timeout, date;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection Conn = new MySqlConnection(myConn);
                MySqlCommand displayLH = new MySqlCommand();
                displayLH.Connection = Conn;
                Conn.Open();
                displayLH.CommandText = "select * from loginhistory where user=@user";
                displayLH.Parameters.AddWithValue("@user", textBox9.Text);
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
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            
            
            
            //left side field only
            if (comboBox3.Text != null && textBox2.Text != null)
            {
                if (textBox8.Text != null)
                {
                    int addprice = 0;
                    string monthCon = comboBox3.Text;
                    switch (monthCon)
                    {
                        case "January":
                            monthCon = "1";
                            break;
                        case "February":
                            monthCon = "2";
                            break;
                        case "March":
                            monthCon = "3";
                            break;
                        case "April":
                            monthCon = "4";
                            break;
                        case "May":
                            monthCon = "5";
                            break;
                        case "June":
                            monthCon = "6";
                            break;
                        case "July":
                            monthCon = "7";
                            break;
                        case "August":
                            monthCon = "8";
                            break;
                        case "September":
                            monthCon = "9";
                            break;
                        case "October":
                            monthCon = "10";
                            break;
                        case "November":
                            monthCon = "11";
                            break;
                        case "December":
                            monthCon = "12";
                            break;
                    }
                    DateTime date2;
                    listView1.Items.Clear();
                    string transactionnum, fooditem, unitprice, quantity, crewlog, totalprice, ordernum;
                    string dateIn = comboBox3.Text + "/" + textBox8.Text + "/" + textBox2.Text;
                    string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                    MySqlConnection Conn = new MySqlConnection(myConn);
                    Conn.Open();
                    MySqlCommand searchDate = new MySqlCommand();
                    searchDate.Connection = Conn;
                    searchDate.CommandText = "select * from salesreport where date=@date";
                    searchDate.Parameters.AddWithValue("@date", Convert.ToDateTime(dateIn));
                    MySqlDataReader rdr = searchDate.ExecuteReader();

                    while (rdr.Read())
                    {
                        transactionnum = rdr.GetString(0).ToString();
                        fooditem = rdr.GetString(1).ToString();
                        unitprice = rdr.GetString(2).ToString();
                        quantity = rdr.GetString(3).ToString();
                        crewlog = rdr.GetString(4).ToString();

                        string getdate = rdr.GetString(5);
                        date2 = Convert.ToDateTime(getdate);
                        string date3 = date2.ToString("d");
                        totalprice = rdr.GetString(6).ToString();
                        addprice += rdr.GetInt32(6);

                        ordernum = rdr.GetString(7).ToString();
                        string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date3, totalprice };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                        label29.Text = addprice.ToString();
                    }
                }
                //if day doesnt have value
                else if (textBox8.Text == null)
                {
                    MessageBox.Show("Please enter day number!");
                    return;
                }
            }
            //all fields have value (both from and to)
            if (comboBox8.Text != "" && textBox1.Text != "" && textBox10.Text != "")
            {
                int addprice = 0;
                string monthCon = comboBox3.Text;
                string monthCon2 = comboBox8.Text;
                switch (monthCon)
                {
                    case "January":
                        monthCon = "1";
                        break;
                    case "February":
                        monthCon = "2";
                        break;
                    case "March":
                        monthCon = "3";
                        break;
                    case "April":
                        monthCon = "4";
                        break;
                    case "May":
                        monthCon = "5";
                        break;
                    case "June":
                        monthCon = "6";
                        break;
                    case "July":
                        monthCon = "7";
                        break;
                    case "August":
                        monthCon = "8";
                        break;
                    case "September":
                        monthCon = "9";
                        break;
                    case "October":
                        monthCon = "10";
                        break;
                    case "November":
                        monthCon = "11";
                        break;
                    case "December":
                        monthCon = "12";
                        break;
                }
                switch (monthCon2)
                {
                    case "January":
                        monthCon2 = "1";
                        break;
                    case "February":
                        monthCon2 = "2";
                        break;
                    case "March":
                        monthCon2 = "3";
                        break;
                    case "April":
                        monthCon2 = "4";
                        break;
                    case "May":
                        monthCon2 = "5";
                        break;
                    case "June":
                        monthCon2 = "6";
                        break;
                    case "July":
                        monthCon2 = "7";
                        break;
                    case "August":
                        monthCon2 = "8";
                        break;
                    case "September":
                        monthCon2 = "9";
                        break;
                    case "October":
                        monthCon2 = "10";
                        break;
                    case "November":
                        monthCon2 = "11";
                        break;
                    case "December":
                        monthCon2 = "12";
                        break;
                }
                DateTime date2;
                listView1.Items.Clear();
                string transactionnum, fooditem, unitprice, quantity, crewlog, totalprice, ordernum;
                string dateIn = comboBox3.Text + "/" + textBox8.Text + "/" + textBox2.Text;
                string dateIn2 = comboBox8.Text + "/" + textBox10.Text + "/" + textBox1.Text;

                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection Conn = new MySqlConnection(myConn);
                Conn.Open();
                MySqlCommand searchDate = new MySqlCommand();
                searchDate.Connection = Conn;
                searchDate.CommandText = "select * from salesreport where date between @date and @date2";
                searchDate.Parameters.AddWithValue("@date", Convert.ToDateTime(dateIn));
                searchDate.Parameters.AddWithValue("@date2", Convert.ToDateTime(dateIn2));
                MySqlDataReader rdr = searchDate.ExecuteReader();

                while (rdr.Read())
                {
                    transactionnum = rdr.GetString(0).ToString();
                    fooditem = rdr.GetString(1).ToString();
                    unitprice = rdr.GetString(2).ToString();
                    quantity = rdr.GetString(3).ToString();
                    crewlog = rdr.GetString(4).ToString();

                    string getdate = rdr.GetString(5);
                    date2 = Convert.ToDateTime(getdate);
                    string date3 = date2.ToString("d");
                    totalprice = rdr.GetString(6).ToString();
                    addprice += rdr.GetInt32(6);
                    ordernum = rdr.GetString(7).ToString();
                    string[] row = { ordernum, transactionnum, fooditem, unitprice, quantity, crewlog, date3, totalprice };
                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                    label29.Text = addprice.ToString();
                }
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string username = "", password = "", fname = "", lname = "", address = "", contact = "";
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection Conn = new MySqlConnection(myConn);
                MySqlCommand newItem = new MySqlCommand();
                newItem.Connection = Conn;
                Conn.Open();
                newItem.CommandText = "insert into users(username,password,fname,lname,address,contact) values(@username,@password,@fname,@lname,@address,@contact)";
                newItem.Parameters.AddWithValue("@fname", textBox3.Text);
                newItem.Parameters.AddWithValue("@lname", textBox4.Text);
                newItem.Parameters.AddWithValue("@address", richTextBox1.Text);
                newItem.Parameters.AddWithValue("@username", textBox5.Text);
                newItem.Parameters.AddWithValue("@password", textBox7.Text);
                newItem.Parameters.AddWithValue("@contact", textBox6.Text);
                newItem.ExecuteNonQuery();

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
                MessageBox.Show("User has been added!");
            }
            catch (Exception a)
            {
                MessageBox.Show(textBox5.Text + " already exists! Please use the update button instead.");
            }
        }
    }
}
