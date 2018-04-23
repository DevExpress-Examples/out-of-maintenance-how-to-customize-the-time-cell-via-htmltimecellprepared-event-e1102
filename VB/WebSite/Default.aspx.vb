Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing
#Region "#1"
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxClasses.Internal
Imports DevExpress.XtraScheduler
                                                        
#End Region

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		DataHelper.SetupMappings(ASPxScheduler1)
		DataHelper.ProvideRowInsertion(ASPxScheduler1, DataSource1.AppointmentDataSource)
		DataSource1.AttachTo(ASPxScheduler1)
	End Sub

#Region "#2"
	Protected Sub OnHtmlTimeCellPrepared(ByVal sender As Object, ByVal e As ASPxSchedulerTimeCellPreparedEventArgs)
		Dim cellInterval As TimeInterval = e.Interval
		If e.View.Type = DevExpress.XtraScheduler.SchedulerViewType.Day Then
			Dim dinnerStart As New TimeSpan(15, 0, 0)
			Dim dinnerEnd As New TimeSpan(17, 0, 0)
			Dim cellStart As TimeSpan = cellInterval.Start.TimeOfDay
			Dim cellEnd As TimeSpan = cellInterval.End.TimeOfDay
			If cellStart >= dinnerStart AndAlso cellStart <= dinnerEnd AndAlso cellEnd <= dinnerEnd Then
				e.Cell.BackColor = Color.Red
				Dim valueString As String = HtmlConvertor.ToHtml(Color.Yellow)
				e.Cell.Style.Add("border-bottom-color", valueString)
				e.Cell.Style.Add("text-align", "center")
				e.Cell.Controls.Add(New LiteralControl("dinner"))
			End If
		End If
		If e.View.Type = SchedulerViewType.Week Then
			Dim specialDate As New DateTime(2008, 7, 24)
			If cellInterval.Start = specialDate Then
				e.Cell.BackColor = Color.Green
			End If
		End If
	End Sub
#End Region
End Class
