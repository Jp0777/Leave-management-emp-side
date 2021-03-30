using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace LeaveMangaement
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            CompareValidator1.ValueToCompare = DateTime.Now.ToString("dd/MM/yyyy");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                string id = Session["uid"].ToString();
                string leaveId = Guid.NewGuid().ToString("N");
                string email = Session["email"].ToString();
                string CS = ConfigurationManager.ConnectionStrings["login"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into applyForLeave values(@uid,@from_date,@to_date,@description,@type_of_leave,@status,@email,@leaveId)", con);
                    con.Open();
                    
                    cmd.Parameters.AddWithValue("@uid", id);
                    cmd.Parameters.AddWithValue("@from_date", From.Text);
                    cmd.Parameters.AddWithValue("@to_date", To.Text);
                    cmd.Parameters.AddWithValue("@description", desc.Text);
                    cmd.Parameters.AddWithValue("@type_of_leave", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@status","pending");
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@leaveId", leaveId);
                    cmd.ExecuteNonQuery();


                    DropDownList1.Text = "";
                    From.Text = "";
                    To.Text = "";
                    desc.Text = "";
                    Response.Write("Applied For Leave Successfully");
                }
            }
        }
    }
   


       
}
