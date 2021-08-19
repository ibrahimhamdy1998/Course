using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;

namespace student
{
    
    public class dbrepo
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


    }
    public partial class WebForm1 : System.Web.UI.Page
    { 
       protected void Page_Load(object sender, EventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            dbrepo hhhh = new dbrepo();
            
            //fill special

           /* if (!IsPostBack)
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
    }
}