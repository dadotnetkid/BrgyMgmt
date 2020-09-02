using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptRoot
/// </summary>
public class rptInvitation1 : DevExpress.XtraReports.UI.XtraReport {
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    protected DetailBand Detail;
    protected PageHeaderBand PageHeader;
    private XRLabel xrLabel4;
    private XRPictureBox xrPictureBox4;
    private XRPictureBox xrPictureBox3;
    private XRLabel xrLabel3;
    private XRLine xrLine2;
    private XRPanel xrPanel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel5;
    private DevExpress.DataAccess.EntityFramework.EFDataSource efDataSource1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptInvitation1() {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptInvitation1));
            DevExpress.DataAccess.EntityFramework.EFConnectionParameters efConnectionParameters1 = new DevExpress.DataAccess.EntityFramework.EFConnectionParameters();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
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
            this.xrLabel5,
            this.xrPanel1});
            this.Detail.HeightF = 885F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel5
            // 
            this.xrLabel5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LetterContent]")});
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(196.875F, 40.00003F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(543.125F, 23F);
            this.xrLabel5.Text = "xrLabel5";
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
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(171.875F, 873.9583F);
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrPictureBox4,
            this.xrPictureBox3,
            this.xrLabel3,
            this.xrLine2});
            this.PageHeader.Name = "PageHeader";
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
            // rptInvitation1
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
            this.Name = "rptInvitation1";
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.efDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
