<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="YCF_Server.Web.Drug.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		DID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		药品名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDrugName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		药品级别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDlevel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		生产日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblManufactureDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		有效日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblValidTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		价格
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		规格
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSpecification" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		来源
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDrugSource" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		入库时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		存储温度
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStoragetempera" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		厂家
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblManufacturers" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		品牌
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBrand" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图片
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDrugIMG" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		外键-药品类型
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTID" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




