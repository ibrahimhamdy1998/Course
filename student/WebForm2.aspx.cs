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
                FillCity();
            
            }
        }
        private void FillCity()
        {
            int id = 0;
            // Call DB
            //Select Id,Name from Specialization
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "select ID,Town_NAme from Town where ID > @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@id", id);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ListItem item = new ListItem();
                        item.Value = dataReader["ID"].ToString();
                        item.Text = dataReader["Town_NAme"].ToString();
                        Filter.Items.Add(item);

                    }
                    sqlConnection.Close();
                }
            }


        }
        
        private void data()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
           SqlConnection sqlConnection = new SqlConnection(connectionString);
         
            SqlCommand cmd = new SqlCommand("SELECT Student.ID,Fname,Lname,Age,Email,Is_accepted,Accpetance,Comments, Specialization,Gender,Town_NAme from Student  INNER JOIN Specialization ON Student.SPECIALIZATION_ID = Specialization.SPECIALIZATION_ID INNER JOIN Gender ON Student.GENDER_ID = Gender.GENDER_ID INNER JOIN TOWN ON Student.CityId = Town.ID", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            sda.Fill(ds);
            
            Student_ID.DataSource = ds;
            Student_ID.DataBind();
                

            
            }




    }

}

