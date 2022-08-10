using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignalRChat
{
    public partial class delete : System.Web.UI.Page
    {
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            bindGrid();
            if (!IsPostBack)
            {
                fetchid();
               
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
           

        }

        public void fetchid()
        {
            SqlConnection sql = new SqlConnection(cs);
            string qry = "select count(id)+1 from tbl_users";
            sql.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TextBox1.Text = dt.Rows[0][0].ToString();




        }

        public void bindGrid()
        {

            SqlConnection sql = new SqlConnection(cs);
            string qry = "select * from tbl_users";
            sql.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            sql.Open();
            int id = Convert.ToInt32(GridView1.Rows[rowindex].Cells[1].Text);
            SqlCommand cmd = new SqlCommand("delete from tbl_users where id = '" + TextBox1.Text + "'",sql);
            cmd.ExecuteNonQuery();
            Response.Write("Deleted");
            sql.Close();
        }
    }
}