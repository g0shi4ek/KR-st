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
            this.panelTop      = new System.Windows.Forms.Panel();
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblSubtitle   = new System.Windows.Forms.Label();
            this.panelBody     = new System.Windows.Forms.Panel();
            this.lblPort       = new System.Windows.Forms.Label();
            this.panelButtons  = new System.Windows.Forms.Panel();
            this.btnSender     = new System.Windows.Forms.Button();
            this.btnReceiver   = new System.Windows.Forms.Button();
            this.btnExit       = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // ── panelTop (accent header bar) ──────────────────────────────────
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.panelTop.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height    = 80;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblSubtitle);

            this.lblTitle.AutoSize  = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(0, 10);
            this.lblTitle.Size      = new System.Drawing.Size(400, 30);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text      = "Передача файлов по RS232C";

            this.lblSubtitle.AutoSize  = false;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            this.lblSubtitle.Location  = new System.Drawing.Point(0, 44);
            this.lblSubtitle.Size      = new System.Drawing.Size(400, 22);
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Text      = "Вариант 11  ·  [7,4]-код Хэмминга  ·  RS232C нуль-модем";

            // ── panelBody ─────────────────────────────────────────────────────
            this.panelBody.BackColor = System.Drawing.Color.FromArgb(22, 27, 46);
            this.panelBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Controls.Add(this.lblPort);
            this.panelBody.Controls.Add(this.panelButtons);
            this.panelBody.Controls.Add(this.btnExit);

            // ── lblPort ───────────────────────────────────────────────────────
            this.lblPort.AutoSize  = false;
            this.lblPort.BackColor = System.Drawing.Color.FromArgb(30, 36, 60);
            this.lblPort.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(140, 160, 210);
            this.lblPort.Location  = new System.Drawing.Point(20, 18);
            this.lblPort.Size      = new System.Drawing.Size(360, 28);
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPort.Text      = "Источник → COM1     |     Приёмник → COM2     |     9600 bps · 8N1";

            // ── panelButtons ──────────────────────────────────────────────────
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Location  = new System.Drawing.Point(20, 58);
            this.panelButtons.Size      = new System.Drawing.Size(360, 80);
            this.panelButtons.Controls.Add(this.btnSender);
            this.panelButtons.Controls.Add(this.btnReceiver);

            // ── btnSender ─────────────────────────────────────────────────────
            this.btnSender.BackColor = System.Drawing.Color.FromArgb(67, 97, 238);
            this.btnSender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSender.FlatAppearance.BorderSize  = 0;
            this.btnSender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(86, 116, 255);
            this.btnSender.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnSender.ForeColor = System.Drawing.Color.White;
            this.btnSender.Location  = new System.Drawing.Point(0, 0);
            this.btnSender.Size      = new System.Drawing.Size(170, 70);
            this.btnSender.Text      = "📤  Источник\n(Sender · COM1)";
            this.btnSender.UseVisualStyleBackColor = false;
            this.btnSender.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSender.Click    += new System.EventHandler(this.BtnSender_Click);

            // ── btnReceiver ───────────────────────────────────────────────────
            this.btnReceiver.BackColor = System.Drawing.Color.FromArgb(76, 201, 160);
            this.btnReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiver.FlatAppearance.BorderSize  = 0;
            this.btnReceiver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(95, 220, 180);
            this.btnReceiver.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnReceiver.ForeColor = System.Drawing.Color.White;
            this.btnReceiver.Location  = new System.Drawing.Point(190, 0);
            this.btnReceiver.Size      = new System.Drawing.Size(170, 70);
            this.btnReceiver.Text      = "📥  Приёмник\n(Receiver · COM2)";
            this.btnReceiver.UseVisualStyleBackColor = false;
            this.btnReceiver.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnReceiver.Click    += new System.EventHandler(this.BtnReceiver_Click);

            // ── btnExit ───────────────────────────────────────────────────────
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(40, 46, 70);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 80, 120);
            this.btnExit.FlatAppearance.BorderSize  = 1;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnExit.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(160, 170, 200);
            this.btnExit.Location  = new System.Drawing.Point(140, 152);
            this.btnExit.Size      = new System.Drawing.Size(120, 30);
            this.btnExit.Text      = "Закрыть";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Click    += new System.EventHandler(this.BtnExit_Click);

            // ── LoginForm ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(22, 27, 46);
            this.ClientSize          = new System.Drawing.Size(400, 270);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Выбор роли — Вариант 11";
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.panelTop.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel  panelTop;
        private System.Windows.Forms.Panel  panelBody;
        private System.Windows.Forms.Panel  panelButtons;
        private System.Windows.Forms.Label  lblTitle;
        private System.Windows.Forms.Label  lblSubtitle;
        private System.Windows.Forms.Label  lblPort;
        private System.Windows.Forms.Button btnSender;
        private System.Windows.Forms.Button btnReceiver;
        private System.Windows.Forms.Button btnExit;

        public System.Windows.Forms.Label PortSetupFailedErrorLabel = new System.Windows.Forms.Label();
    }
}
