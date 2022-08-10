using System;
using System.Web.UI;

namespace SignalRChat
{
    public partial class Register : System.Web.UI.Page
    {
        ConnClass ConnC = new ConnClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_ServerClick(object sender, EventArgs e)
        {
            RegisterPassword(txtPassword.Value);
        }
        

        public void RegisterPassword(String password)
        {

            string Query = "insert into tbl_Users(UserName,Email,Password)Values('" + txtName.Value + "','" + txtEmail.Value + "','" + Hash.Hash512(password) + "')";
            string ExistQ = "select * from tbl_Users where Email='" + txtEmail.Value + "'";
            if (!ConnC.IsExist(ExistQ))
            {
                if (ConnC.ExecuteQuery(Query))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Congratulations!! You have successfully registered..');", true);

                    Session["UserName"] = txtName.Value;
                    Session["Email"] = txtEmail.Value;
                    Response.Redirect("Chat.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", "alert('Email is already Exists!! Please Try Different Email..');", true);
            }

        }

    }
}