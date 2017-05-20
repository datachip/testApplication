using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsReport
/// </summary>
public class clsReport
{
    public static void saveAsRpt()
    {
        try
        {
            passParameters();

            //save as Crystal Report Document
            DiskFileDestinationOptions DiskOpts = new DiskFileDestinationOptions();
            clsGlobal.rptDoc.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            clsGlobal.rptDoc.ExportOptions.ExportFormatType = ExportFormatType.CrystalReport;
            DiskOpts.DiskFileName = clsGlobal.webAppPath + "CrystalReport/Report.rpt";
            clsGlobal.rptDoc.ExportOptions.DestinationOptions = DiskOpts;
            clsGlobal.rptDoc.Export();

            clsDatabase.deleteDSN();
        }
        catch (Exception ex)
        {
            clsDatabase.deleteDSN();
            Console.WriteLine(ex.Message);
        }
    }

    public static void saveAsPdf()
    {
        try
        {
            passParameters();

            //Kill Adobe Reader Process if Open
            Process[] processes = Process.GetProcessesByName("AcroRd32");
            foreach (Process process in processes) { process.Kill(); }

            //save as Crystal Report Document
            DiskFileDestinationOptions DiskOpts = new DiskFileDestinationOptions();
            clsGlobal.rptDoc.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            clsGlobal.rptDoc.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            DiskOpts.DiskFileName = clsGlobal.webAppPath + "PdfReport/Report.pdf";
            clsGlobal.rptDoc.ExportOptions.DestinationOptions = DiskOpts;
            clsGlobal.rptDoc.Export();

            clsDatabase.deleteDSN();
        }
        catch (Exception ex)
        {
            clsDatabase.deleteDSN();
            Console.WriteLine(ex.Message);
        }
    }


