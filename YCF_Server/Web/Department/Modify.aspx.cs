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
namespace YCF_Server.Web.Department
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int DID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(DID);
				}
			}
		}
			
	private void ShowInfo(int DID)
	{
		YCF_Server.BLL.Department bll=new YCF_Server.BLL.Department();
		YCF_Server.Model.Department model=bll.GetModel(DID);
		this.lblDID.Text=model.DID.ToString();
		this.txtEdepartmentName.Text=model.EdepartmentName;
		this.txtDNumber.Text=model.DNumber;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtEdepartmentName.Text.Trim().Length==0)
			{
				strErr+="部门名称不能为空！\\n";	
			}
			if(this.txtDNumber.Text.Trim().Length==0)
			{
				strErr+="部门编号不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int DID=int.Parse(this.lblDID.Text);
			string EdepartmentName=this.txtEdepartmentName.Text;
			string DNumber=this.txtDNumber.Text;


			YCF_Server.Model.Department model=new YCF_Server.Model.Department();
			model.DID=DID;
			model.EdepartmentName=EdepartmentName;
			model.DNumber=DNumber;

			YCF_Server.BLL.Department bll=new YCF_Server.BLL.Department();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
