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

            if (Session["user"] == null)
            {


                Response.Write("Expired");
                Response.Redirect("login.aspx");


            }
            string id = Session["user"].ToString();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select leftLeaves from EmpInfo where id='" + id + "'", con);
                con.Open();
                string leftleaves=cmd.ExecuteScalar().ToString();
                TextBoxLL.Text = leftleaves;

            }
            }

        protected void Button1_Click(object sender, EventArgs e)
        {

   
            int daysOfLeave = (DateTime.Parse(To.Text).Date - DateTime.Parse(From.Text).Date).Days + 1;


            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }

            string leaveid = Guid.NewGuid().ToString("N");
            string id = Session["user"].ToString();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from EmpLeave where id='" + id + "' and ('" + From.Text + "' between  from_date and to_date or '" + To.Text + "' between from_date and to_date) and ( stat='Pending For Approval' or stat='Approved' )", con);
                con.Open();
                int exist = Convert.ToInt32(cmd.ExecuteScalar());

                if (exist > 0)
                {
                    Label6.Text = "You have already applied for this dates,You may choose other dates,plz see in your leave history";
                    Label6.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                else
                {
                    cmd.CommandText = "select leftLeaves from EmpInfo where id='" + id + "'";
                    int leftLeaves = Convert.ToInt32(cmd.ExecuteScalar());
                    if (daysOfLeave > leftLeaves)
                    {
                        Label6.Text = "You have only " + leftLeaves + " leaves left , You can not apply leave for " + daysOfLeave + " days ";
                        Label6.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        cmd.CommandText = "insert into EmpLeave values(@id,@from,@to,@desc,@type,@status,@leaveid,@daysOfLeave)";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@from", From.Text);
                        cmd.Parameters.AddWithValue("@to", To.Text);
                        cmd.Parameters.AddWithValue("@desc", desc.Text);
                        cmd.Parameters.AddWithValue("@status", "Pending For Approval");
                        cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedValue);
                        cmd.Parameters.AddWithValue("@leaveid", leaveid);
                        cmd.Parameters.AddWithValue("@daysOfLeave", daysOfLeave);
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

                        cmd.CommandText = "Update EmpInfo set leftLeaves=leftLeaves-'" + daysOfLeave + "' where id='" + id + "'";
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
                        cmd.CommandText = "select leftLeaves from EmpInfo where id='" + id + "'";
                        string leftleaves = cmd.ExecuteScalar().ToString();
                        TextBoxLL.Text = leftleaves;
                        Label6.Text = "Applied Succesfully,plz see in your leave history";
                        Label6.ForeColor = System.Drawing.Color.Green;

                    }
                }
            }
        }
    }

        }

       
    
