using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptClearanceUsage
/// </summary>
public class rptClearanceUsage : DevExpress.XtraReports.UI.XtraReport {
    private TopMarginBand TopMargin;
    private BottomMarginBand BottomMargin;
    private DetailBand Detail;
    private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
    private XRCheckBox xrCheckBox1;
    private XRLabel xrLabel2;
    private DevExpress.XtraReports.Parameters.Parameter ClearanceID;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptClearanceUsage() {
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrCheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ClearanceID = new DevExpress.XtraReports.Parameters.Parameter();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrCheckBox1});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            // 
            // xrCheckBox1
            // 
            this.xrCheckBox1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "CheckState", "[isUsed]")});
            this.xrCheckBox1.LocationFloat = new DevExpress.Utils.PointFloat(18.75005F, 0F);
            this.xrCheckBox1.Name = "xrCheckBox1";
            this.xrCheckBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrCheckBox1.SizeF = new System.Drawing.SizeF(27.08334F, 23F);
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ReportPurpose]")});
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(45.83338F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(211.4583F, 19F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ClearanceID
            // 
            this.ClearanceID.Description = "Parameter1";
            this.ClearanceID.Name = "ClearanceID";
            this.ClearanceID.Type = typeof(int);
            this.ClearanceID.ValueInfo = "0";
            this.ClearanceID.Visible = false;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetReportPurposes";
            this.objectDataSource1.DataSource = typeof(BrgyMgmt.Web.Models.ClearanceReportPurposes);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // rptClearanceUsage
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.FilterString = "[ClearanceId] = ?ClearanceID";
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ClearanceID});
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
