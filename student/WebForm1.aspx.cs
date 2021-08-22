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
            if (!IsPostBack)
            {
                FillCity();
                FillSpecialization();

            }






            /*     string conn = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

                 dbrepo hhhh = new dbrepo();

                 //fill special

                 if (!IsPostBack)
                 {
                     fname.Text = "Ali";

                 }*/

        }

        //private void FFILLDB()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        string commandText = "INSERT INTO Student(Fname,Lname,Age,Email) values(@Fname,@Lname,@Age,Email)";
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = sqlConnection;
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = commandText;
        //        cmd.Parameters.AddWithValue("@Fname",ID_FIRST_NAME.Text );
        //        cmd.Parameters.AddWithValue("@Lname", ID_LAST_NAME.Text);
        //        cmd.Parameters.AddWithValue("@Age",int.Parse(ID_AGE.Text));
        //        cmd.Parameters.AddWithValue("@Email", ID_EMAIL.Text);
        //        if (sqlConnection.State == System.Data.ConnectionState.Closed)
        //            sqlConnection.Open();

        //        using (SqlDataReader dataReader = cmd.ExecuteReader())
        //        {

        //            while (dataReader.Read())
        //            {
        //                ListItem item = new ListItem();
        //                item.Value = dataReader["SPECIALIZATION_ID"].ToString();
        //                item.Text = dataReader["Specialization"].ToString();

        //                ID_SPECIALIZATION.Items.Add(item);
        //            }
        //            sqlConnection.Close();
        //        }
        //    } //close coneection auto


        //}
        private void FillSpecialization()
        {

            ID_SPECIALIZATION.Items.Add(new ListItem
            {
                Value = "0",
                Text = "please select",
                Selected = true

            });
            int id = 0;
            // Call DB
            //Select Id,Name from Specialization
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "select SPECIALIZATION_ID,Specialization from Specialization where SPECIALIZATION_ID > @id";
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
                        item.Value = dataReader["SPECIALIZATION_ID"].ToString();
                        item.Text = dataReader["Specialization"].ToString();

                        ID_SPECIALIZATION.Items.Add(item);
                    }
                    sqlConnection.Close();
                }
            } //close coneection auto


        }

        private void FillCity()
        {
            int id = 0;
            // Call DB
            //Select Id,Name from Specialization
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "select ID,Name from City where ID > @id";
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
                        item.Text = dataReader["Name"].ToString();
                        ID_CITY.Items.Add(item);

                    }
                    sqlConnection.Close();
                }
            }


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

        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        public void insert()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "INSERT INTO Student (Fname,Lname,Age,Email,Comments) VALUES(@Fname,@Lname,@Age,@Email,@Comments);";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = commandText;
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                cmd.Parameters.Add("Fname", System.Data.SqlDbType.VarChar, 200).Value = ID_FIRST_NAME.Text;
                cmd.ExecuteNonQuery();
                sqlConnection.Close();




            }
        }


        private void insertstudent()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            var insertstatment = "INSERT into Student (Fname,Lname,Age,Email,Comments,SPECIALIZATION_ID) values (@Fname,@Lname,@Age,@Email,@Comments,@SPECIALIZATION_ID)";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(insertstatment, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Fname", ID_FIRST_NAME.Text);
                    sqlCommand.Parameters.AddWithValue("@Lname", ID_LAST_NAME.Text);
                    sqlCommand.Parameters.AddWithValue("@Age", int.Parse(ID_AGE.Text));
                    sqlCommand.Parameters.AddWithValue("@Email", ID_EMAIL.Text);
                    sqlCommand.Parameters.AddWithValue("@Comments", ID_COMMENTS.InnerText);
                    sqlCommand.Parameters.AddWithValue("@SPECIALIZATION_ID", ID_SPECIALIZATION.SelectedValue);
                    sqlCommand.ExecuteNonQuery();

                }
            }
        }

        private void insertcity()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            var insertstatment = "INSERT into City (Name) values (@Name)";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(insertstatment, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", ID_CITY.SelectedValue);
                    sqlCommand.ExecuteNonQuery();

                }
            }
        }
        private void insertspecilization()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            var insertstatment = "INSERT into Specialization (Specialization) values (@Specialization)";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(insertstatment, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Specialization", ID_SPECIALIZATION.SelectedValue);
                    sqlCommand.ExecuteNonQuery();

                }
            }
        }
        private void insertgender()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            var insertstatment = "INSERT into Gender (Gender) values (@Gender)";
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(insertstatment, sqlConnection))
                {
                    if (ID_MALE.Checked)
                    {
                        sqlCommand.Parameters.AddWithValue("@Gender", ID_MALE.Checked);

                    }
                    if (ID_FEMALE.Checked)
                    {
                        sqlCommand.Parameters.AddWithValue("@Gender", ID_FEMALE.Checked);

                    }
                    sqlCommand.ExecuteNonQuery();

                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            insertstudent();
            //insertspecilization();
            //insertcity();
            //insertgender();
        }
    }
}