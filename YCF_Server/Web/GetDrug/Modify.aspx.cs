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
namespace YCF_Server.Web.GetDrug
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(int ID)
	{
		YCF_Server.BLL.GetDrug bll=new YCF_Server.BLL.GetDrug();
		YCF_Server.Model.GetDrug model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtDID.Text=model.DID.ToString();
		this.txtGDTime.Text=model.GDTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDID.Text))
			{
				strErr+="外键-药品格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtGDTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.lblID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int DID=int.Parse(this.txtDID.Text);
			DateTime GDTime=DateTime.Parse(this.txtGDTime.Text);


			YCF_Server.Model.GetDrug model=new YCF_Server.Model.GetDrug();
			model.ID=ID;
			model.EID=EID;
			model.DID=DID;
			model.GDTime=GDTime;

			YCF_Server.BLL.GetDrug bll=new YCF_Server.BLL.GetDrug();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
