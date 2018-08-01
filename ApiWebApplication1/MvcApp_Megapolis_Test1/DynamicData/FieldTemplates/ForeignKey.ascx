<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="MvcApp_Megapolis_Test1.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

