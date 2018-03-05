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
namespace YCF_Server.Web.Role
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtRoleName.Text.Trim().Length==0)
			{
				strErr+="角色不能为空！\\n";	
			}
			if(this.txtRNumber.Text.Trim().Length==0)
			{
				strErr+="角色编号不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDID.Text))
			{
				strErr+="部门ID-外键格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string RoleName=this.txtRoleName.Text;
			string RNumber=this.txtRNumber.Text;
			int DID=int.Parse(this.txtDID.Text);

			YCF_Server.Model.Role model=new YCF_Server.Model.Role();
			model.RoleName=RoleName;
			model.RNumber=RNumber;
			model.DID=DID;

			YCF_Server.BLL.Role bll=new YCF_Server.BLL.Role();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
