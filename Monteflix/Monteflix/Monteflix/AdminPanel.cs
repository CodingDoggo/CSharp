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
    public partial class AdminPanel : Form
    {
        string path = "Data Source=DESKTOP-SLKID4N;Initial Catalog=Monteflix;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter adpt;
        SqlCommand command;
        DataTable dt;
        string linkM = "";
        string currImage = "";
       

        int ID;

        public AdminPanel()
        {
            con = new SqlConnection(path);
            InitializeComponent();
            displayData();
            btnAddMovie.Enabled = false;
            btnUpdateMovie.Enabled = false;
            btnDeleteMovie.Enabled = false;
            btnTrailer.Enabled = false;
            

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void displayData()
        {

            try
            {


                dt = new DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select Movie_ID,Movie_Title,Movie_Release,Movie_Genre,Movie_Trailer,Movie_Image from Movies ", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

            con.Open();
            adpt = new SqlDataAdapter("select Movie_ID,Movie_Title,Movie_Release,Movie_Genre,Movie_Trailer,Movie_Image from Movies where Movie_Title like '%" + txtSearch.Text + "%'", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddMovie.Enabled = true;
            btnDeleteMovie.Enabled = true;
            btnUpdateMovie.Enabled = true;
            btnTrailer.Enabled = true;

            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            labelTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            labelRelease.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtRelease.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            labelGenre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGenre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            con.Open();
            command = new SqlCommand("select Movie_Trailer from Movies where Movie_ID='" + ID + "' ", con);
            linkM = (string)command.ExecuteScalar();
            labelTrailer.Text = linkM;
            txtTrailer.Text = linkM;
            command = new SqlCommand("select Movie_Image from Movies where Movie_ID='" + ID + "'", con);
            currImage = (string)command.ExecuteScalar();
            labelImage.Text = currImage;
            txtImage.Text = currImage;
            con.Close();



            boxImage.BackgroundImage = Image.FromFile(currImage);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtTitle.Text = "";
            txtRelease.Text = "";
            txtGenre.Text = "";
            txtTrailer.Text = "";
            txtImage.Text = "";
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                command = new SqlCommand("delete from Movies where Movie_ID='" + ID + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie deleted from database.");
                clear();
                displayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                


                command = new SqlCommand("update Movies set Movie_Title='" + txtTitle.Text + "', Movie_Release='" + txtRelease.Text + "',Movie_Genre='" + txtGenre.Text + "',Movie_Trailer='" + txtTrailer.Text + "',Movie_Image='" + txtImage.Text + "' where Movie_ID='" + ID + "'", con);
                command.ExecuteNonQuery();

                MessageBox.Show("Updated the movie");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            clear();
            displayData();
        }

        private void btnTrailer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkM);
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                command = new SqlCommand("insert into Movies (Movie_Title,Movie_Release,Movie_Genre,Movie_Trailer,Movie_Image) values ('" + txtTitle.Text + "','" + txtRelease.Text + "','" + txtGenre.Text + "','" + txtTrailer.Text + "','" + txtImage.Text + "')", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Added '" + txtTitle.Text + "' to the Movie list");
                clear();
                displayData();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            
    }
}
