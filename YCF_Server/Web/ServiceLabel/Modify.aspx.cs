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
namespace YCF_Server.Web.ServiceLabel
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SLID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SLID);
				}
			}
		}
			
	private void ShowInfo(int SLID)
	{
		YCF_Server.BLL.ServiceLabel bll=new YCF_Server.BLL.ServiceLabel();
		YCF_Server.Model.ServiceLabel model=bll.GetModel(SLID);
		this.lblSLID.Text=model.SLID.ToString();
		this.txtSID.Text=model.SID.ToString();
		this.txtLID.Text=model.LID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSID.Text))
			{
				strErr+="外键-服务ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLID.Text))
			{
				strErr+="外键-服务标签格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SLID=int.Parse(this.lblSLID.Text);
			int SID=int.Parse(this.txtSID.Text);
			int LID=int.Parse(this.txtLID.Text);


			YCF_Server.Model.ServiceLabel model=new YCF_Server.Model.ServiceLabel();
			model.SLID=SLID;
			model.SID=SID;
			model.LID=LID;

			YCF_Server.BLL.ServiceLabel bll=new YCF_Server.BLL.ServiceLabel();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
