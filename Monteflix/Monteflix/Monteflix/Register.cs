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
    public partial class Register : Form
    {
        string path = "Data Source=DESKTOP-SLKID4N;Initial Catalog=Monteflix;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand command;
        bool checkPass = false;

        public Register()
        {


            con = new SqlConnection(path);
            InitializeComponent();
            setPass();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void setPass()
        {
            txtPassword.UseSystemPasswordChar = true;
            txtCPassword.UseSystemPasswordChar = true;


            txtPassword.MaxLength = 14;
            txtCPassword.MaxLength = 14;
            txtUsername.MaxLength = 49;
            txtEmail.MaxLength = 49;
        }

        private void clear()
        {
            txtCPassword.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string checkPass = txtPassword.Text;
            string checkCPass = txtCPassword.Text;


            if (txtUsername.Text.ToString().Equals("") || txtEmail.Text.ToString().Equals("") || txtPassword.Text == "" || txtCPassword.Text == "")
            {
                MessageBox.Show("Please fill out the blanks!");
            } else if (checkCPass != checkPass)
            {
                MessageBox.Show("Please confirm your password properly!");
            }
            else {

                string Username = txtUsername.Text;
                string Password = txtPassword.Text;
                string Email = txtEmail.Text;

                try
                {
                    con.Open();
                    command = new SqlCommand("insert into Users (User_Name,User_Email,User_Password) values ('" + Username + "','" + Email+ "','" + Password + "')", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    clear();
                    MessageBox.Show("Registration successful!");
                } catch (Exception ex)
                {
                    MessageBox.Show("User already exists.");
                    con.Close();
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkPass == false)
            {
                txtCPassword.UseSystemPasswordChar = false;
                txtPassword.UseSystemPasswordChar = false;
                btnShowPass.Text = "Cover Password";
                checkPass = true;
            }
            else
            {
                txtCPassword.UseSystemPasswordChar = true;
                txtPassword.UseSystemPasswordChar = true;
                btnShowPass.Text = "Show Password";
                checkPass = false;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Close();

          
        }
    }
}
