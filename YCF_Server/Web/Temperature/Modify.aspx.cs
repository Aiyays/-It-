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
namespace YCF_Server.Web.Temperature
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
		YCF_Server.BLL.Temperature bll=new YCF_Server.BLL.Temperature();
		YCF_Server.Model.Temperature model=bll.GetModel(TID);
		this.lblTID.Text=model.TID.ToString();
		this.txtMeasureDateTime.Text=model.MeasureDateTime.ToString();
		this.txtTemperature.Text=model.Temperature;
		this.txtPID.Text=model.PID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtMeasureDateTime.Text))
			{
				strErr+="测量时间格式错误！\\n";	
			}
			if(this.txtTemperature.Text.Trim().Length==0)
			{
				strErr+="温度不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人表格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int TID=int.Parse(this.lblTID.Text);
			DateTime MeasureDateTime=DateTime.Parse(this.txtMeasureDateTime.Text);
			string Temperature=this.txtTemperature.Text;
			int PID=int.Parse(this.txtPID.Text);


			YCF_Server.Model.Temperature model=new YCF_Server.Model.Temperature();
			model.TID=TID;
			model.MeasureDateTime=MeasureDateTime;
			model.Temperature=Temperature;
			model.PID=PID;

			YCF_Server.BLL.Temperature bll=new YCF_Server.BLL.Temperature();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
