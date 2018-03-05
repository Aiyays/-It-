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
namespace YCF_Server.Web.Respiratory
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtRtime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBreathe.Text))
			{
				strErr+="呼吸格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtHeartRate.Text))
			{
				strErr+="心率格式错误！\\n";	
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
			DateTime Rtime=DateTime.Parse(this.txtRtime.Text);
			int Breathe=int.Parse(this.txtBreathe.Text);
			int HeartRate=int.Parse(this.txtHeartRate.Text);
			int PID=int.Parse(this.txtPID.Text);

			YCF_Server.Model.Respiratory model=new YCF_Server.Model.Respiratory();
			model.Rtime=Rtime;
			model.Breathe=Breathe;
			model.HeartRate=HeartRate;
			model.PID=PID;

			YCF_Server.BLL.Respiratory bll=new YCF_Server.BLL.Respiratory();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
