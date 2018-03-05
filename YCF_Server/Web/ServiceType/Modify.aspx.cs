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
namespace YCF_Server.Web.ServiceType
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int TID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(TID);
				}
			}
		}
			
	private void ShowInfo(int TID)
	{
		YCF_Server.BLL.ServiceType bll=new YCF_Server.BLL.ServiceType();
		YCF_Server.Model.ServiceType model=bll.GetModel(TID);
		this.lblTID.Text=model.TID.ToString();
		this.txtType.Text=model.Type;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtType.Text.Trim().Length==0)
			{
				strErr+="服务类型不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int TID=int.Parse(this.lblTID.Text);
			string Type=this.txtType.Text;


			YCF_Server.Model.ServiceType model=new YCF_Server.Model.ServiceType();
			model.TID=TID;
			model.Type=Type;

			YCF_Server.BLL.ServiceType bll=new YCF_Server.BLL.ServiceType();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
