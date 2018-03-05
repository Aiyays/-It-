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
namespace YCF_Server.Web.Blood
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int BID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(BID);
				}
			}
		}
			
	private void ShowInfo(int BID)
	{
		YCF_Server.BLL.Blood bll=new YCF_Server.BLL.Blood();
		YCF_Server.Model.Blood model=bll.GetModel(BID);
		this.lblBID.Text=model.BID.ToString();
		this.txtBtime.Text=model.Btime.ToString();
		this.txtBloodPressure.Text=model.BloodPressure.ToString();
		this.txtBloodFat.Text=model.BloodFat.ToString();
		this.txtBlooGlucose.Text=model.BlooGlucose.ToString();
		this.txtPID.Text=model.PID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtBtime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBloodPressure.Text))
			{
				strErr+="血压格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBloodFat.Text))
			{
				strErr+="血脂格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBlooGlucose.Text))
			{
				strErr+="血糖格式错误！\\n";	
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
			int BID=int.Parse(this.lblBID.Text);
			DateTime Btime=DateTime.Parse(this.txtBtime.Text);
			int BloodPressure=int.Parse(this.txtBloodPressure.Text);
			int BloodFat=int.Parse(this.txtBloodFat.Text);
			int BlooGlucose=int.Parse(this.txtBlooGlucose.Text);
			int PID=int.Parse(this.txtPID.Text);


			YCF_Server.Model.Blood model=new YCF_Server.Model.Blood();
			model.BID=BID;
			model.Btime=Btime;
			model.BloodPressure=BloodPressure;
			model.BloodFat=BloodFat;
			model.BlooGlucose=BlooGlucose;
			model.PID=PID;

			YCF_Server.BLL.Blood bll=new YCF_Server.BLL.Blood();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
