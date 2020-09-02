using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptSummon
/// </summary>
public class rptSummon : rptRoot {
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRPageInfo xrPageInfo1;
    private XRLabel xrLabel5;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel16;
    private XRLine xrLine1;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptSummon() {
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
            DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo objectConstructorInfo1 = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLine1,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel6,
            this.xrPageInfo1});
            this.Detail.Controls.SetChildIndex(this.xrPageInfo1, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel6, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel7, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel9, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel8, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel11, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel10, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel13, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel12, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel15, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel14, 0);
            this.Detail.Controls.SetChildIndex(this.xrLine1, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel16, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel17, 0);
            this.Detail.Controls.SetChildIndex(this.xrLabel18, 0);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5});
            this.PageHeader.Controls.SetChildIndex(this.xrLabel5, 0);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(251.25F, 127F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(260F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "SUMMON\r\n";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(295F, 21.00002F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrPageInfo1.TextFormatString = "{0:MMMM d, yyyy}";
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(195F, 40.00003F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Title:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Title]")});
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(295F, 40.00003F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(341.0417F, 19F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(195.0001F, 59.00002F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Case Number:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[BlotterId]")});
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(295F, 59.00002F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(341.0417F, 19F);
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.Constructor = objectConstructorInfo1;
            this.objectDataSource1.DataSource = typeof(BrgyMgmt.Web.Models.SummonReport);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // xrLabel10
            // 
            this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Complainants]")});
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(295F, 90.50002F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(444.9998F, 19.00001F);
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(195.0001F, 90.50001F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Complainants:";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(195.0002F, 109.5F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Respondents:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Respondents]")});
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(295.0001F, 109.5F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(444.9998F, 19.00001F);
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(195.0001F, 128.5F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Victims:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Victims]")});
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(295F, 128.5F);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(444.9999F, 19F);
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(195.0003F, 163.2917F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(544.9998F, 23F);
            // 
            // xrLabel16
            // 
            this.xrLabel16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LetterContent]")});
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(195.0003F, 201.8334F);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(544.9996F, 23F);
            this.xrLabel16.Text = "xrLabel16";
            // 
            // xrLabel17
            // 
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(195.0003F, 21.00002F);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "Date:";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PresidingStaff]")});
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(195F, 265.375F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // rptSummon
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
