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
namespace YCF_Server.Web.UserFunctionModule
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int MID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(MID);
				}
			}
		}
			
	private void ShowInfo(int MID)
	{
		YCF_Server.BLL.UserFunctionModule bll=new YCF_Server.BLL.UserFunctionModule();
		YCF_Server.Model.UserFunctionModule model=bll.GetModel(MID);
		this.lblMID.Text=model.MID.ToString();
		this.txtF_ID.Text=model.F_ID.ToString();
		this.txtRemarks.Text=model.Remarks;
		this.txtName.Text=model.Name;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtF_ID.Text))
			{
				strErr+="父级ID格式错误！\\n";	
			}
			if(this.txtRemarks.Text.Trim().Length==0)
			{
				strErr+="功能模块名称备注(如：信息管理不能为空！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="功能模块名称（如：UserIn不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int MID=int.Parse(this.lblMID.Text);
			int F_ID=int.Parse(this.txtF_ID.Text);
			string Remarks=this.txtRemarks.Text;
			string Name=this.txtName.Text;


			YCF_Server.Model.UserFunctionModule model=new YCF_Server.Model.UserFunctionModule();
			model.MID=MID;
			model.F_ID=F_ID;
			model.Remarks=Remarks;
			model.Name=Name;

			YCF_Server.BLL.UserFunctionModule bll=new YCF_Server.BLL.UserFunctionModule();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
