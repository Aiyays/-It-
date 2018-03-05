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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			DateTime Btime=DateTime.Parse(this.txtBtime.Text);
			int BloodPressure=int.Parse(this.txtBloodPressure.Text);
			int BloodFat=int.Parse(this.txtBloodFat.Text);
			int BlooGlucose=int.Parse(this.txtBlooGlucose.Text);
			int PID=int.Parse(this.txtPID.Text);

			YCF_Server.Model.Blood model=new YCF_Server.Model.Blood();
			model.Btime=Btime;
			model.BloodPressure=BloodPressure;
			model.BloodFat=BloodFat;
			model.BlooGlucose=BlooGlucose;
			model.PID=PID;

			YCF_Server.BLL.Blood bll=new YCF_Server.BLL.Blood();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
