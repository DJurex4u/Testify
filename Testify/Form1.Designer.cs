namespace Testify
{
    partial class Form1
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
            this.btnRun = new System.Windows.Forms.Button();
            this.txtResponseCode = new System.Windows.Forms.TextBox();
            this.lblResponseCode = new System.Windows.Forms.Label();
            this.lblAndBody = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.txtHeaders = new System.Windows.Forms.TextBox();
            this.lblWithHeaders = new System.Windows.Forms.Label();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.lblRequestTo = new System.Windows.Forms.Label();
            this.comboHttpMethods = new System.Windows.Forms.ComboBox();
            this.lblWhenISend = new System.Windows.Forms.Label();
            this.lblTestName = new System.Windows.Forms.Label();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.chkAuthorisationSettings = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(3, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 14;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtResponseCode
            // 
            this.txtResponseCode.Location = new System.Drawing.Point(177, 537);
            this.txtResponseCode.Name = "txtResponseCode";
            this.txtResponseCode.Size = new System.Drawing.Size(100, 20);
            this.txtResponseCode.TabIndex = 27;
            // 
            // lblResponseCode
            // 
            this.lblResponseCode.AutoSize = true;
            this.lblResponseCode.Location = new System.Drawing.Point(34, 540);
            this.lblResponseCode.Name = "lblResponseCode";
            this.lblResponseCode.Size = new System.Drawing.Size(121, 13);
            this.lblResponseCode.TabIndex = 26;
            this.lblResponseCode.Text = "I verify response code is";
            // 
            // lblAndBody
            // 
            this.lblAndBody.AutoSize = true;
            this.lblAndBody.Location = new System.Drawing.Point(22, 322);
            this.lblAndBody.Name = "lblAndBody";
            this.lblAndBody.Size = new System.Drawing.Size(51, 13);
            this.lblAndBody.TabIndex = 25;
            this.lblAndBody.Text = "and body";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(34, 349);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(395, 163);
            this.txtBody.TabIndex = 24;
            // 
            // txtHeaders
            // 
            this.txtHeaders.Location = new System.Drawing.Point(36, 168);
            this.txtHeaders.Multiline = true;
            this.txtHeaders.Name = "txtHeaders";
            this.txtHeaders.Size = new System.Drawing.Size(394, 125);
            this.txtHeaders.TabIndex = 23;
            // 
            // lblWithHeaders
            // 
            this.lblWithHeaders.AutoSize = true;
            this.lblWithHeaders.Location = new System.Drawing.Point(22, 141);
            this.lblWithHeaders.Name = "lblWithHeaders";
            this.lblWithHeaders.Size = new System.Drawing.Size(67, 13);
            this.lblWithHeaders.TabIndex = 22;
            this.lblWithHeaders.Text = "with headers";
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(409, 105);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(48, 13);
            this.lblEndpoint.TabIndex = 21;
            this.lblEndpoint.Text = "endpoint";
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Location = new System.Drawing.Point(155, 102);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(248, 20);
            this.txtEndpoint.TabIndex = 20;
            // 
            // lblRequestTo
            // 
            this.lblRequestTo.AutoSize = true;
            this.lblRequestTo.Location = new System.Drawing.Point(95, 105);
            this.lblRequestTo.Name = "lblRequestTo";
            this.lblRequestTo.Size = new System.Drawing.Size(54, 13);
            this.lblRequestTo.TabIndex = 19;
            this.lblRequestTo.Text = "request to";
            // 
            // comboHttpMethods
            // 
            this.comboHttpMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHttpMethods.FormattingEnabled = true;
            this.comboHttpMethods.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.comboHttpMethods.Location = new System.Drawing.Point(20, 102);
            this.comboHttpMethods.Name = "comboHttpMethods";
            this.comboHttpMethods.Size = new System.Drawing.Size(69, 21);
            this.comboHttpMethods.TabIndex = 18;
            // 
            // lblWhenISend
            // 
            this.lblWhenISend.AutoSize = true;
            this.lblWhenISend.Location = new System.Drawing.Point(21, 86);
            this.lblWhenISend.Name = "lblWhenISend";
            this.lblWhenISend.Size = new System.Drawing.Size(68, 13);
            this.lblWhenISend.TabIndex = 17;
            this.lblWhenISend.Text = "When I send";
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(95, 23);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(45, 13);
            this.lblTestName.TabIndex = 16;
            this.lblTestName.Text = "Base url";
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(155, 20);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(248, 20);
            this.txtBaseUrl.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnRun);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnLoad);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 659);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 34);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(165, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkAuthorisationSettings
            // 
            this.chkAuthorisationSettings.AutoSize = true;
            this.chkAuthorisationSettings.Location = new System.Drawing.Point(322, 300);
            this.chkAuthorisationSettings.Name = "chkAuthorisationSettings";
            this.chkAuthorisationSettings.Size = new System.Drawing.Size(87, 17);
            this.chkAuthorisationSettings.TabIndex = 29;
            this.chkAuthorisationSettings.Text = "Authorization";
            this.chkAuthorisationSettings.UseVisualStyleBackColor = true;
            this.chkAuthorisationSettings.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(476, 693);
            this.Controls.Add(this.chkAuthorisationSettings);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtResponseCode);
            this.Controls.Add(this.lblResponseCode);
            this.Controls.Add(this.lblAndBody);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtHeaders);
            this.Controls.Add(this.lblWithHeaders);
            this.Controls.Add(this.lblEndpoint);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.lblRequestTo);
            this.Controls.Add(this.comboHttpMethods);
            this.Controls.Add(this.lblWhenISend);
            this.Controls.Add(this.lblTestName);
            this.Controls.Add(this.txtBaseUrl);
            this.Name = "Form1";
            this.Text = "Testify";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtResponseCode;
        private System.Windows.Forms.Label lblResponseCode;
        private System.Windows.Forms.Label lblAndBody;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.TextBox txtHeaders;
        private System.Windows.Forms.Label lblWithHeaders;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label lblRequestTo;
        private System.Windows.Forms.ComboBox comboHttpMethods;
        private System.Windows.Forms.Label lblWhenISend;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox chkAuthorisationSettings;
    }
}

