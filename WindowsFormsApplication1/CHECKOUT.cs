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

    public partial class CHECKOUT : Form
    {
        int change = 0;
        string ordernum = "";
        string unitprice;
        string crewname;
        int getCrew;
        int transactionnum = 0;
        int total = 0;
        int total2 = 0;
        public CHECKOUT()
        {
            InitializeComponent();
             int quantity;

            double totald = 0;
            double total3 = 0;

            string fooditem;
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
            totald = total2 * 0.12;
            total3 = total2 - totald;
            //label8.Text = total3.ToString();
            label10.Text = total2.ToString();
            rdr.Close();
            checkCMD.CommandText = "Select * from transactionnumber";
            MySqlDataReader reader = checkCMD.ExecuteReader();
            while (reader.Read())
            {
                transactionnum = reader.GetInt32(0);
            }
            reader.Close();
            checkCMD.CommandText = "select max(getSession) from loginhistory";
            getCrew = Convert.ToInt32(checkCMD.ExecuteScalar());
            checkCMD.CommandText = "select * from loginhistory where getSession=@getsession";
            checkCMD.Parameters.AddWithValue("@getsession", getCrew);
            MySqlDataReader reader2 = checkCMD.ExecuteReader();
            while (reader2.Read())
            {
                crewname = reader2.GetString(3);
            }
            reader2.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int total = 0, total2 = 0;
            int money=0;
            try
            {
                money = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception a)
            {
                label11.Text = "";
            }
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
                total2 += total;
                change = money - total2;
            }

            if (change < 0)
            {
                label11.Text = "";
            }
            else
            {
                label11.Text = change.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "")
            {
                MessageBox.Show("please input a number");
                return;
            }
            else if (change < 0)
            {
                MessageBox.Show("Inadequate amount of money.");
                return;
            }
            string fooditem = "";

            int quantity = 0, totalprice = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                int invValue = 0;
                int newIntValue = 0;
                string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
                MySqlConnection Conn = new MySqlConnection(myConn);

                ordernum = listView1.Items[i].SubItems[0].Text;
                quantity = Convert.ToInt32(listView1.Items[i].SubItems[1].Text);
                totalprice = Convert.ToInt32(listView1.Items[i].SubItems[3].Text);
                fooditem = listView1.Items[i].SubItems[2].Text;
                MySqlCommand getUP = new MySqlCommand();
                Conn.Open();
                getUP.Connection = Conn;
                getUP.CommandText = "select * from inventory where inventoryitem=@inventoryitem";
                getUP.Parameters.AddWithValue("@inventoryitem", fooditem);
                MySqlDataReader reader = getUP.ExecuteReader();
                while (reader.Read())
                {
                    invValue = reader.GetInt32(2);
                    newIntValue = invValue - quantity;
                }
                reader.Close();
                getUP.CommandText = "select price from menu where fooditem=@fooditem";
                getUP.Parameters.AddWithValue("@fooditem", fooditem);
                MySqlDataReader rdr = getUP.ExecuteReader();
                while (rdr.Read())
                {
                    unitprice = rdr.GetString("price").ToString();
                }
                rdr.Close();
                
                getUP.CommandText = "update inventory set stocknum=@stocknum where inventoryitem=@inventoryitem2";
                getUP.Parameters.AddWithValue("@inventoryitem2", fooditem);
                getUP.Parameters.AddWithValue("@stocknum", newIntValue);
                getUP.ExecuteNonQuery();
                
                MySqlCommand insertSR = new MySqlCommand();
                insertSR.Connection = Conn;
                insertSR.CommandText = "insert into salesreport(transactionnum, quantity, totalprice, fooditem, date, crewlog, unitprice, ordernum)values(@transactionnum, @quantity, @totalprice, @fooditem, CURDATE(), @crewlog, @unitprice, @ordernum)";
                insertSR.Parameters.AddWithValue("@totalprice", totalprice);
                insertSR.Parameters.AddWithValue("@quantity", quantity);
                insertSR.Parameters.AddWithValue("@fooditem", fooditem);
                insertSR.Parameters.AddWithValue("@transactionnum", transactionnum);
                insertSR.Parameters.AddWithValue("@crewlog", crewname);
                insertSR.Parameters.AddWithValue("@unitprice", unitprice);
                insertSR.Parameters.AddWithValue("@ordernum", ordernum);
                insertSR.ExecuteNonQuery();
            }
            transactionnum++;
            string myConn2 = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn2 = new MySqlConnection(myConn2);
            MySqlCommand updateTN = new MySqlCommand();
            updateTN.Connection = Conn2;
            Conn2.Open();
            updateTN.CommandText = "update transactionnumber set transactionnum=@transactionnum";
            updateTN.Parameters.AddWithValue("@transactionnum", transactionnum);
            updateTN.ExecuteNonQuery();
            updateTN.CommandText = "TRUNCATE TABLE salesinvoice";
            updateTN.ExecuteNonQuery();
            MessageBox.Show("Transaction complete");
            MENU men = new MENU();
            this.Hide();
            men.ShowDialog();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MENU chk = new MENU();
            chk.ShowDialog();
        }
    }
}
