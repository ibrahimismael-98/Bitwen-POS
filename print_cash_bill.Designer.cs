
namespace Bitwen_Company
{
    partial class print_cash_bill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(print_cash_bill));
            this.cash_crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.drag_panel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.EXIT = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.DragControl = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.drag_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cash_crystalReportViewer
            // 
            this.cash_crystalReportViewer.ActiveViewIndex = -1;
            this.cash_crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cash_crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.cash_crystalReportViewer.Location = new System.Drawing.Point(0, 40);
            this.cash_crystalReportViewer.Name = "cash_crystalReportViewer";
            this.cash_crystalReportViewer.Size = new System.Drawing.Size(1207, 928);
            this.cash_crystalReportViewer.TabIndex = 0;
            this.cash_crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // drag_panel
            // 
            this.drag_panel.BackColor = System.Drawing.Color.Transparent;
            this.drag_panel.BorderRadius = 50;
            this.drag_panel.Controls.Add(this.label1);
            this.drag_panel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(253)))));
            this.drag_panel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(55)))));
            this.drag_panel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(253)))));
            this.drag_panel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(55)))));
            this.drag_panel.Location = new System.Drawing.Point(-78, -40);
            this.drag_panel.Name = "drag_panel";
            this.drag_panel.ShadowDecoration.Parent = this.drag_panel;
            this.drag_panel.Size = new System.Drawing.Size(1250, 80);
            this.drag_panel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arabic Typesetting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(445, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "پسوولە";
            // 
            // EXIT
            // 
            this.EXIT.BorderThickness = 1;
            this.EXIT.CheckedState.Parent = this.EXIT;
            this.EXIT.CustomImages.Parent = this.EXIT;
            this.EXIT.FillColor = System.Drawing.Color.Red;
            this.EXIT.FillColor2 = System.Drawing.Color.Red;
            this.EXIT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EXIT.ForeColor = System.Drawing.Color.White;
            this.EXIT.HoverState.BorderColor = System.Drawing.Color.Maroon;
            this.EXIT.HoverState.CustomBorderColor = System.Drawing.Color.Maroon;
            this.EXIT.HoverState.Parent = this.EXIT;
            this.EXIT.Location = new System.Drawing.Point(1178, 10);
            this.EXIT.Name = "EXIT";
            this.EXIT.ShadowDecoration.BorderRadius = 20;
            this.EXIT.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.EXIT.ShadowDecoration.Parent = this.EXIT;
            this.EXIT.Size = new System.Drawing.Size(20, 20);
            this.EXIT.TabIndex = 4;
            this.EXIT.Tag = "";
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.drag_panel;
            // 
            // print_cash_bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 970);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.drag_panel);
            this.Controls.Add(this.cash_crystalReportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "print_cash_bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ڕاکێشانی پسوولە";
            this.TopMost = true;
            this.drag_panel.ResumeLayout(false);
            this.drag_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cash_crystalReportViewer;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel drag_panel;
        private Guna.UI2.WinForms.Guna2GradientCircleButton EXIT;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaDragControl DragControl;
    }
}