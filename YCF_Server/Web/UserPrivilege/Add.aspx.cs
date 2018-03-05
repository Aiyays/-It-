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
namespace YCF_Server.Web.UserPrivilege
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtURID.Text))
			{
				strErr+="机构用户角色关系表ID-外键格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMID.Text))
			{
				strErr+="功能模块ID-外键格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int URID=int.Parse(this.txtURID.Text);
			int MID=int.Parse(this.txtMID.Text);

			YCF_Server.Model.UserPrivilege model=new YCF_Server.Model.UserPrivilege();
			model.URID=URID;
			model.MID=MID;

			YCF_Server.BLL.UserPrivilege bll=new YCF_Server.BLL.UserPrivilege();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
