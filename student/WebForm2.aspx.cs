using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
namespace student
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private object dataGridView;

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
            data();
                dataS();
            
            }
        }

        private void data()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
           SqlConnection sqlConnection = new SqlConnection(connectionString);
         
            SqlCommand cmd = new SqlCommand("select * from Student", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            sda.Fill(ds);
            
            Student_ID.DataSource = ds;
            Student_ID.DataBind();
                

            
            }
        private void dataS()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select Specialization From Specialization INNER JOIN Student ON Specialization.SPECIALIZATION_ID=Student.SPECIALIZATION_ID", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sda.Fill(ds);

            ss.DataSource = ds;
            ss.DataBind();



        }
        private void dataG()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Student", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sda.Fill(ds);

            Student_ID.DataSource = ds;
            Student_ID.DataBind();



        }
        private void dataC()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Student", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sda.Fill(ds);

            Student_ID.DataSource = ds;
            Student_ID.DataBind();



        }




    }

}

