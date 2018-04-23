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
using System.Drawing;
#region #1
using DevExpress.Web.ASPxScheduler;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.XtraScheduler;
#endregion #1

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
        DataHelper.SetupMappings(ASPxScheduler1);
        DataHelper.ProvideRowInsertion(ASPxScheduler1, DataSource1.AppointmentDataSource);
        DataSource1.AttachTo(ASPxScheduler1);
    }

#region #2
    protected void OnHtmlTimeCellPrepared(object sender, ASPxSchedulerTimeCellPreparedEventArgs e) {
        TimeInterval cellInterval = e.Interval;
        if (e.View.Type == DevExpress.XtraScheduler.SchedulerViewType.Day) {
            TimeSpan dinnerStart = new TimeSpan(15, 0, 0);
            TimeSpan dinnerEnd = new TimeSpan(17, 0, 0);
            TimeSpan cellStart = cellInterval.Start.TimeOfDay;
            TimeSpan cellEnd = cellInterval.End.TimeOfDay;
            if (cellStart >= dinnerStart && cellStart <= dinnerEnd && cellEnd <= dinnerEnd) {
                e.Cell.BackColor = Color.Red;
                string valueString = HtmlConvertor.ToHtml(Color.Yellow);
                e.Cell.Style.Add("border-bottom-color", valueString);
                e.Cell.Style.Add("text-align", "center");
                e.Cell.Controls.Add(new LiteralControl("dinner"));
            }
        }
        if (e.View.Type == SchedulerViewType.Week) {
            DateTime specialDate = new DateTime(2008, 7, 24);
            if (cellInterval.Start == specialDate) 
                e.Cell.BackColor = Color.Green;
        }
    }
#endregion #2
}
