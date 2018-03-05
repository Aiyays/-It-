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
namespace YCF_Server.Web.PrivateGoods
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PID);
				}
			}
		}
			
	private void ShowInfo(int PID)
	{
		YCF_Server.BLL.PrivateGoods bll=new YCF_Server.BLL.PrivateGoods();
		YCF_Server.Model.PrivateGoods model=bll.GetModel(PID);
		this.lblPID.Text=model.PID.ToString();
		this.txtName.Text=model.Name;
		this.txtNumber.Text=model.Number;
		this.txtCount.Text=model.Count.ToString();
		this.txtParID.Text=model.ParID.ToString();
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="名称不能为空！\\n";	
			}
			if(this.txtNumber.Text.Trim().Length==0)
			{
				strErr+="编号不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCount.Text))
			{
				strErr+="数量格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtParID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PID=int.Parse(this.lblPID.Text);
			string Name=this.txtName.Text;
			string Number=this.txtNumber.Text;
			int Count=int.Parse(this.txtCount.Text);
			int ParID=int.Parse(this.txtParID.Text);
			string Remark=this.txtRemark.Text;


			YCF_Server.Model.PrivateGoods model=new YCF_Server.Model.PrivateGoods();
			model.PID=PID;
			model.Name=Name;
			model.Number=Number;
			model.Count=Count;
			model.ParID=ParID;
			model.Remark=Remark;

			YCF_Server.BLL.PrivateGoods bll=new YCF_Server.BLL.PrivateGoods();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
