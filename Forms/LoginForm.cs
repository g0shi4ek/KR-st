using System;
using System.Windows.Forms;

namespace KR.Forms
{
    /// <summary>
    /// Variant 11: Role selection form.
    /// The user chooses whether this instance is the Sender (источник) or the Receiver (приёмник).
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>True = this PC is the Sender; False = Receiver.</summary>
        public bool IsSender { get; private set; }

        /// <summary>Set to true when the user confirmed a role.</summary>
        public bool RoleSelected { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnSender_Click(object sender, EventArgs e)
        {
            IsSender     = true;
            RoleSelected = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnReceiver_Click(object sender, EventArgs e)
        {
            IsSender     = false;
            RoleSelected = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
