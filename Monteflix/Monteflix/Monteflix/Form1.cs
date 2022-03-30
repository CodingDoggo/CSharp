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
        DataTable udt;
        string linkImdb = "";
        string linkW = "";
        string linkM = "";
        string currImage = "";
        bool moveImage = false;

        int IDUser;
        int ID;

        public Form1(string Value, int ID)
        {
            con = new SqlConnection(path);
            IDUser = ID;
            InitializeComponent();
            displayData();
            lblUserSign.Text = Value;
            

            rbtnBad.AutoCheck = false;
            rbtnGood.AutoCheck = false;
            rbtnVeryGood.AutoCheck = false;

            btnSave.Enabled = false;
            btnTrailer.Enabled = false;
            btnImdb.Enabled = false;
            btnWatch.Enabled = false;




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
                adpt = new SqlDataAdapter("select Movie_ID, Movie_Title, Movie_Release, Movie_Genre, Users_Movies_Review from Movies inner join Users_Movies on Movie_ID = FMovie_ID where FUser_ID = '"+ IDUser +"' UNION ALL select Movie_ID, Movie_Title, Movie_Release, Movie_Genre, NULL from Movies where Movie_ID NOT IN(SELECT Movie_ID FROM Movies inner join Users_Movies on Movie_ID = FMovie_ID where FUser_ID = '"+ IDUser +"')", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            con.Open();
            adpt = new SqlDataAdapter("select Movie_ID, Movie_Title, Movie_Release, Movie_Genre, Users_Movies_Review from Movies inner join Users_Movies on Movie_ID = FMovie_ID where FUser_ID = '" + IDUser + "' and Movie_Title like '%" + txtSearch.Text + "%'  UNION ALL select Movie_ID, Movie_Title, Movie_Release, Movie_Genre, NULL from Movies where Movie_ID NOT IN(SELECT Movie_ID FROM Movies inner join Users_Movies on Movie_ID = FMovie_ID where FUser_ID = '" + IDUser + "') and Movie_Title like '%" + txtSearch.Text + "%'", con);
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
            try
            {
                ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                labelTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                labelRelease.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                labelGenre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show("Slow down fella!");
            }

                con.Open();
                command = new SqlCommand("select Movie_Trailer from Movies where Movie_ID='" + ID + "' ", con);
                linkM = (string)command.ExecuteScalar();
                command = new SqlCommand("select Movie_Image from Movies where Movie_ID='" + ID + "'", con);
                currImage = (string)command.ExecuteScalar();
            
                command = new SqlCommand("select Movie_Watch from Movies where Movie_ID='" + ID + "'", con);
           
            try
            {
                linkW = (string)command.ExecuteScalar();
               
            }
            catch (Exception ex)
            {
                
                linkW = "";
                
            }

                command = new SqlCommand("select Movie_Rating from Movies where Movie_ID='" + ID + "'", con);
            try
            {
                linkImdb = (string)command.ExecuteScalar();
                
            }
            catch (Exception ex)
            {
                linkImdb = "";
                
            }

                con.Close();

                boxImage.BackgroundImage = Image.FromFile(currImage);




                rbtnBad.AutoCheck = true;
                rbtnGood.AutoCheck = true;
                rbtnVeryGood.AutoCheck = true;

                btnSave.Enabled = true;
                btnTrailer.Enabled = true;
                btnWatch.Enabled = true;
                btnImdb.Enabled = true;
            

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
                Int32 exists = 0;
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
                con.Open();
                command = new SqlCommand("select count(*) from Users_Movies where FMovie_ID='" + ID + "' and FUser_ID='"+IDUser+"'", con);
                exists = (Int32)command.ExecuteScalar();
                con.Close();


                if (exists == 0)
                {
                    try
                    {
                        con.Open();
                        command = new SqlCommand("insert into Users_Movies (FUser_ID,FMovie_ID,Users_Movies_Review) values ('" + IDUser + "','" + ID + "','" + check + "')", con);
                        command.ExecuteNonQuery();
                        con.Close();
                        displayData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
                else
                {
                    try
                    {
                        con.Open();
                        command = new SqlCommand("update Users_Movies set Users_Movies_Review='" + check + "' where FMovie_ID='" + ID + "' and FUser_ID='" + IDUser + "'", con);
                        command.ExecuteNonQuery();
                        con.Close();
                        displayData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
            }
        }

        private void btnTrailer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkM);
            } catch(Exception ex)
            {
                MessageBox.Show("Trailer not available.");
            }
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

       

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkW);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Movie not available.");
            }
        }

        private void btnImdb_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkImdb);
            }
            catch (Exception ex)
            {
                MessageBox.Show("IMDb not available.");
            }
        }
    }
}
