namespace SZOH_Launcher
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GameDirecotry = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.News = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Opros = new System.Windows.Forms.PictureBox();
            this.AutoRunCheckBox = new System.Windows.Forms.PictureBox();
            this.OFDButton = new System.Windows.Forms.PictureBox();
            this.GoGameButton = new System.Windows.Forms.PictureBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.Hide = new System.Windows.Forms.PictureBox();
            this.Top = new System.Windows.Forms.PictureBox();
            this.CheckUpdateButton = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoRunCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OFDButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoGameButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckUpdateButton)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameDirecotry
            // 
            this.GameDirecotry.Font = new System.Drawing.Font("Capture it 2", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameDirecotry.Location = new System.Drawing.Point(5, 442);
            this.GameDirecotry.Name = "GameDirecotry";
            this.GameDirecotry.ReadOnly = true;
            this.GameDirecotry.Size = new System.Drawing.Size(259, 21);
            this.GameDirecotry.TabIndex = 1;
            this.GameDirecotry.Text = "Укажите путь до лаунчера игры";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.SystemColors.Control;
            this.Title.Font = new System.Drawing.Font("Batang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(2, 23);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(142, 12);
            this.Title.TabIndex = 7;
            this.Title.Text = "Launcher for SZOHack";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Batang", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(277, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 11);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Batang", 9.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(211, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Автозапуск";
            // 
            // News
            // 
            this.News.BackColor = System.Drawing.Color.White;
            this.News.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.News.Font = new System.Drawing.Font("Batang", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.News.Location = new System.Drawing.Point(6, 22);
            this.News.Name = "News";
            this.News.ReadOnly = true;
            this.News.Size = new System.Drawing.Size(289, 318);
            this.News.TabIndex = 16;
            this.News.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.News);
            this.groupBox1.Font = new System.Drawing.Font("Batang", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(5, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 346);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новости";
            // 
            // Opros
            // 
            this.Opros.Image = global::SZOH_Launcher.Properties.Resources.Opros;
            this.Opros.Location = new System.Drawing.Point(5, 416);
            this.Opros.Name = "Opros";
            this.Opros.Size = new System.Drawing.Size(85, 20);
            this.Opros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Opros.TabIndex = 18;
            this.Opros.TabStop = false;
            this.Opros.Visible = false;
            this.Opros.Click += new System.EventHandler(this.Opros_Click);
            this.Opros.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            this.Opros.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp_1);
            // 
            // AutoRunCheckBox
            // 
            this.AutoRunCheckBox.Image = global::SZOH_Launcher.Properties.Resources.CheckBox;
            this.AutoRunCheckBox.Location = new System.Drawing.Point(291, 419);
            this.AutoRunCheckBox.Name = "AutoRunCheckBox";
            this.AutoRunCheckBox.Size = new System.Drawing.Size(15, 15);
            this.AutoRunCheckBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.AutoRunCheckBox.TabIndex = 13;
            this.AutoRunCheckBox.TabStop = false;
            this.AutoRunCheckBox.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // OFDButton
            // 
            this.OFDButton.Image = global::SZOH_Launcher.Properties.Resources.Directory;
            this.OFDButton.Location = new System.Drawing.Point(269, 440);
            this.OFDButton.Name = "OFDButton";
            this.OFDButton.Size = new System.Drawing.Size(37, 25);
            this.OFDButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.OFDButton.TabIndex = 10;
            this.OFDButton.TabStop = false;
            this.OFDButton.Click += new System.EventHandler(this.OFDialog_Click);
            this.OFDButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.OFDButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // GoGameButton
            // 
            this.GoGameButton.Image = global::SZOH_Launcher.Properties.Resources.GoGame;
            this.GoGameButton.Location = new System.Drawing.Point(4, 468);
            this.GoGameButton.Name = "GoGameButton";
            this.GoGameButton.Size = new System.Drawing.Size(302, 32);
            this.GoGameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GoGameButton.TabIndex = 9;
            this.GoGameButton.TabStop = false;
            this.GoGameButton.Click += new System.EventHandler(this.Go_Game_Click);
            this.GoGameButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.GoGameButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Close
            // 
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.Location = new System.Drawing.Point(288, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(20, 20);
            this.Close.TabIndex = 5;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // Hide
            // 
            this.Hide.Image = global::SZOH_Launcher.Properties.Resources.hide;
            this.Hide.Location = new System.Drawing.Point(263, 0);
            this.Hide.Name = "Hide";
            this.Hide.Size = new System.Drawing.Size(20, 20);
            this.Hide.TabIndex = 3;
            this.Hide.TabStop = false;
            this.Hide.Click += new System.EventHandler(this.Hide_Click);
            // 
            // Top
            // 
            this.Top.Image = global::SZOH_Launcher.Properties.Resources.top;
            this.Top.Location = new System.Drawing.Point(0, 0);
            this.Top.Name = "Top";
            this.Top.Size = new System.Drawing.Size(309, 20);
            this.Top.TabIndex = 6;
            this.Top.TabStop = false;
            this.Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Top_MouseDown);
            this.Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Top_MouseMove);
            this.Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Top_MouseUp);
            // 
            // CheckUpdateButton
            // 
            this.CheckUpdateButton.Image = global::SZOH_Launcher.Properties.Resources.CheckUpdate;
            this.CheckUpdateButton.Location = new System.Drawing.Point(4, 38);
            this.CheckUpdateButton.Name = "CheckUpdateButton";
            this.CheckUpdateButton.Size = new System.Drawing.Size(140, 20);
            this.CheckUpdateButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CheckUpdateButton.TabIndex = 15;
            this.CheckUpdateButton.TabStop = false;
            this.CheckUpdateButton.Click += new System.EventHandler(this.pictureBox4_Click);
            this.CheckUpdateButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseDown);
            this.CheckUpdateButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem2.Text = "Показать";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "Выход";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Область уведомлений";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 505);
            this.Controls.Add(this.Opros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CheckUpdateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AutoRunCheckBox);
            this.Controls.Add(this.OFDButton);
            this.Controls.Add(this.GoGameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Hide);
            this.Controls.Add(this.GameDirecotry);
            this.Controls.Add(this.Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Opros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoRunCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OFDButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoGameButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckUpdateButton)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private int CountRun;
        private bool On;
        private System.Windows.Forms.TextBox GameDirecotry;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox Hide;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.PictureBox Top;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox GoGameButton;
        private System.Windows.Forms.PictureBox OFDButton;
        private System.Windows.Forms.PictureBox AutoRunCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox News;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox Opros;
        private System.Windows.Forms.PictureBox CheckUpdateButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

