using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace student
{
    
   /* public class dbrepo
    {
        DbProviderFactory factory;
        string provider;
        string connectionString;
        public dbrepo()
        {
            provider = ConfigurationManager.AppSettings["provider"];
            connectionString = ConfigurationManager.AppSettings["myConnectionString"];
            factory = DbProviderFactories.GetFactory(provider);
        }

        public List<course> GetAll()
        {
            var courses = new List<course>();
            using(var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select * From Student";
                using(DbDataReader reader = command.ExecuteReader())
                {
                    //go
                    while (reader.Read())
                    {
                        courses.Add(new course{
                            ID = (int) reader ["ID"],
                            Lname = (string)reader["Lname"],
                            Fname = (string)reader["Fname"]

                        });
                    }
                
                }
return courses;
            }
        } 
    }
    public class course
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }


    }*/
    public partial class WebForm1 : System.Web.UI.Page
    { 
       protected void Page_Load(object sender, EventArgs e)
        {
       /*     string conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            dbrepo hhhh = new dbrepo();
            
            //fill special

            if (!IsPostBack)
            {
                fname.Text = "Ali";

            }*/
            
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            ID_AGE.Text = "";
            ID_FIRST_NAME.Text = "";
            ID_LAST_NAME.Text = "";
            ID_EMAIL.Text = "";
            ID_SPECIALIZATION.SelectedValue = "0";
            ID_MALE.Checked = false;
            ID_FEMALE.Checked = false;
            ID_COMMENTS.InnerText = "";            
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if(ID_MALE.Checked || ID_FEMALE.Checked)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            var insertStatment = "INSERT into Specialization (Specialization) values(@Specialization)";
            var insertStatment_S = "INSERT into Student (Fname,Lname,Age,Email,Comments) values(@Fname,@Lname,@Age,@Email,@Comments)";
            //var insertStatment_Gender = "INSERT into Gender (Gender) values(@Gender)";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(insertStatment,sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("Specialization", ID_SPECIALIZATION.SelectedValue);
                    sqlCommand.ExecuteNonQuery();
                }
               using (var connect = new SqlCommand(insertStatment_S, sqlConnection))
                {
                    connect.Parameters.AddWithValue("Student", ID_FIRST_NAME.Text);        
                    connect.Parameters.AddWithValue("Student",ID_LAST_NAME.Text);
                    connect.Parameters.AddWithValue("Student", ID_AGE.Text);
                    connect.Parameters.AddWithValue("Student", ID_EMAIL.Text);
                    connect.Parameters.AddWithValue("Student", ID_COMMENTS.InnerText);
                    connect.ExecuteNonQuery();
                }
               

            }
        }
    }
}