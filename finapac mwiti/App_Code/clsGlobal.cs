using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsGlobal
/// </summary>
public class clsGlobal
{
    public static ReportDocument rptDoc = new ReportDocument();
    public static string webAppPath = "";
    public static string reportPath = "";
    public static string reportName = "";
    public static string docBarCode;
    public static int receiptNo;
    public static string transactionDateAndTime;
    public static string startDate;
    public static string endDate;
    public static int reportTillNo;
    public static int reportTillSessionID;
    public static int bankingID;
    public static int expenditureID;
    public static string paymentVoucherNo;
    public static int insurerID;
    public static string manufacturerName;
    public static string productCategory;
    public static string brandName;
    public static string description;
    public static int loyaltyCardNo;
    public static int userID;
    public static string customerOrSupplierCode;
    public static string userFirstName;
    public static string userLastName;
    public static int docNo;
    public static int tillSessionIDStart;
    public static int tillSessionIDEnd;
    public static string reportManufacturerName;
    public static string reportCategory;
    public static string reportDescription;
    public static string reportBrandName;
    public static string reportSupplierName;
    public static string productCode;
    public static int labRequestNo;
    public static string smartLinkInsurerCode;
    public static string previous2EndDate;
    public static string previous1EndDate;
    public static string currentEndDate;
    public static string currentStartDate;
    public static string year;
    public static string month;
    public static string vatMonth;
    public static int startTill;
    public static int vatYear;
    public static int lastTill;
    public static string customerOrSupplierCategory;
    public static string paymentMode;
    public static int ID;
}