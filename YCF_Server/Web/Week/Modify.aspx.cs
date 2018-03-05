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
namespace YCF_Server.Web.Week
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
		YCF_Server.BLL.Week bll=new YCF_Server.BLL.Week();
		YCF_Server.Model.Week model=bll.GetModel(WID);
		this.lblWID.Text=model.WID.ToString();
		this.txtWeek.Text=model.Week;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtWeek.Text.Trim().Length==0)
			{
				strErr+="星期不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int WID=int.Parse(this.lblWID.Text);
			string Week=this.txtWeek.Text;


			YCF_Server.Model.Week model=new YCF_Server.Model.Week();
			model.WID=WID;
			model.Week=Week;

			YCF_Server.BLL.Week bll=new YCF_Server.BLL.Week();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
