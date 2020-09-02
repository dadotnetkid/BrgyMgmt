using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptClearance
/// </summary>
public class rptClearance : DevExpress.XtraReports.UI.XtraReport {
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DetailBand Detail;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private PageHeaderBand PageHeader;
    private XRLine xrLine2;
    private XRLabel xrLabel3;
    private XRPictureBox xrPictureBox3;
    private XRPictureBox xrPictureBox4;
    private XRLabel xrLabel4;
    private XRPanel xrPanel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRSubreport xrSubreport1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRBarCode xrBarCode1;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel32;
    private XRLabel xrLabel31;
    private XRLabel xrLabel30;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRShape xrShape1;
    private XRLabel xrLabel19;
    private XRLine xrLine1;
    private XRLabel xrLabel18;
    private XRLabel xrLabel33;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel35;
    private XRLabel xrLabel34;
    private XRLabel xrLabel40;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel36;
    private XRLabel xrLabel42;
    private XRLabel xrLabel41;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptClearance() {
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
            DevExpress.XtraPrinting.Shape.ShapeRectangle shapeRectangle1 = new DevExpress.XtraPrinting.Shape.ShapeRectangle();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptClearance));
            DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo objectConstructorInfo1 = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrShape1 = new DevExpress.XtraReports.UI.XRShape();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox4 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
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
            this.xrLabel42,
            this.xrLabel41,
            this.xrLabel40,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLabel36,
            this.xrLabel35,
            this.xrLabel34,
            this.xrPictureBox1,
            this.xrLabel33,
            this.xrLabel32,
            this.xrLabel31,
            this.xrLabel30,
            this.xrLabel28,
            this.xrLabel29,
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrShape1,
            this.xrLabel19,
            this.xrLine1,
            this.xrLabel18,
            this.xrLabel6,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrBarCode1,
            this.xrLabel14,
            this.xrLabel13,
            this.xrSubreport1,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel5,
            this.xrPanel1});
            this.Detail.HeightF = 883.9583F;
            this.Detail.Name = "Detail";
            // 
            // xrLabel42
            // 
            this.xrLabel42.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(317.9167F, 170.0416F);
            this.xrLabel42.Multiline = true;
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(161.4583F, 21F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.StylePriority.UseTextAlignment = false;
            this.xrLabel42.Text = "years up to the present.";
            this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel41
            // 
            this.xrLabel41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[YearsOfStay]")});
            this.xrLabel41.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 170.0416F);
            this.xrLabel41.Multiline = true;
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(20F, 21F);
            this.xrLabel41.StylePriority.UseFont = false;
            this.xrLabel41.StylePriority.UseTextAlignment = false;
            this.xrLabel41.Text = "xrLabel41";
            this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel40
            // 
            this.xrLabel40.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IssuedDate]")});
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic);
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 382.125F);
            this.xrLabel40.Multiline = true;
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel40.StylePriority.UseFont = false;
            this.xrLabel40.StylePriority.UseTextAlignment = false;
            this.xrLabel40.Text = "xrLabel35";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel40.TextFormatString = "{0:MMMM dd, yyy}";
            // 
            // xrLabel37
            // 
            this.xrLabel37.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ORNumber]")});
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(271.8751F, 713.6252F);
            this.xrLabel37.Multiline = true;
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.StylePriority.UseTextAlignment = false;
            this.xrLabel37.Text = "xrLabel34";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel38
            // 
            this.xrLabel38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IssuedDate]")});
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(271.8751F, 734.6252F);
            this.xrLabel38.Multiline = true;
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.StylePriority.UseTextAlignment = false;
            this.xrLabel38.Text = "xrLabel35";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel38.TextFormatString = "{0:d}";
            // 
            // xrLabel39
            // 
            this.xrLabel39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Comelec]")});
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(271.8751F, 755.6253F);
            this.xrLabel39.Multiline = true;
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.StylePriority.UseTextAlignment = false;
            this.xrLabel39.Text = "xrLabel36";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel36
            // 
            this.xrLabel36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CTCPlaceIssued]")});
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(271.8751F, 692.6252F);
            this.xrLabel36.Multiline = true;
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.StylePriority.UseTextAlignment = false;
            this.xrLabel36.Text = "xrLabel36";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel35
            // 
            this.xrLabel35.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CTCDate]")});
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(271.8751F, 671.6251F);
            this.xrLabel35.Multiline = true;
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.StylePriority.UseTextAlignment = false;
            this.xrLabel35.Text = "xrLabel35";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrLabel35.TextFormatString = "{0:d}";
            // 
            // xrLabel34
            // 
            this.xrLabel34.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CTC]")});
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(271.8751F, 650.6251F);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.StylePriority.UseTextAlignment = false;
            this.xrLabel34.Text = "xrLabel34";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.BorderColor = System.Drawing.Color.DarkOrange;
            this.xrPictureBox1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPictureBox1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "ImageSource", "[Photo]")});
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(608.7499F, 84.0416F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 5, 5, 100F);
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(130F, 130F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrPictureBox1.StylePriority.UseBorderColor = false;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            this.xrPictureBox1.StylePriority.UsePadding = false;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 6F);
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(220.4167F, 608.9582F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(100F, 21.00003F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "RIGHT THUMB MARK";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 808.1666F);
            this.xrLabel32.Multiline = true;
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(552.0833F, 21F);
            this.xrLabel32.StylePriority.UseFont = false;
            this.xrLabel32.StylePriority.UseTextAlignment = false;
            this.xrLabel32.Text = "Note: valid for six (6) months from the Date Of Issue. Alterations / erasures inv" +
    "alidates this clearance.";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 755.6252F);
            this.xrLabel31.Multiline = true;
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(83.95837F, 21F);
            this.xrLabel31.StylePriority.UseFont = false;
            this.xrLabel31.StylePriority.UseTextAlignment = false;
            this.xrLabel31.Text = "Comelec Reg.:";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 734.6252F);
            this.xrLabel30.Multiline = true;
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(83.95837F, 20.99994F);
            this.xrLabel30.StylePriority.UseFont = false;
            this.xrLabel30.StylePriority.UseTextAlignment = false;
            this.xrLabel30.Text = "Date Issued:";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 692.6252F);
            this.xrLabel28.Multiline = true;
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(83.95837F, 21F);
            this.xrLabel28.StylePriority.UseFont = false;
            this.xrLabel28.StylePriority.UseTextAlignment = false;
            this.xrLabel28.Text = "Issued At:";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 713.6252F);
            this.xrLabel29.Multiline = true;
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(83.95837F, 21F);
            this.xrLabel29.StylePriority.UseFont = false;
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.Text = "OR No.";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel27
            // 
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 671.6252F);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(83.95837F, 21F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "Date Issue:";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 650.6252F);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(83.95837F, 21F);
            this.xrLabel26.StylePriority.UseFont = false;
            this.xrLabel26.StylePriority.UseTextAlignment = false;
            this.xrLabel26.Text = "CTC NO.";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(591.0417F, 587.9583F);
            this.xrLabel23.Multiline = true;
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(148.9583F, 21.00006F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "Apporved By:";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(591.0417F, 650.6251F);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(148.9583F, 21.00006F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.StylePriority.UseTextAlignment = false;
            this.xrLabel24.Text = "JOHN M. BABLI-ING";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(591.0418F, 671.6251F);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(148.9583F, 21.00006F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "PUNONG BARANGAY";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(591.0418F, 510.5835F);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(148.9583F, 21.00006F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "SECRETARY";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(591.0417F, 489.5835F);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(148.9583F, 21.00006F);
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "VERONICA C. BANIH";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(591.0417F, 426.9166F);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(148.9583F, 21.00003F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Verified By:";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrShape1
            // 
            this.xrShape1.LocationFloat = new DevExpress.Utils.PointFloat(220.4167F, 508.9584F);
            this.xrShape1.Name = "xrShape1";
            this.xrShape1.Shape = shapeRectangle1;
            this.xrShape1.SizeF = new System.Drawing.SizeF(100F, 100F);
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(220.4167F, 467.2916F);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(100F, 21.00003F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.StylePriority.UseTextAlignment = false;
            this.xrLabel19.Text = "(SIGNATURE)";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(186.875F, 465.2915F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(175F, 2F);
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(187.9167F, 382.125F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(110F, 21.00003F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Given on this day, ";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.DarkOrange;
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ResidentName]")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(321.875F, 51.37494F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(296.875F, 25F);
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 249.9999F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "PURPOSE:";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 217.5416F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(552.0833F, 21.00002F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "According to records kept in this office, the subject has no pending cases.";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 170.0416F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.Text = "YEARS OF STAY:";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrBarCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClearanceId]")});
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(591.0416F, 731.8336F);
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(148.9583F, 44.79169F);
            this.xrBarCode1.Symbology = code128Generator1;
            // 
            // xrLabel14
            // 
            this.xrLabel14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Address]")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 149.0416F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(296.875F, 21.00002F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "xrLabel8";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 149.0416F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "ADDRESS:";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 249.9999F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ParameterBindings.Add(new DevExpress.XtraReports.UI.ParameterBinding("ClearanceID", null, "ClearanceId"));
            this.xrSubreport1.ReportSource = new rptClearanceUsage();
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(442.0833F, 108.4167F);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 128.0416F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "CIVIL STATUS:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 107.0416F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "GENDER:";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 86.04158F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(100F, 21F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "AGE:";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Gender]")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 107.0416F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(152.0833F, 21F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CivilStatus]")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 128.0416F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(152.0833F, 21.00002F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Age]")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(297.9167F, 86.04158F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(152.0833F, 21F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(197.9167F, 14.99999F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(552.0833F, 23.54168F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "BARANGAY CLEARANCE";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.xrLine2,
            this.xrLabel3,
            this.xrPictureBox3,
            this.xrPictureBox4,
            this.xrLabel4});
            this.PageHeader.HeightF = 113.3333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.OrangeRed;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(50F, 98F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(650F, 2F);
            this.xrLine2.StylePriority.UseForeColor = false;
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
            // xrPictureBox3
            // 
            this.xrPictureBox3.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox3.ImageSource"));
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(126.25F, 0F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(80F, 90F);
            this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox4
            // 
            this.xrPictureBox4.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox4.ImageSource"));
            this.xrPictureBox4.LocationFloat = new DevExpress.Utils.PointFloat(538.75F, 0F);
            this.xrPictureBox4.Name = "xrPictureBox4";
            this.xrPictureBox4.SizeF = new System.Drawing.SizeF(80F, 90F);
            this.xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
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
            // objectDataSource1
            // 
            this.objectDataSource1.Constructor = objectConstructorInfo1;
            this.objectDataSource1.DataSource = typeof(BrgyMgmt.Web.Models.ClearanceReport);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // rptClearance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 20, 20);
            this.Version = "20.1";
            this.Watermark.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("rptClearance.Watermark.ImageSource"));
            this.Watermark.ImageTiling = true;
            this.Watermark.ImageTransparency = 220;
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
