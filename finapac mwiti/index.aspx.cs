using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsGlobal.webAppPath = Server.MapPath("/");
        if (!IsPostBack)
        {
            //clsReport.saveAsRpt();
            //displayCrystalReport();

            updateReportPath();
            clsReport.saveAsPdf();
            displayPdfThroPath();
        }
    }

    private void updateReportPath()
    {
        clsGlobal.reportName = "Sales Report Group";
        clsGlobal.reportPath = clsGlobal.webAppPath + "Reports/rptSalesReportCategory.rpt";

        clsGlobal.reportCategory = "SHIRTS";
        clsGlobal.startDate = "2016-01-06 00:00:00";
        clsGlobal.endDate = "2016-02-10 23:59:59";
    }

    private void displayCrystalReport()
    {
        clsGlobal.rptDoc.Load(Server.MapPath("CrystalReport/report.rpt"));
        //CrystalReportViewer1.ReportSource = clsGlobal.xtalrptdcmt;
        //CrystalReportViewer1.DataBind();
    }

    public string displayPdfThroPath()
    {
        return Page.ResolveClientUrl("PdfReport/Report.pdf");
    }
}