<%@ Page Title="AssessRecord" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="YCF_Server.Web.AssessRecord.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="AID" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="UName" HeaderText="姓名" SortExpression="UName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="FN" HeaderText="档案号" SortExpression="FN" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BirthDate" HeaderText="生日" SortExpression="BirthDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="TheBed" HeaderText="病床号" SortExpression="TheBed" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ValuationDate" HeaderText="评估日期" SortExpression="ValuationDate" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Evaluator" HeaderText="评估员" SortExpression="Evaluator" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Registrar" HeaderText="登记员" SortExpression="Registrar" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="RecordData" HeaderText="登记日期" SortExpression="RecordData" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="BADL" HeaderText="BADL指数" SortExpression="BADL" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LADL" HeaderText="LADL指数" SortExpression="LADL" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="LSP" HeaderText="LSP指数" SortExpression="LSP" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="SysEvaluation" HeaderText="系统评估" SortExpression="SysEvaluation" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Assessment" HeaderText="综合评估（评估人员进行评估）" SortExpression="Assessment" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="UID" HeaderText="用户ID（被评估人员ID）-外" SortExpression="UID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Comment" HeaderText="护理等级分配备注" SortExpression="Comment" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="AID" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="AID" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
