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
namespace YCF_Server.Web.Schedule
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSCID.Text))
			{
				strErr+="外键（班次）格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtWID.Text))
			{
				strErr+="（外键）时间周格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SCID=int.Parse(this.txtSCID.Text);
			int WID=int.Parse(this.txtWID.Text);

			YCF_Server.Model.Schedule model=new YCF_Server.Model.Schedule();
			model.SCID=SCID;
			model.WID=WID;

			YCF_Server.BLL.Schedule bll=new YCF_Server.BLL.Schedule();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