    public static void passParameters()
    {
        try
        {

            clsDatabase.createDSN();
            clsGlobal.rptDoc.Load(clsGlobal.reportPath, OpenReportMethod.OpenReportByTempCopy);
            clsGlobal.rptDoc.Refresh();

            //Pass Parameter Values accordingly
            if (clsGlobal.reportName == ("Receipt")
                || (clsGlobal.reportName == ("Receipt Duplicate")
                || (clsGlobal.reportName == ("Receipt Triplicate"))))
            {
                if ((clsGlobal.reportPath == System.Environment.CurrentDirectory + ("/reports/rptReceiptA4.rpt"))
                    || (clsGlobal.reportPath == System.Environment.CurrentDirectory + ("/reports/rptReceiptA4Temp.rpt"))
                    || (clsGlobal.reportPath == System.Environment.CurrentDirectory + ("/reports/rptReceiptA5.rpt"))
                    || (clsGlobal.reportPath == System.Environment.CurrentDirectory + ("/reports/rptReceiptA5Temp.rpt"))
                    || (clsGlobal.reportPath == System.Environment.CurrentDirectory + ("/reports/rptReceiptDotMatrix.rpt"))
                    || (clsGlobal.reportPath == System.Environment.CurrentDirectory + ("/reports/rptReceiptDotMatrixTemp.rpt")))
                {
                    clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
                }
                else
                {
                    clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
                }
            }
            else if (clsGlobal.reportName == ("Receipt Room Booking"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Customer Receipt"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Invoice"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Invoice (Cash)"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Job Card"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocNo", clsGlobal.receiptNo);
                clsGlobal.rptDoc.SetParameterValue("Date", clsGlobal.transactionDateAndTime);
            }
            else if (clsGlobal.reportName == ("Goods Transfer Note"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Deposits Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Delivery Note"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Goods Damaged"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Goods Received Note"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Goods Returned In"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Credit Note In"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Goods Returned Out"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Purchase Order"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Sale Order"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Quotation"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Proforma Invoice"))
            {
                clsGlobal.rptDoc.SetParameterValue("DocBarCode", clsGlobal.docBarCode);
            }
            else if (clsGlobal.reportName == ("Change Entry"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionID", clsGlobal.reportTillSessionID);
                clsGlobal.rptDoc.SetParameterValue("ChangeEntryID", clsGlobal.ID);
            }
            else if (clsGlobal.reportName == ("Banking Slip"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionID", clsGlobal.reportTillSessionID);
                clsGlobal.rptDoc.SetParameterValue("BankingID", clsGlobal.bankingID);
            }
            else if (clsGlobal.reportName == ("Excess"))
            {
                clsGlobal.rptDoc.SetParameterValue("ID", clsGlobal.ID);
            }
            else if (clsGlobal.reportName == ("Pick Up"))
            {
                clsGlobal.rptDoc.SetParameterValue("ID", clsGlobal.ID);
            }
            else if (clsGlobal.reportName == ("Short"))
            {
                clsGlobal.rptDoc.SetParameterValue("ID", clsGlobal.ID);
            }
            else if (clsGlobal.reportName == ("Petty Cash Voucher"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionID", clsGlobal.reportTillSessionID);
                clsGlobal.rptDoc.SetParameterValue("ExpenditureID", clsGlobal.expenditureID);
            }
            else if (clsGlobal.reportName == ("Payment Voucher"))
            {
                clsGlobal.rptDoc.SetParameterValue("VoucherNo", clsGlobal.paymentVoucherNo);
            }
            else if (clsGlobal.reportName == ("All Insurers Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("One Insurer Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("InsurerID", clsGlobal.insurerID);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Stock Report Complete"))
            {

            }
            else if (clsGlobal.reportName == ("Stock Report by Manufacturer"))
            {
                clsGlobal.rptDoc.SetParameterValue("ManufacturerName", clsGlobal.manufacturerName);
            }
            else if (clsGlobal.reportName == ("Stock Report by Category"))
            {
                clsGlobal.rptDoc.SetParameterValue("Category", clsGlobal.productCategory);
            }
            else if (clsGlobal.reportName == ("Stock Report by Brand"))
            {
                clsGlobal.rptDoc.SetParameterValue("BrandName", clsGlobal.brandName);
            }
            else if (clsGlobal.reportName == ("Stock Report by Description"))
            {
                clsGlobal.rptDoc.SetParameterValue("Description", clsGlobal.description);
            }
            else if (clsGlobal.reportName == ("Route Service Monitor"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Restock Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Credit Notes Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Loyalty Statement"))
            {
                clsGlobal.rptDoc.SetParameterValue("LoyaltyCardNo", clsGlobal.loyaltyCardNo);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Restock Report (User)"))
            {
                clsGlobal.rptDoc.SetParameterValue("UserID", clsGlobal.userID);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Customer Statement Of Goods Transfer "))
            {
                clsGlobal.rptDoc.SetParameterValue("CustomerOrSupplierCode", clsGlobal.customerOrSupplierCode);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Customer Statement Of Goods Transfer All"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Customer Statement Of Purchases"))
            {
                clsGlobal.rptDoc.SetParameterValue("CustomerOrSupplierCode", clsGlobal.customerOrSupplierCode);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Customers Statement Of Purchases All"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Customer Statement Of Account"))
            {
                clsGlobal.rptDoc.SetParameterValue("CustomerOrSupplierCode", clsGlobal.customerOrSupplierCode);
            }
            else if (clsGlobal.reportName == ("Supplier Statement Of Account"))
            {
                clsGlobal.rptDoc.SetParameterValue("CustomerOrSupplierCode", clsGlobal.customerOrSupplierCode);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Room Occupancy"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Supplier Statement Of Account All"))
            {

            }
            else if (clsGlobal.reportName == ("Supplier Statement Of Goods Received"))
            {
                clsGlobal.rptDoc.SetParameterValue("CustomerOrSupplierCode", clsGlobal.customerOrSupplierCode);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Supplier Statement Of Goods Received All"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Statement of Goods Received"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Customers Statement General All"))
            {
                clsGlobal.rptDoc.SetParameterValue("UserNames", clsGlobal.userFirstName + " " + clsGlobal.userLastName);
            }
            else if (clsGlobal.reportName == ("Session"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionID", clsGlobal.reportTillSessionID);
            }
            else if (clsGlobal.reportName == ("X Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionID", clsGlobal.reportTillSessionID);
                clsGlobal.rptDoc.SetParameterValue("XReportNo", clsGlobal.docNo);
            }
            else if (clsGlobal.reportName == ("Session Range"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionIDStart", clsGlobal.tillSessionIDStart);
                clsGlobal.rptDoc.SetParameterValue("TillSessionIDEnd", clsGlobal.tillSessionIDEnd);

            }
            else if (clsGlobal.reportName == ("Sessions Per Day"))
            {
                clsGlobal.rptDoc.SetParameterValue("TillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("TillSessionIDStart", clsGlobal.tillSessionIDStart);
                clsGlobal.rptDoc.SetParameterValue("TillSessionIDEnd", clsGlobal.tillSessionIDEnd);

            }
            else if (clsGlobal.reportName == ("Sessions Per Day All"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);

            }
            else if (clsGlobal.reportName == ("Session Range All"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);

            }
            else if (clsGlobal.reportName == ("Sales Report Complete"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report With Customers"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report TillNo"))
            {
                clsGlobal.rptDoc.SetParameterValue("ReportTillNo", clsGlobal.reportTillNo);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report Manufacturer"))
            {
                clsGlobal.rptDoc.SetParameterValue("ReportManufacturerName", clsGlobal.reportManufacturerName);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report Group"))
            {
                clsGlobal.rptDoc.SetParameterValue("ReportCategory", clsGlobal.reportCategory);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report Brand"))
            {
                clsGlobal.rptDoc.SetParameterValue("ReportBrandName", clsGlobal.reportBrandName);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report Description"))
            {
                clsGlobal.rptDoc.SetParameterValue("Description", clsGlobal.reportDescription);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Sales Report Supplier"))
            {
                clsGlobal.rptDoc.SetParameterValue("SupplierName", clsGlobal.reportSupplierName);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Bar Code"))
            {
                clsGlobal.rptDoc.SetParameterValue("ProductCode", clsGlobal.productCode);
            }
            else if (clsGlobal.reportName == ("Lab Results"))
            {
                clsGlobal.rptDoc.SetParameterValue("CustomerOrSupplierCode", clsGlobal.customerOrSupplierCode);
                clsGlobal.rptDoc.SetParameterValue("LabRequestNo", clsGlobal.labRequestNo);
            }
            else if (clsGlobal.reportName == ("All Smart Link Insurers Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("One Smart Link Insurer Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("SmartLinkInsurerCode", clsGlobal.smartLinkInsurerCode);
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Profit And Loss Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("Previous2Month", clsGlobal.previous2EndDate);
                clsGlobal.rptDoc.SetParameterValue("Previous1Month", clsGlobal.previous1EndDate);
                clsGlobal.rptDoc.SetParameterValue("CurrentMonth", clsGlobal.currentEndDate);
            }
            else if (clsGlobal.reportName == ("Profit And Loss Report Dynamic"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Profit And Loss Account"))
            {

            }
            else if (clsGlobal.reportName == ("Expenditure Schedule All"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Stock Movement Sheet"))
            {
                //clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                //clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Trial Balance"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.currentStartDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.currentEndDate);
            }
            else if (clsGlobal.reportName == ("Balance Sheet"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == ("Rsm Report"))
            {
                clsGlobal.rptDoc.SetParameterValue("Year", clsGlobal.year);
                clsGlobal.rptDoc.SetParameterValue("Month", clsGlobal.month);
                clsGlobal.rptDoc.SetParameterValue("Description", clsGlobal.description);
            }
            else if (clsGlobal.reportName == ("Product Movement Sheet"))
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
                clsGlobal.rptDoc.SetParameterValue("ProductCode", clsGlobal.productCode);
                clsGlobal.rptDoc.SetParameterValue("Description", clsGlobal.description);
            }
            else if (clsGlobal.reportName == "VAT Summary")
            {
                clsGlobal.rptDoc.SetParameterValue("VatMonth", clsGlobal.vatMonth);
                clsGlobal.rptDoc.SetParameterValue("VatYear", clsGlobal.vatYear);
                clsGlobal.rptDoc.SetParameterValue("StartTill", clsGlobal.startTill);
                clsGlobal.rptDoc.SetParameterValue("LastTill", clsGlobal.lastTill);
            }
            else if (clsGlobal.reportName == "Petty Cash Account Statement")
            {

            }
            else if (clsGlobal.reportName == "Sales Account Statement")
            {

            }
            else if (clsGlobal.reportName == "Top Customers")
            {

            }
            else if (clsGlobal.reportName == "Open Cash Drawer")
            {

            }
            else if (clsGlobal.reportName == "Loyalty Customers List")
            {

            }
            else if (clsGlobal.reportName == "Customers List All")
            {

            }
            else if (clsGlobal.reportName == "Price List")
            {
                clsGlobal.rptDoc.SetParameterValue("Category", clsGlobal.reportCategory);
            }
            else if (clsGlobal.reportName == "Customers List")
            {
                clsGlobal.rptDoc.SetParameterValue("Category", clsGlobal.customerOrSupplierCategory);
            }
            else if (clsGlobal.reportName == "Invoices List Summarized")
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
            }
            else if (clsGlobal.reportName == "Non Cash Receipts")
            {
                clsGlobal.rptDoc.SetParameterValue("StartDate", clsGlobal.startDate);
                clsGlobal.rptDoc.SetParameterValue("EndDate", clsGlobal.endDate);
                clsGlobal.rptDoc.SetParameterValue("PaymentMode", clsGlobal.paymentMode);
            }
        }
        catch (Exception ex)
        {
            clsDatabase.deleteDSN();
            Console.WriteLine(ex.Message);
        }
    }
}