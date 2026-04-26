namespace KR.Forms
{
    partial class ChatForm
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
            // ── Declare all controls ──────────────────────────────────────────
            this.menuStrip1          = new System.Windows.Forms.MenuStrip();
            this.menuItemHelp        = new System.Windows.Forms.ToolStripMenuItem();

            this.panelHeader         = new System.Windows.Forms.Panel();
            this.lblRole             = new System.Windows.Forms.Label();
            this.lblPortInfo         = new System.Windows.Forms.Label();
            this.lblStatus           = new System.Windows.Forms.Label();
            this.btnConnect          = new System.Windows.Forms.Button();
            this.btnDisconnect       = new System.Windows.Forms.Button();

            this.panelMain           = new System.Windows.Forms.Panel();

            this.grpSender           = new System.Windows.Forms.GroupBox();
            this.lblFilePath         = new System.Windows.Forms.Label();
            this.txtFilePath         = new System.Windows.Forms.TextBox();
            this.btnBrowse           = new System.Windows.Forms.Button();
            this.btnSendFile         = new System.Windows.Forms.Button();
            this.lblPaceLabel        = new System.Windows.Forms.Label();
            this.cmbPace             = new System.Windows.Forms.ComboBox();
            this.btnSetPace          = new System.Windows.Forms.Button();
            this.lblErrorMode        = new System.Windows.Forms.Label();
            this.cmbErrorMode        = new System.Windows.Forms.ComboBox();
            this.progressBar         = new System.Windows.Forms.ProgressBar();
            this.lblProgress         = new System.Windows.Forms.Label();

            this.grpReceiver         = new System.Windows.Forms.GroupBox();
            this.lblReceivedFile     = new System.Windows.Forms.Label();
            this.txtReceivedFileName = new System.Windows.Forms.TextBox();
            this.btnSaveFile         = new System.Windows.Forms.Button();
            this.lblPaceRecvLabel    = new System.Windows.Forms.Label();
            this.cmbPaceRecv         = new System.Windows.Forms.ComboBox();
            this.btnSetPaceRecv      = new System.Windows.Forms.Button();
            this.progressBarRecv     = new System.Windows.Forms.ProgressBar();
            this.lblProgressRecv     = new System.Windows.Forms.Label();

            this.grpFilePreview      = new System.Windows.Forms.GroupBox();
            this.rtbFileContent      = new System.Windows.Forms.RichTextBox();

            this.grpLog              = new System.Windows.Forms.GroupBox();
            this.rtbLog              = new System.Windows.Forms.RichTextBox();

            this.openFileDialog1     = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1     = new System.Windows.Forms.SaveFileDialog();

            this.menuStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.grpSender.SuspendLayout();
            this.grpReceiver.SuspendLayout();
            this.grpFilePreview.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();

            // ── Color palette ─────────────────────────────────────────────────
            // bg0 = deepest background  #0f1117
            // bg1 = card/panel bg       #161b2e
            // bg2 = input bg            #1e2540
            // acc = accent blue         #4361ee
            // grn = accent green        #4cc9a0
            // red = danger              #e05252
            // txt = primary text        #e0e6f0
            // sub = secondary text      #8899bb
            var bg0 = System.Drawing.Color.FromArgb(15,  17,  23);
            var bg1 = System.Drawing.Color.FromArgb(22,  27,  46);
            var bg2 = System.Drawing.Color.FromArgb(30,  37,  64);
            var acc = System.Drawing.Color.FromArgb(67,  97, 238);
            var grn = System.Drawing.Color.FromArgb(76, 201, 160);
            var red = System.Drawing.Color.FromArgb(224, 82,  82);
            var txt = System.Drawing.Color.FromArgb(224, 230, 240);
            var sub = System.Drawing.Color.FromArgb(136, 153, 187);

            var fontUI   = new System.Drawing.Font("Segoe UI",          9.5F);
            var fontSemi = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            var fontBold = new System.Drawing.Font("Segoe UI",          9.5F, System.Drawing.FontStyle.Bold);
            var fontMono = new System.Drawing.Font("Consolas",          9F);

            // ── menuStrip1 ────────────────────────────────────────────────────
            this.menuStrip1.BackColor = bg0;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuItemHelp });
            this.menuStrip1.Location  = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name      = "menuStrip1";
            this.menuStrip1.Size      = new System.Drawing.Size(960, 24);
            this.menuStrip1.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

            this.menuItemHelp.ForeColor = sub;
            this.menuItemHelp.Font      = fontUI;
            this.menuItemHelp.Name      = "menuItemHelp";
            this.menuItemHelp.Text      = "Справка";
            this.menuItemHelp.Click    += new System.EventHandler(this.MenuItemHelp_Click);

            // ── panelHeader (top status bar) ──────────────────────────────────
            this.panelHeader.BackColor = bg1;
            this.panelHeader.Location  = new System.Drawing.Point(0, 24);
            this.panelHeader.Size      = new System.Drawing.Size(960, 56);
            this.panelHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblRole, this.lblPortInfo, this.lblStatus,
                this.btnConnect, this.btnDisconnect });

            // Role label
            this.lblRole.AutoSize  = false;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font      = fontBold;
            this.lblRole.ForeColor = txt;
            this.lblRole.Location  = new System.Drawing.Point(12, 8);
            this.lblRole.Size      = new System.Drawing.Size(200, 20);
            this.lblRole.Text      = "Роль: —";

            // Port info
            this.lblPortInfo.AutoSize  = false;
            this.lblPortInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPortInfo.Font      = fontUI;
            this.lblPortInfo.ForeColor = sub;
            this.lblPortInfo.Location  = new System.Drawing.Point(12, 30);
            this.lblPortInfo.Size      = new System.Drawing.Size(380, 18);
            this.lblPortInfo.Text      = "Порт: —  |  9600 bps · 8N1";

            // Status badge
            this.lblStatus.AutoSize  = false;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(40, 224, 82, 82);
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = red;
            this.lblStatus.Location  = new System.Drawing.Point(400, 16);
            this.lblStatus.Size      = new System.Drawing.Size(130, 22);
            this.lblStatus.Text      = "● Не подключено";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Connect button
            this.btnConnect.BackColor = acc;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(86, 116, 255);
            this.btnConnect.Font      = fontSemi;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location  = new System.Drawing.Point(760, 12);
            this.btnConnect.Size      = new System.Drawing.Size(90, 32);
            this.btnConnect.Text      = "Подключить";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.Click    += new System.EventHandler(this.BtnConnect_Click);

            // Disconnect button
            this.btnDisconnect.BackColor = red;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.FlatAppearance.BorderSize = 0;
            this.btnDisconnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 100, 100);
            this.btnDisconnect.Font      = fontSemi;
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location  = new System.Drawing.Point(858, 12);
            this.btnDisconnect.Size      = new System.Drawing.Size(90, 32);
            this.btnDisconnect.Text      = "Отключить";
            this.btnDisconnect.Enabled   = false;
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnDisconnect.Click    += new System.EventHandler(this.BtnDisconnect_Click);

            // ── panelMain (content area below header) ─────────────────────────
            this.panelMain.BackColor = bg0;
            this.panelMain.Location  = new System.Drawing.Point(0, 80);
            this.panelMain.Size      = new System.Drawing.Size(960, 560);
            this.panelMain.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpSender, this.grpReceiver, this.grpFilePreview, this.grpLog });

            // ── Helper: style a GroupBox ──────────────────────────────────────
            void StyleGroup(System.Windows.Forms.GroupBox g, string title,
                            int x, int y, int w, int h)
            {
                g.BackColor = bg1;
                g.ForeColor = sub;
                g.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
                g.Location  = new System.Drawing.Point(x, y);
                g.Size      = new System.Drawing.Size(w, h);
                g.Text      = title;
                g.Padding   = new System.Windows.Forms.Padding(8);
            }

            // ── grpSender ─────────────────────────────────────────────────────
            StyleGroup(this.grpSender, "Источник — отправка файла", 8, 8, 460, 196);
            this.grpSender.Visible = false;
            this.grpSender.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFilePath, this.txtFilePath, this.btnBrowse, this.btnSendFile,
                this.lblPaceLabel, this.cmbPace, this.btnSetPace,
                this.lblErrorMode, this.cmbErrorMode,
                this.progressBar, this.lblProgress });

            this.lblFilePath.AutoSize  = false;
            this.lblFilePath.BackColor = System.Drawing.Color.Transparent;
            this.lblFilePath.Font      = fontUI;
            this.lblFilePath.ForeColor = sub;
            this.lblFilePath.Location  = new System.Drawing.Point(10, 24);
            this.lblFilePath.Size      = new System.Drawing.Size(44, 22);
            this.lblFilePath.Text      = "Файл:";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtFilePath.Font      = fontMono;
            this.txtFilePath.Location  = new System.Drawing.Point(58, 24);
            this.txtFilePath.Size      = new System.Drawing.Size(280, 22);
            this.txtFilePath.ReadOnly  = true;
            this.txtFilePath.BackColor = bg2;
            this.txtFilePath.ForeColor = txt;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnBrowse.BackColor = bg2;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 70, 110);
            this.btnBrowse.FlatAppearance.BorderSize  = 1;
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(50, 60, 100);
            this.btnBrowse.Font      = fontUI;
            this.btnBrowse.ForeColor = txt;
            this.btnBrowse.Location  = new System.Drawing.Point(346, 23);
            this.btnBrowse.Size      = new System.Drawing.Size(100, 24);
            this.btnBrowse.Text      = "📂 Обзор...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Click    += new System.EventHandler(this.BtnBrowse_Click);

            this.btnSendFile.BackColor = grn;
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.FlatAppearance.BorderSize = 0;
            this.btnSendFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(95, 220, 180);
            this.btnSendFile.Font      = fontSemi;
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Location  = new System.Drawing.Point(10, 56);
            this.btnSendFile.Size      = new System.Drawing.Size(436, 34);
            this.btnSendFile.Text      = "▶  Отправить файл";
            this.btnSendFile.Enabled   = false;
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSendFile.Click    += new System.EventHandler(this.BtnSendFile_Click);

            this.lblPaceLabel.AutoSize  = false;
            this.lblPaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPaceLabel.Font      = fontUI;
            this.lblPaceLabel.ForeColor = sub;
            this.lblPaceLabel.Location  = new System.Drawing.Point(10, 100);
            this.lblPaceLabel.Size      = new System.Drawing.Size(110, 22);
            this.lblPaceLabel.Text      = "Темп передачи:";
            this.lblPaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbPace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPace.Font          = fontUI;
            this.cmbPace.BackColor     = bg2;
            this.cmbPace.ForeColor     = txt;
            this.cmbPace.Location      = new System.Drawing.Point(124, 100);
            this.cmbPace.Size          = new System.Drawing.Size(180, 22);
            this.cmbPace.Items.AddRange(new object[] { "🐢  Медленно (500 мс)", "🚶  Нормально (100 мс)", "🚀  Быстро (10 мс)" });
            this.cmbPace.SelectedIndex = 1;

            this.btnSetPace.BackColor = acc;
            this.btnSetPace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPace.FlatAppearance.BorderSize = 0;
            this.btnSetPace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(86, 116, 255);
            this.btnSetPace.Font      = fontUI;
            this.btnSetPace.ForeColor = System.Drawing.Color.White;
            this.btnSetPace.Location  = new System.Drawing.Point(312, 99);
            this.btnSetPace.Size      = new System.Drawing.Size(134, 24);
            this.btnSetPace.Text      = "Задать темп";
            this.btnSetPace.UseVisualStyleBackColor = false;
            this.btnSetPace.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSetPace.Click    += new System.EventHandler(this.BtnSetPace_Click);

            // Error mode selector (Sender only — for demonstration)
            this.lblErrorMode.AutoSize  = false;
            this.lblErrorMode.BackColor = System.Drawing.Color.Transparent;
            this.lblErrorMode.Font      = fontUI;
            this.lblErrorMode.ForeColor = sub;
            this.lblErrorMode.Location  = new System.Drawing.Point(10, 130);
            this.lblErrorMode.Size      = new System.Drawing.Size(110, 22);
            this.lblErrorMode.Text      = "Режим ошибок:";
            this.lblErrorMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbErrorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbErrorMode.Font          = fontUI;
            this.cmbErrorMode.BackColor     = bg2;
            this.cmbErrorMode.ForeColor     = txt;
            this.cmbErrorMode.Location      = new System.Drawing.Point(124, 130);
            this.cmbErrorMode.Size          = new System.Drawing.Size(322, 22);
            this.cmbErrorMode.Items.AddRange(new object[] {
                "✅  Нет ошибок (нормальная передача)",
                "⚡  1 бит — Хэмминг исправит автоматически",
                "💥  2 бита — ошибка не исправима, RET_CHUNK" });
            this.cmbErrorMode.SelectedIndex = 0;
            this.cmbErrorMode.SelectedIndexChanged += new System.EventHandler(this.CmbErrorMode_SelectedIndexChanged);

            this.progressBar.Location = new System.Drawing.Point(10, 162);
            this.progressBar.Size     = new System.Drawing.Size(380, 14);
            this.progressBar.Minimum  = 0;
            this.progressBar.Maximum  = 100;
            this.progressBar.Value    = 0;
            this.progressBar.Style    = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.lblProgress.AutoSize  = false;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font      = fontUI;
            this.lblProgress.ForeColor = grn;
            this.lblProgress.Location  = new System.Drawing.Point(396, 160);
            this.lblProgress.Size      = new System.Drawing.Size(50, 18);
            this.lblProgress.Text      = "0 %";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── grpReceiver ───────────────────────────────────────────────────
            StyleGroup(this.grpReceiver, "Приёмник — приём файла", 8, 8, 460, 170);
            this.grpReceiver.Visible = false;
            this.grpReceiver.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblReceivedFile, this.txtReceivedFileName, this.btnSaveFile,
                this.lblPaceRecvLabel, this.cmbPaceRecv, this.btnSetPaceRecv,
                this.progressBarRecv, this.lblProgressRecv });

            this.lblReceivedFile.AutoSize  = false;
            this.lblReceivedFile.BackColor = System.Drawing.Color.Transparent;
            this.lblReceivedFile.Font      = fontUI;
            this.lblReceivedFile.ForeColor = sub;
            this.lblReceivedFile.Location  = new System.Drawing.Point(10, 24);
            this.lblReceivedFile.Size      = new System.Drawing.Size(100, 22);
            this.lblReceivedFile.Text      = "Принятый файл:";
            this.lblReceivedFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtReceivedFileName.Font      = fontMono;
            this.txtReceivedFileName.Location  = new System.Drawing.Point(114, 24);
            this.txtReceivedFileName.Size      = new System.Drawing.Size(224, 22);
            this.txtReceivedFileName.ReadOnly  = true;
            this.txtReceivedFileName.BackColor = bg2;
            this.txtReceivedFileName.ForeColor = txt;
            this.txtReceivedFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnSaveFile.BackColor = grn;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.FlatAppearance.BorderSize = 0;
            this.btnSaveFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(95, 220, 180);
            this.btnSaveFile.Font      = fontUI;
            this.btnSaveFile.ForeColor = System.Drawing.Color.White;
            this.btnSaveFile.Location  = new System.Drawing.Point(346, 23);
            this.btnSaveFile.Size      = new System.Drawing.Size(100, 24);
            this.btnSaveFile.Text      = "💾 Сохранить";
            this.btnSaveFile.Enabled   = false;
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFile.Click    += new System.EventHandler(this.BtnSaveFile_Click);

            this.lblPaceRecvLabel.AutoSize  = false;
            this.lblPaceRecvLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPaceRecvLabel.Font      = fontUI;
            this.lblPaceRecvLabel.ForeColor = sub;
            this.lblPaceRecvLabel.Location  = new System.Drawing.Point(10, 58);
            this.lblPaceRecvLabel.Size      = new System.Drawing.Size(110, 22);
            this.lblPaceRecvLabel.Text      = "Управл. темпом:";
            this.lblPaceRecvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbPaceRecv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaceRecv.Font          = fontUI;
            this.cmbPaceRecv.BackColor     = bg2;
            this.cmbPaceRecv.ForeColor     = txt;
            this.cmbPaceRecv.Location      = new System.Drawing.Point(124, 58);
            this.cmbPaceRecv.Size          = new System.Drawing.Size(180, 22);
            this.cmbPaceRecv.Items.AddRange(new object[] { "🐢  Медленно (500 мс)", "🚶  Нормально (100 мс)", "🚀  Быстро (10 мс)" });
            this.cmbPaceRecv.SelectedIndex = 1;

            this.btnSetPaceRecv.BackColor = acc;
            this.btnSetPaceRecv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPaceRecv.FlatAppearance.BorderSize = 0;
            this.btnSetPaceRecv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(86, 116, 255);
            this.btnSetPaceRecv.Font      = fontUI;
            this.btnSetPaceRecv.ForeColor = System.Drawing.Color.White;
            this.btnSetPaceRecv.Location  = new System.Drawing.Point(312, 57);
            this.btnSetPaceRecv.Size      = new System.Drawing.Size(134, 24);
            this.btnSetPaceRecv.Text      = "Задать темп";
            this.btnSetPaceRecv.UseVisualStyleBackColor = false;
            this.btnSetPaceRecv.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnSetPaceRecv.Click    += new System.EventHandler(this.BtnSetPaceRecv_Click);

            this.progressBarRecv.Location = new System.Drawing.Point(10, 92);
            this.progressBarRecv.Size     = new System.Drawing.Size(380, 14);
            this.progressBarRecv.Minimum  = 0;
            this.progressBarRecv.Maximum  = 100;
            this.progressBarRecv.Value    = 0;
            this.progressBarRecv.Style    = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.lblProgressRecv.AutoSize  = false;
            this.lblProgressRecv.BackColor = System.Drawing.Color.Transparent;
            this.lblProgressRecv.Font      = fontUI;
            this.lblProgressRecv.ForeColor = grn;
            this.lblProgressRecv.Location  = new System.Drawing.Point(396, 90);
            this.lblProgressRecv.Size      = new System.Drawing.Size(50, 18);
            this.lblProgressRecv.Text      = "0 %";
            this.lblProgressRecv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── grpFilePreview ────────────────────────────────────────────────
            StyleGroup(this.grpFilePreview, "Просмотр содержимого файла (в реальном времени)", 476, 8, 476, 170);
            this.grpFilePreview.Controls.Add(this.rtbFileContent);

            this.rtbFileContent.BackColor  = bg0;
            this.rtbFileContent.ForeColor  = grn;
            this.rtbFileContent.Font       = fontMono;
            this.rtbFileContent.Location   = new System.Drawing.Point(6, 20);
            this.rtbFileContent.Size       = new System.Drawing.Size(462, 142);
            this.rtbFileContent.ReadOnly   = true;
            this.rtbFileContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbFileContent.WordWrap   = false;
            this.rtbFileContent.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // ── grpLog ────────────────────────────────────────────────────────
            StyleGroup(this.grpLog, "Служебный журнал  (кадры · события · ошибки)", 8, 186, 944, 366);
            this.grpLog.Controls.Add(this.rtbLog);

            this.rtbLog.BackColor  = bg0;
            this.rtbLog.ForeColor  = sub;
            this.rtbLog.Font       = fontMono;
            this.rtbLog.Location   = new System.Drawing.Point(6, 18);
            this.rtbLog.Size       = new System.Drawing.Size(930, 340);
            this.rtbLog.ReadOnly   = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // ── Dialogs ───────────────────────────────────────────────────────
            this.openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            this.openFileDialog1.Title  = "Выберите файл для отправки";

            this.saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            this.saveFileDialog1.Title  = "Сохранить принятый файл";

            // ── ChatForm ──────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = bg0;
            this.ClientSize          = new System.Drawing.Size(960, 640);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip       = this.menuStrip1;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Передача файлов по RS232C — Вариант 11";
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMain);
            this.Load += new System.EventHandler(this.ChatForm_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.grpSender.ResumeLayout(false);
            this.grpReceiver.ResumeLayout(false);
            this.grpFilePreview.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── Controls ──────────────────────────────────────────────────────────
        private System.Windows.Forms.MenuStrip         menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;

        private System.Windows.Forms.Panel  panelHeader;
        private System.Windows.Forms.Panel  panelMain;
        private System.Windows.Forms.Label  lblRole;
        private System.Windows.Forms.Label  lblPortInfo;
        private System.Windows.Forms.Label  lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;

        private System.Windows.Forms.GroupBox  grpSender;
        private System.Windows.Forms.Label     lblFilePath;
        private System.Windows.Forms.TextBox   txtFilePath;
        private System.Windows.Forms.Button    btnBrowse;
        private System.Windows.Forms.Button    btnSendFile;
        private System.Windows.Forms.Label     lblPaceLabel;
        private System.Windows.Forms.ComboBox  cmbPace;
        private System.Windows.Forms.Button    btnSetPace;
        private System.Windows.Forms.Label     lblErrorMode;
        private System.Windows.Forms.ComboBox  cmbErrorMode;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label     lblProgress;

        private System.Windows.Forms.GroupBox  grpReceiver;
        private System.Windows.Forms.Label     lblReceivedFile;
        private System.Windows.Forms.TextBox   txtReceivedFileName;
        private System.Windows.Forms.Button    btnSaveFile;
        private System.Windows.Forms.Label     lblPaceRecvLabel;
        private System.Windows.Forms.ComboBox  cmbPaceRecv;
        private System.Windows.Forms.Button    btnSetPaceRecv;
        private System.Windows.Forms.ProgressBar progressBarRecv;
        private System.Windows.Forms.Label     lblProgressRecv;

        private System.Windows.Forms.GroupBox    grpFilePreview;
        private System.Windows.Forms.RichTextBox rtbFileContent;

        private System.Windows.Forms.GroupBox    grpLog;
        private System.Windows.Forms.RichTextBox rtbLog;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
