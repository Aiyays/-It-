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
namespace YCF_Server.Web.DrugType
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
		YCF_Server.BLL.DrugType bll=new YCF_Server.BLL.DrugType();
		YCF_Server.Model.DrugType model=bll.GetModel(TID);
		this.lblTID.Text=model.TID.ToString();
		this.txtDrugType.Text=model.DrugType;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtDrugType.Text.Trim().Length==0)
			{
				strErr+="药品类型不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int TID=int.Parse(this.lblTID.Text);
			string DrugType=this.txtDrugType.Text;


			YCF_Server.Model.DrugType model=new YCF_Server.Model.DrugType();
			model.TID=TID;
			model.DrugType=DrugType;

			YCF_Server.BLL.DrugType bll=new YCF_Server.BLL.DrugType();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
