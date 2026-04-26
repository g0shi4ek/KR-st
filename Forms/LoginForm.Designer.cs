namespace KR.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblSubtitle   = new System.Windows.Forms.Label();
            this.lblPort       = new System.Windows.Forms.Label();
            this.btnSender     = new System.Windows.Forms.Button();
            this.btnReceiver   = new System.Windows.Forms.Button();
            this.btnExit       = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ── lblTitle ──────────────────────────────────────────────────────
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.None;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(10, 18);
            this.lblTitle.Size      = new System.Drawing.Size(360, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text      = "Передача файлов по RS232C";

            // ── lblSubtitle ───────────────────────────────────────────────────
            this.lblSubtitle.AutoSize  = false;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.LightCyan;
            this.lblSubtitle.Location  = new System.Drawing.Point(10, 58);
            this.lblSubtitle.Size      = new System.Drawing.Size(360, 24);
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Text      = "Вариант 11 — [7,4]-код Хэмминга";

            // ── lblPort ───────────────────────────────────────────────────────
            this.lblPort.AutoSize  = false;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblPort.ForeColor = System.Drawing.Color.LightYellow;
            this.lblPort.Location  = new System.Drawing.Point(10, 86);
            this.lblPort.Size      = new System.Drawing.Size(360, 22);
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPort.Text      = "Источник: COM1   |   Приёмник: COM2   |   9600 bps";

            // ── btnSender ─────────────────────────────────────────────────────
            this.btnSender.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSender.FlatAppearance.BorderSize = 0;
            this.btnSender.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 12F);
            this.btnSender.ForeColor = System.Drawing.Color.White;
            this.btnSender.Location  = new System.Drawing.Point(20, 128);
            this.btnSender.Size      = new System.Drawing.Size(160, 52);
            this.btnSender.Text      = "Источник\n(Sender, COM1)";
            this.btnSender.UseVisualStyleBackColor = false;
            this.btnSender.Click    += new System.EventHandler(this.BtnSender_Click);

            // ── btnReceiver ───────────────────────────────────────────────────
            this.btnReceiver.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiver.FlatAppearance.BorderSize = 0;
            this.btnReceiver.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 12F);
            this.btnReceiver.ForeColor = System.Drawing.Color.White;
            this.btnReceiver.Location  = new System.Drawing.Point(200, 128);
            this.btnReceiver.Size      = new System.Drawing.Size(160, 52);
            this.btnReceiver.Text      = "Приёмник\n(Receiver, COM2)";
            this.btnReceiver.UseVisualStyleBackColor = false;
            this.btnReceiver.Click    += new System.EventHandler(this.BtnReceiver_Click);

            // ── btnExit ───────────────────────────────────────────────────────
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location  = new System.Drawing.Point(130, 198);
            this.btnExit.Size      = new System.Drawing.Size(120, 32);
            this.btnExit.Text      = "Закрыть";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click    += new System.EventHandler(this.BtnExit_Click);

            // ── LoginForm ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(30, 30, 60);
            this.ClientSize          = new System.Drawing.Size(380, 248);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Выбор роли — Вариант 11";
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.btnSender);
            this.Controls.Add(this.btnReceiver);
            this.Controls.Add(this.btnExit);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblSubtitle;
        private System.Windows.Forms.Label  lblPort;
        private System.Windows.Forms.Button btnSender;
        private System.Windows.Forms.Button btnReceiver;
        private System.Windows.Forms.Button btnExit;

        // Keep public so ChatForm can reference it (was used in old code)
        public System.Windows.Forms.Label PortSetupFailedErrorLabel = new System.Windows.Forms.Label();
    }
}
