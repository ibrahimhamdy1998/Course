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

    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //   FillSpecialization();
                FillCity();
                FillSpecialization();
            }
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
                        ID_CITY.Items.Add(item);

                    }
                    sqlConnection.Close();
                }
            }


        }
        private void FillSpecialization()
        {
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

        /*private void FillSpecialization()
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
                          item.Value = dataReader["ID"].ToString();
                          item.Text = dataReader["Town_NAme"].ToString();

                          ID_CITY.Items.Add(item);
                      }
                      sqlConnection.Close();
                  }
              } //close coneection auto


          }
          */
        private void Filltown()
        {
            int id = 0;
            // Call DB
            //Select Id,Name from Specialization
            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string commandText = "select ID,Town_NAme from City where ID > @id";
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
                        ID_CITY.Items.Add(item);

                    }
                    sqlConnection.Close();
                }
            }

        }

        private void cancel()
        {
            ID_AGE.Text = "";
            ID_FIRST_NAME.Text = "";
            ID_LAST_NAME.Text = "";
            ID_EMAIL.Text = "";
            ID_MALE.Checked = false;
            ID_FEMALE.Checked = false;
            ID_COMMENTS.InnerText = "";
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void insertstudent()
        {
            try
            {
                DateTime today = DateTime.Now;
                var connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                var insertstatment = "INSERT into Student (Fname,Lname,Age,Email,Comments,Accpetance,Is_accepted,SPECIALIZATION_ID,GENDER_ID,CityId)" +
                                                 " values (@Fname,@Lname,@Age,@Email,@Comments,@Accpetance,@Is_accepted,@SPECIALIZATION_ID,@GENDER_ID,@CityId)";
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
                        sqlCommand.Parameters.AddWithValue("@Accpetance", DateTime.Now);

                        sqlCommand.Parameters.AddWithValue("@SPECIALIZATION_ID", ID_SPECIALIZATION.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@CityId", ID_CITY.SelectedValue);
                        if (ID_MALE.Checked)
                        {
                            sqlCommand.Parameters.AddWithValue("@GENDER_ID", 1);
                        }
                        if (ID_FEMALE.Checked)
                        {
                            sqlCommand.Parameters.AddWithValue("@GENDER_ID", 2);
                        }
                        sqlCommand.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        protected void Register_Click(object sender, EventArgs e)
        {

            try
            {
                insertstudent();
                cancel();
            }
            catch
            {
          //      ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your data dosent inserted')", true);
            }

        }
    
        //private void FillCity()
        //{
        //    int id = 0;
        //    // Call DB
        //    //Select Id,Name from Specialization
        //    string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();

        //    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    {
        //        string commandText = "select ID,Name from City where ID > @id";
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = sqlConnection;
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.CommandText = commandText;
        //        cmd.Parameters.AddWithValue("@id", id);

        //        if (sqlConnection.State == System.Data.ConnectionState.Closed)
        //            sqlConnection.Open();

        //        using (SqlDataReader dataReader = cmd.ExecuteReader())
        //        {
        //            while (dataReader.Read())
        //            {
        //                ListItem item = new ListItem();
        //                item.Value = dataReader["ID"].ToString();
        //                item.Text = dataReader["Name"].ToString();
        //                ID_CITY.Items.Add(item);

        //            }
        //            sqlConnection.Close();
        //        }
        //}


        //}


    }
}