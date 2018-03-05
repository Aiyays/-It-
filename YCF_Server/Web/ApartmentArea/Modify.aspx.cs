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
namespace YCF_Server.Web.ApartmentArea
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int AID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(AID);
				}
			}
		}
			
	private void ShowInfo(int AID)
	{
		YCF_Server.BLL.ApartmentArea bll=new YCF_Server.BLL.ApartmentArea();
		YCF_Server.Model.ApartmentArea model=bll.GetModel(AID);
		this.lblAID.Text=model.AID.ToString();
		this.txtApartmentArea.Text=model.ApartmentArea;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtApartmentArea.Text.Trim().Length==0)
			{
				strErr+="房间区域不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int AID=int.Parse(this.lblAID.Text);
			string ApartmentArea=this.txtApartmentArea.Text;


			YCF_Server.Model.ApartmentArea model=new YCF_Server.Model.ApartmentArea();
			model.AID=AID;
			model.ApartmentArea=ApartmentArea;

			YCF_Server.BLL.ApartmentArea bll=new YCF_Server.BLL.ApartmentArea();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
