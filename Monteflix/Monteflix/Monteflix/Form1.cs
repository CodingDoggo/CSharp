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
    public partial class Form1 : Form
    {
        string path = "Data Source=DESKTOP-SLKID4N;Initial Catalog=Monteflix;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand command;
        DataTable dt;
        string linkM = "";
        string currImage = "";
        bool moveImage = false;

        int ID;

        public Form1()
        {
            con = new SqlConnection(path);
            InitializeComponent();
            displayData();

          
            rbtnBad.AutoCheck = false;
            rbtnGood.AutoCheck = false;
            rbtnVeryGood.AutoCheck = false;

            btnSave.Enabled = false;
            btnTrailer.Enabled = false;




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }



        public void displayData()
        {
            
            try
            {
              

                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select Movie_ID,Movie_Title,Movie_Release,Movie_Genre,Movie_Review from Movies ", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            con.Open();
            adpt = new SqlDataAdapter("select Movie_ID,Movie_Title,Movie_Release,Movie_Genre,Movie_Review from Movies where Movie_Title like '%" + txtSearch.Text + "%'", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            labelTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            labelRelease.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            labelGenre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //linkM = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //currImage = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            con.Open();
            command = new SqlCommand("select Movie_Trailer from Movies where Movie_ID='" + ID + "' ", con);
            linkM = (string)command.ExecuteScalar();
            command = new SqlCommand("select Movie_Image from Movies where Movie_ID='" + ID + "'", con);
            currImage = (string)command.ExecuteScalar();

            con.Close();

            boxImage.BackgroundImage = Image.FromFile(currImage);




            rbtnBad.AutoCheck = true;
            rbtnGood.AutoCheck = true;
            rbtnVeryGood.AutoCheck = true;

            btnSave.Enabled = true;
            btnTrailer.Enabled = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbtnVeryGood.Checked == false && rbtnGood.Checked == false && rbtnBad.Checked == false)
            {
                MessageBox.Show("Please review the movie!");
            }
            else
            {
                string check = "";
                if (rbtnBad.Checked)
                {
                    check = "Bad";
                }
                else if (rbtnGood.Checked)
                {
                    check = "Good";
                }
                else
                {
                    check = "Very Good";
                }

                try
                {
                    con.Open();
                    command = new SqlCommand("update Movies set Movie_Review='" + check + "' where Movie_ID='" + ID + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    displayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTrailer_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start(linkM);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boxImage_Click(object sender, EventArgs e)
        {

        }

        private void timerLogo_Tick(object sender, EventArgs e)
        {
            if (moveImage == false)
            {
                femaleCorn.Location = new Point(257, 0);
                maleCorn.Location = new Point(194, -1);
                moveImage = true;
            }
            else
            {
                femaleCorn.Location = new Point(220, 0);
                maleCorn.Location = new Point(170, 0);
                moveImage = false;
            }


            }
        }
}
