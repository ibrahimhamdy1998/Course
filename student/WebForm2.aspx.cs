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
                FillGrid();
                FillCity();
                FillSpecialization();
                BindGrid();
            }
          
        }
        private void FillCity()
        {
            int id = 0;

            Filter.Items.Add(new ListItem { Value = "0", Text = "All", Selected = true });

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

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Student.ID,Fname,Lname,Age,Email,Is_accepted,Accpetance,Comments, Specialization,Gender,Town_NAme from Student INNER JOIN Specialization ON Student.SPECIALIZATION_ID = Specialization.SPECIALIZATION_ID INNER JOIN Gender ON Student.GENDER_ID = Gender.GENDER_ID INNER JOIN TOWN ON Student.CityId = Town.ID", con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Student_ID.DataSource = dt;
                        Student_ID.DataBind();
                    }
                }
            }

            //Required for jQuery DataTables to work.
            Student_ID.UseAccessibleHeader = true;
            Student_ID.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        private void FillGrid()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            String commandtext = "SELECT Student.ID,Fname,Lname,Age,Email,Is_accepted,Accpetance,Comments, Specialization,Gender,Town_NAme from Student INNER JOIN Specialization ON Student.SPECIALIZATION_ID = Specialization.SPECIALIZATION_ID INNER JOIN Gender ON Student.GENDER_ID = Gender.GENDER_ID INNER JOIN TOWN ON Student.CityId = Town.ID";

            if ((Filter.SelectedValue != "" && Filter.SelectedValue != "0") && (Filters.SelectedValue != "" && Filters.SelectedValue != "0"))
            {
                commandtext += " Where Student.CityId = " + Filter.SelectedValue + " And Student.SPECIALIZATION_ID = " + Filters.SelectedValue;
            }
            else if (Filter.SelectedValue != "" && Filter.SelectedValue != "0")
            {

                commandtext += " where Student.CityId = " + Filter.SelectedValue;

            }
            else if (Filters.SelectedValue != "" && Filters.SelectedValue != "0")
            {

                commandtext += " where Student.SPECIALIZATION_ID = " + Filters.SelectedValue;

            }



            #region Other If
            //var andWord = "";

            //if ((Filter.SelectedValue != "" && Filter.SelectedValue != "0") || (Filters.SelectedValue != "" && Filters.SelectedValue != "0"))
            //{
            //    commandtext += " Where ";
            //}

            //if (Filter.SelectedValue != "" && Filter.SelectedValue != "0")
            //{

            //    commandtext += " Student.CityId = " + Filter.SelectedValue;
            //    andWord = " and ";

            //}

            //if (Filters.SelectedValue != "" && Filters.SelectedValue != "0")
            //{

            //    commandtext += andWord + " Student.SPECIALIZATION_ID = " + Filters.SelectedValue;

            //}
            #endregion


            //if (Filter.SelectedValue != "" && Filter.SelectedValue != "0")
            //{
            //    commandtext += " where Student.CityId =" + Filter.SelectedValue;

            //}



            SqlCommand cmd = new SqlCommand(commandtext, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            sda.Fill(ds);

            Student_ID.DataSource = ds;
            Student_ID.DataBind();



        }


        private void FillSpecialization()
        {
            int id = 0;
            Filters.Items.Add(new ListItem { Value = "0", Text = "All", Selected = true });

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
                        Filters.Items.Add(item);
                    }
                    sqlConnection.Close();
                }
            } //close coneection auto


        }

        protected void Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void Filters_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void Student_ID_DataBound(object sender, EventArgs e)
        {

     
        }
    }

}

