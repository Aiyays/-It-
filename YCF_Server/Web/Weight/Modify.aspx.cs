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
namespace YCF_Server.Web.Weight
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int WID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(WID);
				}
			}
		}
			
	private void ShowInfo(int WID)
	{
		YCF_Server.BLL.Weight bll=new YCF_Server.BLL.Weight();
		YCF_Server.Model.Weight model=bll.GetModel(WID);
		this.lblWID.Text=model.WID.ToString();
		this.txtWTime.Text=model.WTime.ToString();
		this.txtWeight.Text=model.Weight;
		this.txtPID.Text=model.PID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtWTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(this.txtWeight.Text.Trim().Length==0)
			{
				strErr+="体重不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int WID=int.Parse(this.lblWID.Text);
			DateTime WTime=DateTime.Parse(this.txtWTime.Text);
			string Weight=this.txtWeight.Text;
			int PID=int.Parse(this.txtPID.Text);


			YCF_Server.Model.Weight model=new YCF_Server.Model.Weight();
			model.WID=WID;
			model.WTime=WTime;
			model.Weight=Weight;
			model.PID=PID;

			YCF_Server.BLL.Weight bll=new YCF_Server.BLL.Weight();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
