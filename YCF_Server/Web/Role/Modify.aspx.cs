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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int RID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(RID);
				}
			}
		}
			
	private void ShowInfo(int RID)
	{
		YCF_Server.BLL.Role bll=new YCF_Server.BLL.Role();
		YCF_Server.Model.Role model=bll.GetModel(RID);
		this.lblRID.Text=model.RID.ToString();
		this.txtRoleName.Text=model.RoleName;
		this.txtRNumber.Text=model.RNumber;
		this.txtDID.Text=model.DID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int RID=int.Parse(this.lblRID.Text);
			string RoleName=this.txtRoleName.Text;
			string RNumber=this.txtRNumber.Text;
			int DID=int.Parse(this.txtDID.Text);


			YCF_Server.Model.Role model=new YCF_Server.Model.Role();
			model.RID=RID;
			model.RoleName=RoleName;
			model.RNumber=RNumber;
			model.DID=DID;

			YCF_Server.BLL.Role bll=new YCF_Server.BLL.Role();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
