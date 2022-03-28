using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monteflix
{
    public partial class Login : Form
    {
        string path = "Data Source=DESKTOP-SLKID4N;Initial Catalog=Monteflix;Integrated Security=True";
        SqlConnection con;
        SqlCommand command;
        bool checkPass = false;
        
        public Login()
        {
            con = new SqlConnection(path);
            InitializeComponent();
            setPass();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.FormClosed += new FormClosedEventHandler(frontClose);
            this.Hide();
            reg.Show();
            
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (checkPass == false)
            {
               
                txtPassword.UseSystemPasswordChar = false;
                btnShowPass.Text = "Cover Password";
                checkPass = true;
            }
            else
            {
               
                txtPassword.UseSystemPasswordChar = true;
                btnShowPass.Text = "Show Password";
                checkPass = false;
            }
        }

        private void setPass()
        {
            txtPassword.UseSystemPasswordChar = true;
            

            txtPassword.MaxLength = 14;
            txtUsername.MaxLength = 49;
            txtEmail.MaxLength = 49;
        }

        private void clear()
        {
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void frontClose(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.ToString().Equals("") || txtEmail.Text.ToString().Equals("") || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill out the blanks!");
            }
            else
            {

                string Username = txtUsername.Text;
                string Password = txtPassword.Text;
                string Email = txtEmail.Text;
                   

                Int32 count = 0;

                try
                {
                    con.Open();
                    command = new SqlCommand("select count(*) from Users where User_Name='" + Username + "'and User_Email='" + Email + "' and User_Password='" + Password + "'", con);
                    count = (Int32)command.ExecuteScalar();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
                if(count == 1 && Username.Equals("Admin") && Email.Equals("monteflix.admin@gmail.com"))
                {
                    AdminPanel admin = new AdminPanel();
                    admin.FormClosed += new FormClosedEventHandler(frontClose);
                    this.Hide();
                    admin.Show();
                    MessageBox.Show("Welcome admin!");
                }

                else if (count == 1)
                {
                    Form1 frm = new Form1();
                    frm.FormClosed += new FormClosedEventHandler(frontClose);
                    this.Hide();
                    frm.Show();
                    MessageBox.Show("Successful login");

                }
                else
                {
                    MessageBox.Show("Wrong credentials, try again.");
                    clear();
                }

            }
        }

        
    }
}
