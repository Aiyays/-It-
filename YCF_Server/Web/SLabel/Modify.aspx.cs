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
namespace YCF_Server.Web.SLabel
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int LID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(LID);
				}
			}
		}
			
	private void ShowInfo(int LID)
	{
		YCF_Server.BLL.SLabel bll=new YCF_Server.BLL.SLabel();
		YCF_Server.Model.SLabel model=bll.GetModel(LID);
		this.lblLID.Text=model.LID.ToString();
		this.txtLabel.Text=model.Label;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtLabel.Text.Trim().Length==0)
			{
				strErr+="服务标签不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int LID=int.Parse(this.lblLID.Text);
			string Label=this.txtLabel.Text;


			YCF_Server.Model.SLabel model=new YCF_Server.Model.SLabel();
			model.LID=LID;
			model.Label=Label;

			YCF_Server.BLL.SLabel bll=new YCF_Server.BLL.SLabel();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
