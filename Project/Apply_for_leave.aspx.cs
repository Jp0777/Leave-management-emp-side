using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Project
{
    public partial class Apply_for_leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CompareValidator1.ValueToCompare = DateTime.Now.ToString("dd/MM/yyyy");

            if (Session["user"]==null)
            {

               
                    Response.Write("Expired");
                    Response.Redirect("login.aspx");
                
            }
          
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }

                string leaveid = Guid.NewGuid().ToString("N");
                string id = Session["user"].ToString();
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                SqlCommand cmd = new SqlCommand("select count(*) from EmpLeave where '"+From.Text+"' between  from_date and to_date or '"+ To.Text+"' between from_date and to_date and id='" + id + "'", con);
                con.Open();
                int exist=(Int32)cmd.ExecuteScalar();

                if (exist > 0)
                {
                    Label6.Text = "You have already applied for this dates,You may choose other dates,plz see in your leave history";
                    Label6.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    cmd.CommandText = "insert into EmpLeave values(@id,@from,@to,@desc,@type,@status,@leaveid)";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@from", From.Text);
                    cmd.Parameters.AddWithValue("@to", To.Text);
                    cmd.Parameters.AddWithValue("@desc", desc.Text);
                    cmd.Parameters.AddWithValue("@status", "Pending For Approval");
                    cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@leaveid", leaveid);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Label6.Text = ex.Message;
                        Label6.ForeColor = System.Drawing.Color.Red;
                        return;
                    }


                    DropDownList1.SelectedValue = "";
                    From.Text = "";
                    To.Text = "";
                    desc.Text = "";
                    Label6.Text = "Applied Succesfully,plz see in your leave history";
                    Label6.ForeColor = System.Drawing.Color.Green;
                      
                  }
                   }
                }
            }

        }

       
    
