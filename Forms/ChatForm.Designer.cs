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
            this.menuStrip1              = new System.Windows.Forms.MenuStrip();
            this.menuItemHelp            = new System.Windows.Forms.ToolStripMenuItem();

            this.grpConnection           = new System.Windows.Forms.GroupBox();
            this.lblRole                 = new System.Windows.Forms.Label();
            this.lblPortInfo             = new System.Windows.Forms.Label();
            this.lblStatus               = new System.Windows.Forms.Label();
            this.btnConnect              = new System.Windows.Forms.Button();
            this.btnDisconnect           = new System.Windows.Forms.Button();

            this.grpSender               = new System.Windows.Forms.GroupBox();
            this.lblFilePath             = new System.Windows.Forms.Label();
            this.txtFilePath             = new System.Windows.Forms.TextBox();
            this.btnBrowse               = new System.Windows.Forms.Button();
            this.btnSendFile             = new System.Windows.Forms.Button();
            this.lblPaceLabel            = new System.Windows.Forms.Label();
            this.cmbPace                 = new System.Windows.Forms.ComboBox();
            this.btnSetPace              = new System.Windows.Forms.Button();
            this.progressBar             = new System.Windows.Forms.ProgressBar();
            this.lblProgress             = new System.Windows.Forms.Label();

            this.grpReceiver             = new System.Windows.Forms.GroupBox();
            this.lblReceivedFile         = new System.Windows.Forms.Label();
            this.txtReceivedFileName     = new System.Windows.Forms.TextBox();
            this.btnSaveFile             = new System.Windows.Forms.Button();
            this.lblPaceRecvLabel        = new System.Windows.Forms.Label();
            this.cmbPaceRecv             = new System.Windows.Forms.ComboBox();
            this.btnSetPaceRecv          = new System.Windows.Forms.Button();
            this.progressBarRecv         = new System.Windows.Forms.ProgressBar();
            this.lblProgressRecv         = new System.Windows.Forms.Label();

            this.grpFilePreview          = new System.Windows.Forms.GroupBox();
            this.rtbFileContent          = new System.Windows.Forms.RichTextBox();

            this.grpLog                  = new System.Windows.Forms.GroupBox();
            this.rtbLog                  = new System.Windows.Forms.RichTextBox();

            this.openFileDialog1         = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1         = new System.Windows.Forms.SaveFileDialog();

            this.menuStrip1.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.grpSender.SuspendLayout();
            this.grpReceiver.SuspendLayout();
            this.grpFilePreview.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();

            // ── menuStrip1 ────────────────────────────────────────────────────
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(40, 40, 80);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuItemHelp });
            this.menuStrip1.Location  = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name      = "menuStrip1";
            this.menuStrip1.Size      = new System.Drawing.Size(900, 24);

            this.menuItemHelp.ForeColor = System.Drawing.Color.White;
            this.menuItemHelp.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.menuItemHelp.Name      = "menuItemHelp";
            this.menuItemHelp.Text      = "Справка";
            this.menuItemHelp.Click    += new System.EventHandler(this.MenuItemHelp_Click);

            // ── grpConnection ─────────────────────────────────────────────────
            this.grpConnection.BackColor = System.Drawing.Color.Transparent;
            this.grpConnection.ForeColor = System.Drawing.Color.White;
            this.grpConnection.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.grpConnection.Location  = new System.Drawing.Point(8, 28);
            this.grpConnection.Size      = new System.Drawing.Size(880, 72);
            this.grpConnection.Text      = "Соединение";
            this.grpConnection.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblRole, this.lblPortInfo, this.lblStatus, this.btnConnect, this.btnDisconnect });

            this.lblRole.AutoSize  = false;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 11F);
            this.lblRole.ForeColor = System.Drawing.Color.LightCyan;
            this.lblRole.Location  = new System.Drawing.Point(8, 22);
            this.lblRole.Size      = new System.Drawing.Size(180, 22);
            this.lblRole.Text      = "Роль: —";

            this.lblPortInfo.AutoSize  = false;
            this.lblPortInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPortInfo.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblPortInfo.ForeColor = System.Drawing.Color.LightYellow;
            this.lblPortInfo.Location  = new System.Drawing.Point(200, 22);
            this.lblPortInfo.Size      = new System.Drawing.Size(300, 22);
            this.lblPortInfo.Text      = "Порт: —  |  9600 bps, 8N1";

            this.lblStatus.AutoSize  = false;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 11F);
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location  = new System.Drawing.Point(510, 22);
            this.lblStatus.Size      = new System.Drawing.Size(180, 22);
            this.lblStatus.Text      = "Не подключено";

            this.btnConnect.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 10F);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location  = new System.Drawing.Point(700, 18);
            this.btnConnect.Size      = new System.Drawing.Size(80, 30);
            this.btnConnect.Text      = "Подключить";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click    += new System.EventHandler(this.BtnConnect_Click);

            this.btnDisconnect.BackColor = System.Drawing.Color.IndianRed;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.FlatAppearance.BorderSize = 0;
            this.btnDisconnect.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 10F);
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location  = new System.Drawing.Point(790, 18);
            this.btnDisconnect.Size      = new System.Drawing.Size(82, 30);
            this.btnDisconnect.Text      = "Отключить";
            this.btnDisconnect.Enabled   = false;
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click    += new System.EventHandler(this.BtnDisconnect_Click);

            // ── grpSender ─────────────────────────────────────────────────────
            this.grpSender.BackColor = System.Drawing.Color.Transparent;
            this.grpSender.ForeColor = System.Drawing.Color.White;
            this.grpSender.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.grpSender.Location  = new System.Drawing.Point(8, 106);
            this.grpSender.Size      = new System.Drawing.Size(440, 160);
            this.grpSender.Text      = "Источник — отправка файла";
            this.grpSender.Visible   = false;
            this.grpSender.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFilePath, this.txtFilePath, this.btnBrowse, this.btnSendFile,
                this.lblPaceLabel, this.cmbPace, this.btnSetPace,
                this.progressBar, this.lblProgress });

            this.lblFilePath.AutoSize  = false;
            this.lblFilePath.BackColor = System.Drawing.Color.Transparent;
            this.lblFilePath.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblFilePath.ForeColor = System.Drawing.Color.White;
            this.lblFilePath.Location  = new System.Drawing.Point(8, 24);
            this.lblFilePath.Size      = new System.Drawing.Size(60, 20);
            this.lblFilePath.Text      = "Файл:";

            this.txtFilePath.Font      = new System.Drawing.Font("Consolas", 9F);
            this.txtFilePath.Location  = new System.Drawing.Point(70, 22);
            this.txtFilePath.Size      = new System.Drawing.Size(260, 22);
            this.txtFilePath.ReadOnly  = true;
            this.txtFilePath.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.txtFilePath.ForeColor = System.Drawing.Color.White;

            this.btnBrowse.BackColor = System.Drawing.Color.SlateBlue;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location  = new System.Drawing.Point(338, 20);
            this.btnBrowse.Size      = new System.Drawing.Size(90, 26);
            this.btnBrowse.Text      = "Обзор...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click    += new System.EventHandler(this.BtnBrowse_Click);

            this.btnSendFile.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.FlatAppearance.BorderSize = 0;
            this.btnSendFile.Font      = new System.Drawing.Font("Franklin Gothic Heavy", 11F);
            this.btnSendFile.ForeColor = System.Drawing.Color.White;
            this.btnSendFile.Location  = new System.Drawing.Point(8, 52);
            this.btnSendFile.Size      = new System.Drawing.Size(420, 32);
            this.btnSendFile.Text      = "Отправить файл";
            this.btnSendFile.Enabled   = false;
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click    += new System.EventHandler(this.BtnSendFile_Click);

            this.lblPaceLabel.AutoSize  = false;
            this.lblPaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPaceLabel.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblPaceLabel.ForeColor = System.Drawing.Color.White;
            this.lblPaceLabel.Location  = new System.Drawing.Point(8, 92);
            this.lblPaceLabel.Size      = new System.Drawing.Size(120, 20);
            this.lblPaceLabel.Text      = "Темп передачи:";

            this.cmbPace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPace.Font          = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.cmbPace.Location      = new System.Drawing.Point(132, 90);
            this.cmbPace.Size          = new System.Drawing.Size(160, 24);
            this.cmbPace.Items.AddRange(new object[] { "Медленно (500 мс)", "Нормально (100 мс)", "Быстро (10 мс)" });
            this.cmbPace.SelectedIndex = 1;

            this.btnSetPace.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSetPace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPace.FlatAppearance.BorderSize = 0;
            this.btnSetPace.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.btnSetPace.ForeColor = System.Drawing.Color.White;
            this.btnSetPace.Location  = new System.Drawing.Point(300, 88);
            this.btnSetPace.Size      = new System.Drawing.Size(128, 26);
            this.btnSetPace.Text      = "Задать темп";
            this.btnSetPace.UseVisualStyleBackColor = false;
            this.btnSetPace.Click    += new System.EventHandler(this.BtnSetPace_Click);

            this.progressBar.Location = new System.Drawing.Point(8, 124);
            this.progressBar.Size     = new System.Drawing.Size(340, 20);
            this.progressBar.Minimum  = 0;
            this.progressBar.Maximum  = 100;
            this.progressBar.Value    = 0;

            this.lblProgress.AutoSize  = false;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblProgress.ForeColor = System.Drawing.Color.LightGreen;
            this.lblProgress.Location  = new System.Drawing.Point(356, 124);
            this.lblProgress.Size      = new System.Drawing.Size(76, 20);
            this.lblProgress.Text      = "0 %";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── grpReceiver ───────────────────────────────────────────────────
            this.grpReceiver.BackColor = System.Drawing.Color.Transparent;
            this.grpReceiver.ForeColor = System.Drawing.Color.White;
            this.grpReceiver.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.grpReceiver.Location  = new System.Drawing.Point(8, 106);
            this.grpReceiver.Size      = new System.Drawing.Size(440, 160);
            this.grpReceiver.Text      = "Приёмник — приём файла";
            this.grpReceiver.Visible   = false;
            this.grpReceiver.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblReceivedFile, this.txtReceivedFileName, this.btnSaveFile,
                this.lblPaceRecvLabel, this.cmbPaceRecv, this.btnSetPaceRecv,
                this.progressBarRecv, this.lblProgressRecv });

            this.lblReceivedFile.AutoSize  = false;
            this.lblReceivedFile.BackColor = System.Drawing.Color.Transparent;
            this.lblReceivedFile.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblReceivedFile.ForeColor = System.Drawing.Color.White;
            this.lblReceivedFile.Location  = new System.Drawing.Point(8, 24);
            this.lblReceivedFile.Size      = new System.Drawing.Size(100, 20);
            this.lblReceivedFile.Text      = "Принятый файл:";

            this.txtReceivedFileName.Font      = new System.Drawing.Font("Consolas", 9F);
            this.txtReceivedFileName.Location  = new System.Drawing.Point(112, 22);
            this.txtReceivedFileName.Size      = new System.Drawing.Size(220, 22);
            this.txtReceivedFileName.ReadOnly  = true;
            this.txtReceivedFileName.BackColor = System.Drawing.Color.FromArgb(50, 50, 80);
            this.txtReceivedFileName.ForeColor = System.Drawing.Color.White;

            this.btnSaveFile.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.FlatAppearance.BorderSize = 0;
            this.btnSaveFile.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.btnSaveFile.ForeColor = System.Drawing.Color.White;
            this.btnSaveFile.Location  = new System.Drawing.Point(340, 20);
            this.btnSaveFile.Size      = new System.Drawing.Size(90, 26);
            this.btnSaveFile.Text      = "Сохранить";
            this.btnSaveFile.Enabled   = false;
            this.btnSaveFile.UseVisualStyleBackColor = false;
            this.btnSaveFile.Click    += new System.EventHandler(this.BtnSaveFile_Click);

            this.lblPaceRecvLabel.AutoSize  = false;
            this.lblPaceRecvLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPaceRecvLabel.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblPaceRecvLabel.ForeColor = System.Drawing.Color.White;
            this.lblPaceRecvLabel.Location  = new System.Drawing.Point(8, 56);
            this.lblPaceRecvLabel.Size      = new System.Drawing.Size(120, 20);
            this.lblPaceRecvLabel.Text      = "Управление темпом:";

            this.cmbPaceRecv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaceRecv.Font          = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.cmbPaceRecv.Location      = new System.Drawing.Point(132, 54);
            this.cmbPaceRecv.Size          = new System.Drawing.Size(160, 24);
            this.cmbPaceRecv.Items.AddRange(new object[] { "Медленно (500 мс)", "Нормально (100 мс)", "Быстро (10 мс)" });
            this.cmbPaceRecv.SelectedIndex = 1;

            this.btnSetPaceRecv.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSetPaceRecv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPaceRecv.FlatAppearance.BorderSize = 0;
            this.btnSetPaceRecv.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.btnSetPaceRecv.ForeColor = System.Drawing.Color.White;
            this.btnSetPaceRecv.Location  = new System.Drawing.Point(300, 52);
            this.btnSetPaceRecv.Size      = new System.Drawing.Size(128, 26);
            this.btnSetPaceRecv.Text      = "Задать темп";
            this.btnSetPaceRecv.UseVisualStyleBackColor = false;
            this.btnSetPaceRecv.Click    += new System.EventHandler(this.BtnSetPaceRecv_Click);

            this.progressBarRecv.Location = new System.Drawing.Point(8, 88);
            this.progressBarRecv.Size     = new System.Drawing.Size(340, 20);
            this.progressBarRecv.Minimum  = 0;
            this.progressBarRecv.Maximum  = 100;
            this.progressBarRecv.Value    = 0;

            this.lblProgressRecv.AutoSize  = false;
            this.lblProgressRecv.BackColor = System.Drawing.Color.Transparent;
            this.lblProgressRecv.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F);
            this.lblProgressRecv.ForeColor = System.Drawing.Color.LightGreen;
            this.lblProgressRecv.Location  = new System.Drawing.Point(356, 88);
            this.lblProgressRecv.Size      = new System.Drawing.Size(76, 20);
            this.lblProgressRecv.Text      = "0 %";
            this.lblProgressRecv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── grpFilePreview ────────────────────────────────────────────────
            this.grpFilePreview.BackColor = System.Drawing.Color.Transparent;
            this.grpFilePreview.ForeColor = System.Drawing.Color.White;
            this.grpFilePreview.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.grpFilePreview.Location  = new System.Drawing.Point(456, 106);
            this.grpFilePreview.Size      = new System.Drawing.Size(436, 160);
            this.grpFilePreview.Text      = "Просмотр содержимого файла";
            this.grpFilePreview.Controls.Add(this.rtbFileContent);

            this.rtbFileContent.BackColor  = System.Drawing.Color.FromArgb(20, 20, 40);
            this.rtbFileContent.ForeColor  = System.Drawing.Color.LightGreen;
            this.rtbFileContent.Font       = new System.Drawing.Font("Consolas", 9F);
            this.rtbFileContent.Location   = new System.Drawing.Point(4, 20);
            this.rtbFileContent.Size       = new System.Drawing.Size(428, 132);
            this.rtbFileContent.ReadOnly   = true;
            this.rtbFileContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.rtbFileContent.WordWrap   = false;

            // ── grpLog ────────────────────────────────────────────────────────
            this.grpLog.BackColor = System.Drawing.Color.Transparent;
            this.grpLog.ForeColor = System.Drawing.Color.White;
            this.grpLog.Font      = new System.Drawing.Font("Franklin Gothic Medium Cond", 11F);
            this.grpLog.Location  = new System.Drawing.Point(8, 272);
            this.grpLog.Size      = new System.Drawing.Size(884, 280);
            this.grpLog.Text      = "Служебный журнал (кадры / события)";
            this.grpLog.Controls.Add(this.rtbLog);

            this.rtbLog.BackColor  = System.Drawing.Color.FromArgb(15, 15, 30);
            this.rtbLog.ForeColor  = System.Drawing.Color.LightGray;
            this.rtbLog.Font       = new System.Drawing.Font("Consolas", 9F);
            this.rtbLog.Location   = new System.Drawing.Point(4, 20);
            this.rtbLog.Size       = new System.Drawing.Size(876, 252);
            this.rtbLog.ReadOnly   = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            // ── openFileDialog1 ───────────────────────────────────────────────
            this.openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            this.openFileDialog1.Title  = "Выберите файл для отправки";

            // ── saveFileDialog1 ───────────────────────────────────────────────
            this.saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            this.saveFileDialog1.Title  = "Сохранить принятый файл";

            // ── ChatForm ──────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(25, 25, 55);
            this.ClientSize          = new System.Drawing.Size(900, 562);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip       = this.menuStrip1;
            this.MaximizeBox         = false;
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Передача файлов по RS232C — Вариант 11";
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.grpSender);
            this.Controls.Add(this.grpReceiver);
            this.Controls.Add(this.grpFilePreview);
            this.Controls.Add(this.grpLog);
            this.Load += new System.EventHandler(this.ChatForm_Load);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpSender.ResumeLayout(false);
            this.grpReceiver.ResumeLayout(false);
            this.grpFilePreview.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── Controls ──────────────────────────────────────────────────────────
        private System.Windows.Forms.MenuStrip          menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem  menuItemHelp;

        private System.Windows.Forms.GroupBox  grpConnection;
        private System.Windows.Forms.Label     lblRole;
        private System.Windows.Forms.Label     lblPortInfo;
        private System.Windows.Forms.Label     lblStatus;
        private System.Windows.Forms.Button    btnConnect;
        private System.Windows.Forms.Button    btnDisconnect;

        private System.Windows.Forms.GroupBox  grpSender;
        private System.Windows.Forms.Label     lblFilePath;
        private System.Windows.Forms.TextBox   txtFilePath;
        private System.Windows.Forms.Button    btnBrowse;
        private System.Windows.Forms.Button    btnSendFile;
        private System.Windows.Forms.Label     lblPaceLabel;
        private System.Windows.Forms.ComboBox  cmbPace;
        private System.Windows.Forms.Button    btnSetPace;
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
