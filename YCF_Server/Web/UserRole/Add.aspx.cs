using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace YCF_Server.Web.UserRole
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUID.Text))
			{
				strErr+="机构用户ID-外键格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRID.Text))
			{
				strErr+="角色ID-外键格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UID=int.Parse(this.txtUID.Text);
			int RID=int.Parse(this.txtRID.Text);

			YCF_Server.Model.UserRole model=new YCF_Server.Model.UserRole();
			model.UID=UID;
			model.RID=RID;

			YCF_Server.BLL.UserRole bll=new YCF_Server.BLL.UserRole();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
