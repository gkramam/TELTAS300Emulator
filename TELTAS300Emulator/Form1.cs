using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELTAS300Emulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            ControlExtensions.BindToEnum<LoadPorts>(cmbLoadPort);
            ControlExtensions.BindToEnum<ForceErrorType>(cmbErrorType);
            ControlExtensions.BindToEnum<NAKParams>(cmbNAKErrorType);
            ControlExtensions.BindToEnum<NAKWarnings>(cmbNAKWarning);
            ControlExtensions.BindToEnum<BeforeInterLocks>(cmbBeforeInterLock);
            ControlExtensions.BindToEnum<AfterInterLocks>(cmbAfterInterLock);
            ControlExtensions.BindToEnum<SlotStatus>(cmbSlotStatus);

            Dictionary<int, int> source = new Dictionary<int, int>();
            Enumerable.Range(1, AppConfiguration.NumberOfSlotsInCasette).ToList().ForEach(s =>
            {
                source.Add(s-1, s);
            });
            cmbSlots.DataSource = source.ToList();
            cmbSlots.DisplayMember = "Value";
            cmbSlots.ValueMember = "Key";
            cmbSlots.SelectedIndex = 0;

            ResetAll();

            rbtnCarrierRemoved.Checked = true;
            rbtnCarrierPlaced.Checked = false;
            rbtnWaferProtrusionOK.Checked = true;
            rbtnWaferProtrusionInterference.Checked = false;

            btnUpdateLoadPort.Click += BtnUpdateLoadPort_Click;
            btnClearAll.Click += BtnClearAll_Click;

            cmbLoadPort.SelectedIndexChanged += CmbLoadPort_SelectedIndexChanged;
            cmbErrorType.SelectedIndexChanged += CmbErrorType_SelectedIndexChanged;
            rbtnBefore.CheckedChanged += RbtnInterLock_CheckedChanged;
            rbtnAfter.CheckedChanged += RbtnInterLock_CheckedChanged;

            rbtnWaferProtrusionOK.CheckedChanged += RbtnWaferProtrusion_CheckedChanged;
            rbtnWaferProtrusionInterference.CheckedChanged += RbtnWaferProtrusion_CheckedChanged;

            rbtnCarrierPlaced.CheckedChanged += RbtnCarrier_CheckedChanged;
            rbtnCarrierRemoved.CheckedChanged += RbtnCarrier_CheckedChanged;

            cmbSlots.SelectedIndexChanged += CmbSlots_SelectedIndexChanged;
            cmbSlotStatus.SelectedIndexChanged += CmbSlotStatus_SelectedIndexChanged;
            cmbLoadPort.SelectedIndex = 1;
            cmbLoadPort.SelectedIndex = 0;

        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }
        private void CmbSlotStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingSlotStatus)
                return;
            var loadport = Program.emulation.LoadPorts[cmbLoadPort.SelectedIndex];
            loadport.Casette[cmbSlots.SelectedIndex] =
                (SlotStatus)Enum.Parse(typeof(SlotStatus), cmbSlotStatus.SelectedValue.ToString());
        }

        bool isLoadingSlotStatus = false;
        private void CmbSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loadport = Program.emulation.LoadPorts[cmbLoadPort.SelectedIndex];
            var status = loadport.Casette[cmbSlots.SelectedIndex];
            isLoadingSlotStatus = true;

            foreach(KeyValuePair<string,object> kvp in cmbSlotStatus.Items)
            {
                if (kvp.Key.Equals(status.ToString()))
                {
                    cmbSlotStatus.SelectedIndex = cmbSlotStatus.Items.IndexOf(kvp);
                    break;
                }
            }
            isLoadingSlotStatus = false;
        }

        void EnableDisableForWaferProtrusion(bool isEnable)
        {
            cmbErrorType.Enabled =
                cmbNAKErrorType.Enabled =
                cmbNAKWarning.Enabled =
                grpInterLockType.Enabled =
                cmbBeforeInterLock.Enabled =
                cmbAfterInterLock.Enabled =
                btnClearAll.Enabled =
                btnUpdateLoadPort.Enabled = isEnable;
            
            ResetErrorLevel(true);
        }

        int CheckedCOunt = 0;
        private void RbtnCarrier_CheckedChanged(object sender, EventArgs e)
        {
            if (isReloadingLoadportData)
                return;
            CheckedCOunt++;
            if (CheckedCOunt > 1)
            {
                CheckedCOunt = 0;
                return;
            }
            var loadport = Program.emulation.LoadPorts[cmbLoadPort.SelectedIndex];
            loadport.IsCarrierPlaced = rbtnCarrierPlaced.Checked;
        }

        private void RbtnWaferProtrusion_CheckedChanged(object sender, EventArgs e)
        {
            if (isReloadingLoadportData)
                return;
            CheckedCOunt++;
            if (CheckedCOunt > 1)
            {
                CheckedCOunt = 0;
                return;
            }
            EnableDisableForWaferProtrusion(rbtnWaferProtrusionOK.Checked);
            var loadport = Program.emulation.LoadPorts[cmbLoadPort.SelectedIndex];
            loadport.IsWaferProtrusionSensorInterLock = rbtnWaferProtrusionInterference.Checked;
            
        }

        private void CmbLoadPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetLoadPortLevel();
            ReloadLoadportData();
            EnableDisableForWaferProtrusion(rbtnWaferProtrusionOK.Checked);
        }
        bool isReloadingLoadportData = false;
        void ReloadLoadportData()
        {
            isReloadingLoadportData = true;
            var loadport = Program.emulation.LoadPorts[cmbLoadPort.SelectedIndex];
            rbtnWaferProtrusionOK.Enabled =
                rbtnWaferProtrusionInterference.Enabled =
                rbtnCarrierPlaced.Enabled =
                rbtnCarrierRemoved.Enabled =
                grpCarrier.Enabled =
                grpWaferProtrusion.Enabled = false;
            rbtnWaferProtrusionOK.Checked = !loadport.IsWaferProtrusionSensorInterLock;
            rbtnWaferProtrusionInterference.Checked = loadport.IsWaferProtrusionSensorInterLock;
            rbtnCarrierPlaced.Checked = loadport.IsCarrierPlaced;
            rbtnCarrierRemoved.Checked = !loadport.IsCarrierPlaced;
            rbtnWaferProtrusionOK.Enabled =
                rbtnWaferProtrusionInterference.Enabled =
                rbtnCarrierPlaced.Enabled =
                rbtnCarrierRemoved.Enabled =
                grpCarrier.Enabled =
                grpWaferProtrusion.Enabled = true;
            isReloadingLoadportData = false;
        }

        private void RbtnInterLock_CheckedChanged(object sender, EventArgs e)
        {
            cmbBeforeInterLock.Enabled = rbtnBefore.Checked;
            cmbAfterInterLock.Enabled = rbtnAfter.Checked;
        }

        private void CmbErrorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetErrorLevel(true);

            if (cmbErrorType.SelectedIndex == -1)
                return;

            switch (Enum.Parse(typeof(ForceErrorType),cmbErrorType.SelectedValue.ToString()))
            {
                case ForceErrorType.Rejection_Reply:
                    cmbNAKErrorType.Enabled = cmbNAKWarning.Enabled = true;
                    break;
                case ForceErrorType.Interlock:
                    grpInterLockType.Enabled = cmbBeforeInterLock.Enabled = true;
                    break;
            }
        }

        public void ResetLoadPortLevel()
        {
            cmbErrorType.SelectedIndex = -1;
        }

        public void ResetCarrier()
        {
            rbtnCarrierPlaced.Enabled = rbtnCarrierRemoved.Enabled = false;
            
            rbtnCarrierPlaced.Enabled = rbtnCarrierRemoved.Enabled = true;
        }

        public void ResetWaferProtrusion()
        {
            rbtnWaferProtrusionOK.Enabled = rbtnWaferProtrusionInterference.Enabled = false;
            rbtnWaferProtrusionOK.Checked = true;
            rbtnWaferProtrusionInterference.Checked = false;
            rbtnWaferProtrusionOK.Enabled = rbtnWaferProtrusionInterference.Enabled = true; ;
        }
        public void ResetErrorLevel(bool disable)
        {
            cmbNAKErrorType.Enabled =
            cmbNAKWarning.Enabled =
                grpInterLockType.Enabled =
                cmbAfterInterLock.Enabled =
                cmbBeforeInterLock.Enabled = !disable;

            cmbNAKErrorType.SelectedIndex = -1;
            cmbNAKWarning.SelectedIndex = -1;
            rbtnBefore.Checked = true;
            cmbAfterInterLock.SelectedIndex = -1;
            cmbBeforeInterLock.SelectedIndex = -1;
        }

        public void ResetAll()
        {
            cmbErrorType.Enabled =
                cmbNAKErrorType.Enabled =
                cmbNAKWarning.Enabled =
                cmbAfterInterLock.Enabled =
                cmbBeforeInterLock.Enabled = 
                rbtnBefore.Enabled =
                rbtnAfter.Enabled = 
                grpInterLockType.Enabled = false;

            cmbErrorType.SelectedIndex = -1;
            cmbNAKErrorType.SelectedIndex = -1;
            cmbNAKWarning.SelectedIndex = -1;
            cmbBeforeInterLock.SelectedIndex = -1;
            cmbAfterInterLock.SelectedIndex = -1;
            rbtnBefore.Checked = true;
            rbtnAfter.Checked = false;

            rbtnBefore.Enabled =
                rbtnAfter.Enabled = true;
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            ResetAll();

            Program.emulation.LoadPorts.ForEach(l => {
                l.ForceErrorForFutureCommands = false;
                l.ForceErrorContext = null;
                l.State = new LoadPortState() {waferProtrusionSensor=l.State.waferProtrusionSensor,casettePresence=l.State.casettePresence };
            });
        }

        void ShowValidationMessage(string message)
        {
            MessageBoxEx.Show(this, message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnUpdateLoadPort_Click(object sender, EventArgs e)
        {

            Nullable<LoadPorts> loadport = null;
            Nullable<ForceErrorType> errType = null;
            Nullable<NAKParams> nakErrType = null;
            Nullable<NAKWarnings> nakwarn = null;
            Nullable<BeforeInterLocks> beforeInterlock = null;
            Nullable<AfterInterLocks> afterInterlock = null;

            if (cmbLoadPort.SelectedIndex != -1)
                loadport = (LoadPorts)Enum.Parse(typeof(LoadPorts), cmbLoadPort.SelectedValue.ToString());
            if (cmbErrorType.SelectedIndex != -1)
                 errType = (ForceErrorType)Enum.Parse(typeof(ForceErrorType), cmbErrorType.SelectedValue.ToString());
            if (cmbNAKErrorType.SelectedIndex != -1)
                nakErrType = (NAKParams)Enum.Parse(typeof(NAKParams), cmbNAKErrorType.SelectedValue.ToString());
            if (cmbNAKWarning.SelectedIndex != -1)
                nakwarn = (NAKWarnings)Enum.Parse(typeof(NAKWarnings), cmbNAKWarning.SelectedValue.ToString());
            if (cmbBeforeInterLock.SelectedIndex != -1)
                beforeInterlock = (BeforeInterLocks)Enum.Parse(typeof(BeforeInterLocks), cmbBeforeInterLock.SelectedValue.ToString());
            if (cmbAfterInterLock.SelectedIndex != -1)
                afterInterlock = (AfterInterLocks)Enum.Parse(typeof(AfterInterLocks), cmbAfterInterLock.SelectedValue.ToString());

            if(loadport == null)
            {
                ShowValidationMessage("Select a Loadport");
                return;
            }
            else if(errType == null)
            {
                ShowValidationMessage("Select a Error Type");
                return;
            }
            else if(errType == ForceErrorType.Rejection_Reply && nakErrType == null)
            {
                ShowValidationMessage("Select a NAK Error and an optional Warning");
                return;
            }
            else if (errType == ForceErrorType.Interlock && rbtnBefore.Checked && beforeInterlock == null)
            {
                ShowValidationMessage( "Select a Before Interlock");
                return;
            }
            else if (errType == ForceErrorType.Interlock && !rbtnBefore.Checked && afterInterlock == null)
            {
                ShowValidationMessage( "Select a After Interlock");
                return;
            }

            var loadPort = Program.emulation.LoadPorts[0];//[cmbLoadPort.SelectedIndex];
            loadPort.ForceErrorForFutureCommands = true;

            loadPort.ForceErrorContext = new ForceErrorContext(
                cmbLoadPort.SelectedIndex,
                errType,
                nakErrType,
                nakwarn,
                rbtnBefore.Checked,
                beforeInterlock,
                afterInterlock
                );
        }
    }
}
