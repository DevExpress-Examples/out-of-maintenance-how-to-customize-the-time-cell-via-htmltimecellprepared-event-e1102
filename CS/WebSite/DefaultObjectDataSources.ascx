<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultObjectDataSources.ascx.cs" Inherits="DefaultObjectDataSources" %>
<asp:ObjectDataSource ID="appointmentDataSourceObject" runat="server" DataObjectTypeName="CustomEvent" TypeName="CustomEventDataSource" DeleteMethod="DeleteMethodHandler" SelectMethod="SelectMethodHandler" InsertMethod="InsertMethodHandler" OnObjectCreated="temporaryAppointmentDataSource_ObjectCreated" UpdateMethod="UpdateMethodHandler">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="resourceDataSourceObject" runat="server" DataObjectTypeName="CustomResource" TypeName="CustomResourceDataSource" DeleteMethod="DeleteMethodHandler" SelectMethod="SelectMethodHandler" InsertMethod="InsertMethodHandler" OnObjectCreated="temporaryResourceDataSource_ObjectCreated" UpdateMethod="UpdateMethodHandler">
</asp:ObjectDataSource>