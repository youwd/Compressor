﻿
namespace Compressor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.start = new System.Windows.Forms.Button();
            this.labelCatalog = new System.Windows.Forms.Label();
            this.buttonOpenCatalog = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBoxVideo = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxImage = new System.Windows.Forms.ListBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxProcessor = new System.Windows.Forms.ComboBox();
            this.checkBoxGPU = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(687, 779);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(147, 51);
            this.start.TabIndex = 0;
            this.start.Text = "开始";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // labelCatalog
            // 
            this.labelCatalog.AutoSize = true;
            this.labelCatalog.Location = new System.Drawing.Point(25, 53);
            this.labelCatalog.Name = "labelCatalog";
            this.labelCatalog.Size = new System.Drawing.Size(130, 24);
            this.labelCatalog.TabIndex = 1;
            this.labelCatalog.Text = "文件目录：";
            // 
            // buttonOpenCatalog
            // 
            this.buttonOpenCatalog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonOpenCatalog.Location = new System.Drawing.Point(152, 40);
            this.buttonOpenCatalog.Name = "buttonOpenCatalog";
            this.buttonOpenCatalog.Size = new System.Drawing.Size(682, 51);
            this.buttonOpenCatalog.TabIndex = 2;
            this.buttonOpenCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenCatalog.UseVisualStyleBackColor = false;
            this.buttonOpenCatalog.Click += new System.EventHandler(this.buttonOpenCatalog_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(21, 111);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 548);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxVideo);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabPage1.Size = new System.Drawing.Size(808, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "视频";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBoxVideo
            // 
            this.listBoxVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxVideo.FormattingEnabled = true;
            this.listBoxVideo.HorizontalScrollbar = true;
            this.listBoxVideo.ItemHeight = 24;
            this.listBoxVideo.Location = new System.Drawing.Point(3, 3);
            this.listBoxVideo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.listBoxVideo.Name = "listBoxVideo";
            this.listBoxVideo.Size = new System.Drawing.Size(802, 498);
            this.listBoxVideo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxImage);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图片";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxImage
            // 
            this.listBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxImage.FormattingEnabled = true;
            this.listBoxImage.HorizontalScrollbar = true;
            this.listBoxImage.ItemHeight = 24;
            this.listBoxImage.Location = new System.Drawing.Point(3, 3);
            this.listBoxImage.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.listBoxImage.Name = "listBoxImage";
            this.listBoxImage.Size = new System.Drawing.Size(802, 495);
            this.listBoxImage.TabIndex = 0;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(29, 672);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(130, 24);
            this.labelMessage.TabIndex = 4;
            this.labelMessage.Text = "正在处理：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 719);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(801, 35);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 792);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "线程数：";
            // 
            // comboBoxProcessor
            // 
            this.comboBoxProcessor.FormattingEnabled = true;
            this.comboBoxProcessor.Location = new System.Drawing.Point(145, 787);
            this.comboBoxProcessor.Name = "comboBoxProcessor";
            this.comboBoxProcessor.Size = new System.Drawing.Size(121, 32);
            this.comboBoxProcessor.TabIndex = 7;
            // 
            // checkBoxGPU
            // 
            this.checkBoxGPU.AutoSize = true;
            this.checkBoxGPU.Location = new System.Drawing.Point(331, 791);
            this.checkBoxGPU.Name = "checkBoxGPU";
            this.checkBoxGPU.Size = new System.Drawing.Size(174, 28);
            this.checkBoxGPU.TabIndex = 8;
            this.checkBoxGPU.Text = "是否使用GPU";
            this.checkBoxGPU.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 862);
            this.Controls.Add(this.checkBoxGPU);
            this.Controls.Add(this.comboBoxProcessor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonOpenCatalog);
            this.Controls.Add(this.labelCatalog);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "视频图片压缩器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label labelCatalog;
        private System.Windows.Forms.Button buttonOpenCatalog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listBoxVideo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxImage;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProcessor;
        private System.Windows.Forms.CheckBox checkBoxGPU;
    }
}

