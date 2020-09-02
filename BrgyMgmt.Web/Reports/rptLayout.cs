using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptRoot
/// </summary>
public class rptLayout : DevExpress.XtraReports.UI.XtraReport {
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    protected DetailBand Detail;
    protected PageHeaderBand PageHeader;
    private XRLabel xrLabel4;
    private XRPictureBox xrPictureBox4;
    private XRPictureBox xrPictureBox3;
    private XRLabel xrLabel3;
    private XRLine xrLine2;
    private XRPageBreak xrPageBreak1;
    private XRLabel xrLabel5;
    private DevExpress.DataAccess.EntityFramework.EFDataSource efDataSource1;
    private XRPanel xrPanel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLine xrLine1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptLayout() {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptLayout));
            DevExpress.DataAccess.EntityFramework.EFConnectionParameters efConnectionParameters1 = new DevExpress.DataAccess.EntityFramework.EFConnectionParameters();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox4 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.efDataSource1 = new DevExpress.DataAccess.EntityFramework.EFDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 20F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 20F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel13,
            this.xrLine1,
            this.xrLabel12,
            this.xrLabel7,
            this.xrLabel6,
            this.xrPageBreak1,
            this.xrLabel5});
            this.Detail.HeightF = 930.2086F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 665.8333F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(90.62498F, 19F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "Respondent/s:";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 696.0416F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(65F, 90F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "______ 1) \r\n______ 2) \r\n______ 3) \r\n\r\n______ 4)";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 911.2086F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(252.0833F, 19F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Barangay Copy";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 892.2086F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(252.0833F, 19F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "_______________  Date/Time ___________";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 847.2498F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(252.0833F, 19F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "(Signature over printed name)";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 828.2498F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(252.0833F, 19F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Received by Respondents or / Reprsentative/s";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(561.4583F, 828.2498F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(150F, 19F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "OFFICER";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Concat(\'I served this letter upon respondent \', [Complaint].[ResidentRespondents]" +
                    ".[FullName],\' on the ____ day of __________, to be settled on [SettlementDate].\'" +
                    ")")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(220F, 615.4166F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(510F, 38F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(538.7499F, 826.2498F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(187.5F, 2F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(283.7501F, 696.0416F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(445F, 90.00006F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = resources.GetString("xrLabel12.Text");
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(218.7501F, 571.5833F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(510.0001F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "OFFICERS RETURN";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LetterContent]")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(220F, 499.9166F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(510F, 23.00002F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel5";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 351.0417F);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LetterContent]")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(220F, 150F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(510F, 23.00002F);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1,
            this.xrLabel4,
            this.xrPictureBox4,
            this.xrPictureBox3,
            this.xrLabel3,
            this.xrLine2});
            this.PageHeader.HeightF = 995F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.PrintAcrossBands = true;
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.OrangeRed;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(5F, 125F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(170F, 870F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(5.000003F, 30.00002F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(155F, 829.7916F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = resources.GetString("xrLabel2.Text");
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(5F, 5F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(60F, 16F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.Text = "VISION";
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(251.25F, 75.00002F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(260F, 23F);
            this.xrLabel4.Text = " OFFICE OF THE PUNONG BARANGAY\r\n";
            // 
            // xrPictureBox4
            // 
            this.xrPictureBox4.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox4.ImageSource"));
            this.xrPictureBox4.LocationFloat = new DevExpress.Utils.PointFloat(538.75F, 0F);
            this.xrPictureBox4.Name = "xrPictureBox4";
            this.xrPictureBox4.SizeF = new System.Drawing.SizeF(80F, 90F);
            this.xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox3
            // 
            this.xrPictureBox3.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox3.ImageSource"));
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(126.25F, 0F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(80F, 90F);
            this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(263.75F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(230F, 70F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "REPUBLIC OF THE PHILIPPINES\r\nProvince of Nueva Vizcaya\r\nMunicipality of Quezon\r\nB" +
    "ARANGAY RUNRUNO\r\n3713";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.OrangeRed;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(50F, 98F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(650F, 2F);
            this.xrLine2.StylePriority.UseForeColor = false;
            // 
            // efDataSource1
            // 
            efConnectionParameters1.ConnectionString = "";
            efConnectionParameters1.ConnectionStringName = "BrgyMgmtEntities";
            efConnectionParameters1.Source = typeof(BrgyMgmt.Web.Models.BrgyMgmtEntities);
            this.efDataSource1.ConnectionParameters = efConnectionParameters1;
            this.efDataSource1.Name = "efDataSource1";
            // 
            // rptLayout
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.efDataSource1});
            this.DataMember = "Settlements";
            this.DataSource = this.efDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 20, 20);
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
