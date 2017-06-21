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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = "username";

            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Text = "password";

        }
       
        private void Form1_Shown(Object sender, EventArgs e)
        {
           
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "username";
                textBox1.ForeColor = SystemColors.GrayText;
            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }

        }

        /*private void username_TextChanged(object sender, EventArgs e)
        {

        }*/

       

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "password";
                textBox2.ForeColor = SystemColors.GrayText;
            }

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb = "", passdb = "";
            string fname="", lname="";
            string usertype = "";
            string date = DateTime.Now.ToShortDateString();
            string timein = DateTime.Now.ToShortTimeString();
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand checkUser = new MySqlCommand();
            checkUser.Connection = Conn;
            Conn.Open();
            checkUser.CommandText = "select * from users where username=@username";
            checkUser.Parameters.AddWithValue("@username", user);
            MySqlDataReader getUser = checkUser.ExecuteReader();
            if (getUser.Read())
            {
                userdb = getUser.GetString(0);
                passdb = getUser.GetString(1);
                usertype = getUser.GetString(2);
                fname = getUser.GetString(3);
                lname = getUser.GetString(4);
                if (userdb == user && passdb == password)
                {
                    if (usertype == "B")
                    {
                        MessageBox.Show("User type is crew! Please use Crew button instead.");
                        return;

                    }
                    
                    getUser.Close();
                    checkUser.CommandText = "insert into loginhistory(date, timein, user, crewname)values(@date,@timein,@user,@crewname)";
                    checkUser.Parameters.AddWithValue("@date", date);
                    checkUser.Parameters.AddWithValue("@timein", timein);
                    checkUser.Parameters.AddWithValue("@user", user);
                    checkUser.Parameters.AddWithValue("@crewname", fname + " " + lname);
                    checkUser.ExecuteNonQuery();
                    this.Hide();
                    ADMIN ad = new ADMIN();
                    ad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect user or password!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Incorrect user or password!");
                return;
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usertype = "";
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb = "", passdb = "";
            string fname = "", lname = "";
            string date = DateTime.Now.ToShortDateString();
            string timein = DateTime.Now.ToShortTimeString();
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand checkUser = new MySqlCommand();
            checkUser.Connection = Conn;
            Conn.Open();
            checkUser.CommandText = "select * from users where username=@username";
            checkUser.Parameters.AddWithValue("@username", user);
            MySqlDataReader getUser = checkUser.ExecuteReader();
            if (getUser.Read())
            {
                userdb = getUser.GetString(0);
                passdb = getUser.GetString(1);
                usertype = getUser.GetString(2);
                fname = getUser.GetString(3);
                lname = getUser.GetString(4);
                if (userdb == user && passdb == password)
                {

                    if (usertype == "A")
                    {
                        MessageBox.Show("User type is Admin! Please use Admin button instead.");
                        return;
                    }
                    getUser.Close();
                    checkUser.CommandText = "insert into loginhistory(date, timein, user, crewname)values(@date,@timein,@user,@crewname)";
                    checkUser.Parameters.AddWithValue("@date", date);
                    checkUser.Parameters.AddWithValue("@timein", timein);
                    checkUser.Parameters.AddWithValue("@user", user);
                    checkUser.Parameters.AddWithValue("@crewname", fname + " " + lname);
                    checkUser.ExecuteNonQuery();
                    this.Hide();
                    MENU M = new MENU();
                    M.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect user or password!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Incorrect user or password!");
                return;
            }
            
            
            
            
        }

        private void LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string usertype = "";
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb = "", passdb = "";
            string fname = "", lname = "";
            string date = DateTime.Now.ToShortDateString();
            string timein = DateTime.Now.ToShortTimeString();
            string myConn = "Server=127.0.0.1;Database=munchlab;Uid=root;Pwd=root;";
            MySqlConnection Conn = new MySqlConnection(myConn);
            MySqlCommand checkUser = new MySqlCommand();
            checkUser.Connection = Conn;
            Conn.Open();
            checkUser.CommandText = "select * from users where username=@username";
            checkUser.Parameters.AddWithValue("@username", user);
            MySqlDataReader getUser = checkUser.ExecuteReader();
            if (getUser.Read())
            {
                userdb = getUser.GetString(0);
                passdb = getUser.GetString(1);
                usertype = getUser.GetString(2);
                fname = getUser.GetString(3);
                lname = getUser.GetString(4);
                if (userdb == user && passdb == password)
                {

                    
                    getUser.Close();
                    checkUser.CommandText = "insert into loginhistory(date, timein, user, crewname)values(@date,@timein,@user,@crewname)";
                    checkUser.Parameters.AddWithValue("@date", date);
                    checkUser.Parameters.AddWithValue("@timein", timein);
                    checkUser.Parameters.AddWithValue("@user", user);
                    checkUser.Parameters.AddWithValue("@crewname", fname + " " + lname);
                    checkUser.ExecuteNonQuery();
                    if (usertype == "B")
                    {
                        this.Hide();
                        MENU M = new MENU();
                        M.ShowDialog();
                    }
                    if (usertype == "A")
                    {
                        this.Hide();
                        ADMIN ad = new ADMIN();
                        ad.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect user or password!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Incorrect user or password!");
                return;
            }
        }

       
    }
}
