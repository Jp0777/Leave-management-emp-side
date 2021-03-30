using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LeaveMangaement
{
    public partial class Approved_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = GetData();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        public DataSet GetData()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select uname,email, from_date,to_date,type_of_leave,stat,descrip,leaveId from EmpInfo, EmpLeave  where EmpInfo.id=EmpLeave.id and stat='Approved' ", con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }
     
        protected void approveLeave_changeStatus(string leaveIdApprove)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE EmpLeave SET stat='Approved' where leaveId='" + leaveIdApprove + "'", con);
                cmd.ExecuteNonQuery();
            }
        }
        protected void denyLeave_changeStatus(string leaveIdDeny)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE EmpLeave SET stat='Denied' where leaveId='" + leaveIdDeny + "'", con);
                cmd.ExecuteNonQuery();
            }
        }
        protected void action_Approve_Deny_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "approveLeave":
                    string leaveIdApprove = btn.CommandArgument.ToString();
                    approveLeave_changeStatus(leaveIdApprove);
                    Response.Redirect("leaves-list-admin.aspx");
                    break;
                case "denyLeave":
                    string leaveIdDeny = btn.CommandArgument.ToString();
                    denyLeave_changeStatus(leaveIdDeny);
                    Response.Redirect("leaves-list-admin.aspx");
                    break;
            }
        }
    }
}