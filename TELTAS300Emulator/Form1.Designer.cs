namespace TELTAS300Emulator
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLoadPort = new System.Windows.Forms.Label();
            this.cmbLoadPort = new System.Windows.Forms.ComboBox();
            this.lblErrorType = new System.Windows.Forms.Label();
            this.cmbErrorType = new System.Windows.Forms.ComboBox();
            this.grpInterLockType = new System.Windows.Forms.GroupBox();
            this.rbtnAfter = new System.Windows.Forms.RadioButton();
            this.rbtnBefore = new System.Windows.Forms.RadioButton();
            this.lblBeforeInterlock = new System.Windows.Forms.Label();
            this.cmbBeforeInterLock = new System.Windows.Forms.ComboBox();
            this.lblAfterInterlock = new System.Windows.Forms.Label();
            this.cmbAfterInterLock = new System.Windows.Forms.ComboBox();
            this.lblNAKErrorType = new System.Windows.Forms.Label();
            this.cmbNAKErrorType = new System.Windows.Forms.ComboBox();
            this.lblNakWarning = new System.Windows.Forms.Label();
            this.cmbNAKWarning = new System.Windows.Forms.ComboBox();
            this.btnUpdateLoadPort = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.grpCarrier = new System.Windows.Forms.GroupBox();
            this.rbtnCarrierRemoved = new System.Windows.Forms.RadioButton();
            this.rbtnCarrierPlaced = new System.Windows.Forms.RadioButton();
            this.grpWaferProtrusion = new System.Windows.Forms.GroupBox();
            this.rbtnWaferProtrusionInterference = new System.Windows.Forms.RadioButton();
            this.rbtnWaferProtrusionOK = new System.Windows.Forms.RadioButton();
            this.lblSlot = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSlots = new System.Windows.Forms.ComboBox();
            this.lblSlotStatus = new System.Windows.Forms.Label();
            this.cmbSlotStatus = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpInterLockType.SuspendLayout();
            this.grpCarrier.SuspendLayout();
            this.grpWaferProtrusion.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblLoadPort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblErrorType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbErrorType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpInterLockType, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblBeforeInterlock, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbBeforeInterLock, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblAfterInterlock, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbAfterInterLock, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblNAKErrorType, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbNAKErrorType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNakWarning, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbNAKWarning, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateLoadPort, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnClearAll, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.grpCarrier, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpWaferProtrusion, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbLoadPort, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 311);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLoadPort
            // 
            this.lblLoadPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLoadPort.AutoSize = true;
            this.lblLoadPort.Location = new System.Drawing.Point(45, 7);
            this.lblLoadPort.Name = "lblLoadPort";
            this.lblLoadPort.Size = new System.Drawing.Size(62, 13);
            this.lblLoadPort.TabIndex = 0;
            this.lblLoadPort.Text = "Load Port : ";
            // 
            // cmbLoadPort
            // 
            this.cmbLoadPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLoadPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoadPort.FormattingEnabled = true;
            this.cmbLoadPort.Location = new System.Drawing.Point(113, 3);
            this.cmbLoadPort.Name = "cmbLoadPort";
            this.cmbLoadPort.Size = new System.Drawing.Size(121, 21);
            this.cmbLoadPort.TabIndex = 1;
            // 
            // lblErrorType
            // 
            this.lblErrorType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblErrorType.AutoSize = true;
            this.lblErrorType.Location = new System.Drawing.Point(42, 38);
            this.lblErrorType.Name = "lblErrorType";
            this.lblErrorType.Size = new System.Drawing.Size(65, 13);
            this.lblErrorType.TabIndex = 0;
            this.lblErrorType.Text = "Error Type : ";
            // 
            // cmbErrorType
            // 
            this.cmbErrorType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbErrorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbErrorType.FormattingEnabled = true;
            this.cmbErrorType.Location = new System.Drawing.Point(113, 34);
            this.cmbErrorType.Name = "cmbErrorType";
            this.cmbErrorType.Size = new System.Drawing.Size(121, 21);
            this.cmbErrorType.TabIndex = 1;
            // 
            // grpInterLockType
            // 
            this.grpInterLockType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grpInterLockType.AutoSize = true;
            this.grpInterLockType.Controls.Add(this.rbtnAfter);
            this.grpInterLockType.Controls.Add(this.rbtnBefore);
            this.grpInterLockType.Location = new System.Drawing.Point(113, 127);
            this.grpInterLockType.Name = "grpInterLockType";
            this.grpInterLockType.Size = new System.Drawing.Size(122, 56);
            this.grpInterLockType.TabIndex = 2;
            this.grpInterLockType.TabStop = false;
            this.grpInterLockType.Text = "Interlock Type";
            // 
            // rbtnAfter
            // 
            this.rbtnAfter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnAfter.AutoSize = true;
            this.rbtnAfter.Location = new System.Drawing.Point(69, 20);
            this.rbtnAfter.Name = "rbtnAfter";
            this.rbtnAfter.Size = new System.Drawing.Size(47, 17);
            this.rbtnAfter.TabIndex = 0;
            this.rbtnAfter.Text = "After";
            this.rbtnAfter.UseVisualStyleBackColor = true;
            // 
            // rbtnBefore
            // 
            this.rbtnBefore.AutoSize = true;
            this.rbtnBefore.Checked = true;
            this.rbtnBefore.Location = new System.Drawing.Point(7, 20);
            this.rbtnBefore.Name = "rbtnBefore";
            this.rbtnBefore.Size = new System.Drawing.Size(56, 17);
            this.rbtnBefore.TabIndex = 0;
            this.rbtnBefore.TabStop = true;
            this.rbtnBefore.Text = "Before";
            this.rbtnBefore.UseVisualStyleBackColor = true;
            // 
            // lblBeforeInterlock
            // 
            this.lblBeforeInterlock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBeforeInterlock.AutoSize = true;
            this.lblBeforeInterlock.Location = new System.Drawing.Point(16, 193);
            this.lblBeforeInterlock.Name = "lblBeforeInterlock";
            this.lblBeforeInterlock.Size = new System.Drawing.Size(91, 13);
            this.lblBeforeInterlock.TabIndex = 0;
            this.lblBeforeInterlock.Text = "Before Interlock : ";
            // 
            // cmbBeforeInterLock
            // 
            this.cmbBeforeInterLock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbBeforeInterLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBeforeInterLock.FormattingEnabled = true;
            this.cmbBeforeInterLock.Items.AddRange(new object[] {
            "NAK Error",
            "Interlock Error"});
            this.cmbBeforeInterLock.Location = new System.Drawing.Point(113, 189);
            this.cmbBeforeInterLock.Name = "cmbBeforeInterLock";
            this.cmbBeforeInterLock.Size = new System.Drawing.Size(121, 21);
            this.cmbBeforeInterLock.TabIndex = 1;
            // 
            // lblAfterInterlock
            // 
            this.lblAfterInterlock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAfterInterlock.AutoSize = true;
            this.lblAfterInterlock.Location = new System.Drawing.Point(25, 220);
            this.lblAfterInterlock.Name = "lblAfterInterlock";
            this.lblAfterInterlock.Size = new System.Drawing.Size(82, 13);
            this.lblAfterInterlock.TabIndex = 0;
            this.lblAfterInterlock.Text = "After Interlock : ";
            // 
            // cmbAfterInterLock
            // 
            this.cmbAfterInterLock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbAfterInterLock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAfterInterLock.FormattingEnabled = true;
            this.cmbAfterInterLock.Items.AddRange(new object[] {
            "NAK Error",
            "Interlock Error"});
            this.cmbAfterInterLock.Location = new System.Drawing.Point(113, 216);
            this.cmbAfterInterLock.Name = "cmbAfterInterLock";
            this.cmbAfterInterLock.Size = new System.Drawing.Size(121, 21);
            this.cmbAfterInterLock.TabIndex = 1;
            // 
            // lblNAKErrorType
            // 
            this.lblNAKErrorType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNAKErrorType.AutoSize = true;
            this.lblNAKErrorType.Location = new System.Drawing.Point(19, 69);
            this.lblNAKErrorType.Name = "lblNAKErrorType";
            this.lblNAKErrorType.Size = new System.Drawing.Size(88, 13);
            this.lblNAKErrorType.TabIndex = 0;
            this.lblNAKErrorType.Text = "Rejection Type : ";
            // 
            // cmbNAKErrorType
            // 
            this.cmbNAKErrorType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbNAKErrorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNAKErrorType.FormattingEnabled = true;
            this.cmbNAKErrorType.Location = new System.Drawing.Point(113, 65);
            this.cmbNAKErrorType.Name = "cmbNAKErrorType";
            this.cmbNAKErrorType.Size = new System.Drawing.Size(121, 21);
            this.cmbNAKErrorType.TabIndex = 1;
            // 
            // lblNakWarning
            // 
            this.lblNakWarning.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNakWarning.AutoSize = true;
            this.lblNakWarning.Location = new System.Drawing.Point(3, 100);
            this.lblNakWarning.Name = "lblNakWarning";
            this.lblNakWarning.Size = new System.Drawing.Size(104, 13);
            this.lblNakWarning.TabIndex = 0;
            this.lblNakWarning.Text = "Rejection Warning : ";
            // 
            // cmbNAKWarning
            // 
            this.cmbNAKWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbNAKWarning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNAKWarning.FormattingEnabled = true;
            this.cmbNAKWarning.Items.AddRange(new object[] {
            "NAK Error",
            "Interlock Error"});
            this.cmbNAKWarning.Location = new System.Drawing.Point(113, 96);
            this.cmbNAKWarning.Name = "cmbNAKWarning";
            this.cmbNAKWarning.Size = new System.Drawing.Size(121, 21);
            this.cmbNAKWarning.TabIndex = 1;
            // 
            // btnUpdateLoadPort
            // 
            this.btnUpdateLoadPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnUpdateLoadPort.AutoSize = true;
            this.btnUpdateLoadPort.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdateLoadPort.Location = new System.Drawing.Point(4, 263);
            this.btnUpdateLoadPort.Name = "btnUpdateLoadPort";
            this.btnUpdateLoadPort.Size = new System.Drawing.Size(101, 34);
            this.btnUpdateLoadPort.TabIndex = 3;
            this.btnUpdateLoadPort.Text = "Update Load Port";
            this.btnUpdateLoadPort.UseVisualStyleBackColor = false;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClearAll.Location = new System.Drawing.Point(113, 263);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(136, 34);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "Clear All Errors and Reinit";
            this.btnClearAll.UseVisualStyleBackColor = false;
            // 
            // grpCarrier
            // 
            this.grpCarrier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grpCarrier.AutoSize = true;
            this.grpCarrier.Controls.Add(this.rbtnCarrierRemoved);
            this.grpCarrier.Controls.Add(this.rbtnCarrierPlaced);
            this.grpCarrier.Location = new System.Drawing.Point(255, 3);
            this.grpCarrier.Name = "grpCarrier";
            this.tableLayoutPanel1.SetRowSpan(this.grpCarrier, 2);
            this.grpCarrier.Size = new System.Drawing.Size(146, 56);
            this.grpCarrier.TabIndex = 2;
            this.grpCarrier.TabStop = false;
            this.grpCarrier.Text = "Carrier";
            // 
            // rbtnCarrierRemoved
            // 
            this.rbtnCarrierRemoved.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnCarrierRemoved.AutoSize = true;
            this.rbtnCarrierRemoved.Checked = true;
            this.rbtnCarrierRemoved.Location = new System.Drawing.Point(69, 20);
            this.rbtnCarrierRemoved.Name = "rbtnCarrierRemoved";
            this.rbtnCarrierRemoved.Size = new System.Drawing.Size(71, 17);
            this.rbtnCarrierRemoved.TabIndex = 0;
            this.rbtnCarrierRemoved.TabStop = true;
            this.rbtnCarrierRemoved.Text = "Removed";
            this.rbtnCarrierRemoved.UseVisualStyleBackColor = true;
            // 
            // rbtnCarrierPlaced
            // 
            this.rbtnCarrierPlaced.AutoSize = true;
            this.rbtnCarrierPlaced.Location = new System.Drawing.Point(7, 20);
            this.rbtnCarrierPlaced.Name = "rbtnCarrierPlaced";
            this.rbtnCarrierPlaced.Size = new System.Drawing.Size(58, 17);
            this.rbtnCarrierPlaced.TabIndex = 0;
            this.rbtnCarrierPlaced.Text = "Placed";
            this.rbtnCarrierPlaced.UseVisualStyleBackColor = true;
            // 
            // grpWaferProtrusion
            // 
            this.grpWaferProtrusion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grpWaferProtrusion.AutoSize = true;
            this.grpWaferProtrusion.Controls.Add(this.rbtnWaferProtrusionInterference);
            this.grpWaferProtrusion.Controls.Add(this.rbtnWaferProtrusionOK);
            this.grpWaferProtrusion.Location = new System.Drawing.Point(255, 65);
            this.grpWaferProtrusion.Name = "grpWaferProtrusion";
            this.tableLayoutPanel1.SetRowSpan(this.grpWaferProtrusion, 2);
            this.grpWaferProtrusion.Size = new System.Drawing.Size(157, 56);
            this.grpWaferProtrusion.TabIndex = 2;
            this.grpWaferProtrusion.TabStop = false;
            this.grpWaferProtrusion.Text = "Wafer Protrusion Sensor";
            // 
            // rbtnWaferProtrusionInterference
            // 
            this.rbtnWaferProtrusionInterference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtnWaferProtrusionInterference.AutoSize = true;
            this.rbtnWaferProtrusionInterference.Location = new System.Drawing.Point(69, 20);
            this.rbtnWaferProtrusionInterference.Name = "rbtnWaferProtrusionInterference";
            this.rbtnWaferProtrusionInterference.Size = new System.Drawing.Size(82, 17);
            this.rbtnWaferProtrusionInterference.TabIndex = 0;
            this.rbtnWaferProtrusionInterference.Text = "Interference";
            this.rbtnWaferProtrusionInterference.UseVisualStyleBackColor = true;
            // 
            // rbtnWaferProtrusionOK
            // 
            this.rbtnWaferProtrusionOK.AutoSize = true;
            this.rbtnWaferProtrusionOK.Checked = true;
            this.rbtnWaferProtrusionOK.Location = new System.Drawing.Point(7, 20);
            this.rbtnWaferProtrusionOK.Name = "rbtnWaferProtrusionOK";
            this.rbtnWaferProtrusionOK.Size = new System.Drawing.Size(40, 17);
            this.rbtnWaferProtrusionOK.TabIndex = 0;
            this.rbtnWaferProtrusionOK.TabStop = true;
            this.rbtnWaferProtrusionOK.Text = "OK";
            this.rbtnWaferProtrusionOK.UseVisualStyleBackColor = true;
            // 
            // lblSlot
            // 
            this.lblSlot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSlot.AutoSize = true;
            this.lblSlot.Location = new System.Drawing.Point(3, 21);
            this.lblSlot.Name = "lblSlot";
            this.lblSlot.Size = new System.Drawing.Size(44, 13);
            this.lblSlot.TabIndex = 0;
            this.lblSlot.Text = "Slot # : ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblSlot, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbSlots, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSlotStatus, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbSlotStatus, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(255, 127);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 56);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // cmbSlots
            // 
            this.cmbSlots.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlots.FormattingEnabled = true;
            this.cmbSlots.Location = new System.Drawing.Point(53, 17);
            this.cmbSlots.Name = "cmbSlots";
            this.cmbSlots.Size = new System.Drawing.Size(47, 21);
            this.cmbSlots.TabIndex = 1;
            // 
            // lblSlotStatus
            // 
            this.lblSlotStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSlotStatus.AutoSize = true;
            this.lblSlotStatus.Location = new System.Drawing.Point(106, 21);
            this.lblSlotStatus.Name = "lblSlotStatus";
            this.lblSlotStatus.Size = new System.Drawing.Size(46, 13);
            this.lblSlotStatus.TabIndex = 0;
            this.lblSlotStatus.Text = "Status : ";
            // 
            // cmbSlotStatus
            // 
            this.cmbSlotStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSlotStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSlotStatus.FormattingEnabled = true;
            this.cmbSlotStatus.Location = new System.Drawing.Point(158, 17);
            this.cmbSlotStatus.Name = "cmbSlotStatus";
            this.cmbSlotStatus.Size = new System.Drawing.Size(79, 21);
            this.cmbSlotStatus.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "TAS300 Emulator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpInterLockType.ResumeLayout(false);
            this.grpInterLockType.PerformLayout();
            this.grpCarrier.ResumeLayout(false);
            this.grpCarrier.PerformLayout();
            this.grpWaferProtrusion.ResumeLayout(false);
            this.grpWaferProtrusion.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLoadPort;
        private System.Windows.Forms.ComboBox cmbLoadPort;
        private System.Windows.Forms.Label lblErrorType;
        private System.Windows.Forms.ComboBox cmbErrorType;
        private System.Windows.Forms.GroupBox grpInterLockType;
        private System.Windows.Forms.RadioButton rbtnAfter;
        private System.Windows.Forms.RadioButton rbtnBefore;
        private System.Windows.Forms.Label lblBeforeInterlock;
        private System.Windows.Forms.ComboBox cmbBeforeInterLock;
        private System.Windows.Forms.Label lblAfterInterlock;
        private System.Windows.Forms.ComboBox cmbAfterInterLock;
        private System.Windows.Forms.Label lblNAKErrorType;
        private System.Windows.Forms.ComboBox cmbNAKErrorType;
        private System.Windows.Forms.Label lblNakWarning;
        private System.Windows.Forms.ComboBox cmbNAKWarning;
        private System.Windows.Forms.Button btnUpdateLoadPort;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.GroupBox grpCarrier;
        private System.Windows.Forms.RadioButton rbtnCarrierRemoved;
        private System.Windows.Forms.RadioButton rbtnCarrierPlaced;
        private System.Windows.Forms.GroupBox grpWaferProtrusion;
        private System.Windows.Forms.RadioButton rbtnWaferProtrusionInterference;
        private System.Windows.Forms.RadioButton rbtnWaferProtrusionOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSlot;
        private System.Windows.Forms.ComboBox cmbSlots;
        private System.Windows.Forms.Label lblSlotStatus;
        private System.Windows.Forms.ComboBox cmbSlotStatus;
    }
}

