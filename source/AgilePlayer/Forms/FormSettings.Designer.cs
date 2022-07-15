// This file is part of Agile Player
// An Audio player with downsampler, upsampler and bit-converter
// written in C#.
// 
// Copyright © Alaa Ibrahim Hadid 2022
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// Author email: mailto:alaahadidfreeware@gmail.com
//
namespace APlayer
{
    partial class FormSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.checkBox_save_list_on_exit = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_cps = new System.Windows.Forms.Label();
            this.trackBar_cps = new System.Windows.Forms.TrackBar();
            this.trackBar_buffer_size = new System.Windows.Forms.TrackBar();
            this.label_buffer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_db_source = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_buffer_size)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_save_list_on_exit
            // 
            this.checkBox_save_list_on_exit.AutoSize = true;
            this.checkBox_save_list_on_exit.Location = new System.Drawing.Point(24, 14);
            this.checkBox_save_list_on_exit.Name = "checkBox_save_list_on_exit";
            this.checkBox_save_list_on_exit.Size = new System.Drawing.Size(398, 24);
            this.checkBox_save_list_on_exit.TabIndex = 0;
            this.checkBox_save_list_on_exit.Text = "Save latest list on exit (to open that list at next start)";
            this.checkBox_save_list_on_exit.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(567, 64);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Auto switch target playback settings (i.e. Frequency, Channels Number and \r\nBits " +
    "Per Sample) when Media file is opened, to match that opened media \r\nspecificatio" +
    "ns.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(543, 562);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_cps
            // 
            this.label_cps.AutoSize = true;
            this.label_cps.Location = new System.Drawing.Point(24, 159);
            this.label_cps.Name = "label_cps";
            this.label_cps.Size = new System.Drawing.Size(207, 20);
            this.label_cps.TabIndex = 4;
            this.label_cps.Text = "Clock Per Second (CPS): 44";
            // 
            // trackBar_cps
            // 
            this.trackBar_cps.Location = new System.Drawing.Point(24, 182);
            this.trackBar_cps.Maximum = 64;
            this.trackBar_cps.Minimum = 15;
            this.trackBar_cps.Name = "trackBar_cps";
            this.trackBar_cps.Size = new System.Drawing.Size(567, 69);
            this.trackBar_cps.TabIndex = 5;
            this.toolTip1.SetToolTip(this.trackBar_cps, resources.GetString("trackBar_cps.ToolTip"));
            this.trackBar_cps.Value = 44;
            this.trackBar_cps.Scroll += new System.EventHandler(this.trackBar_cps_Scroll);
            // 
            // trackBar_buffer_size
            // 
            this.trackBar_buffer_size.Location = new System.Drawing.Point(24, 277);
            this.trackBar_buffer_size.Maximum = 43;
            this.trackBar_buffer_size.Minimum = 7;
            this.trackBar_buffer_size.Name = "trackBar_buffer_size";
            this.trackBar_buffer_size.Size = new System.Drawing.Size(567, 69);
            this.trackBar_buffer_size.TabIndex = 7;
            this.toolTip1.SetToolTip(this.trackBar_buffer_size, "Higher the value better quality but effect performance, also may\r\naffect latency " +
        "of seeking, opening media...etc\r\nIt is recommended to set it lower than 30 KB.");
            this.trackBar_buffer_size.Value = 9;
            this.trackBar_buffer_size.Scroll += new System.EventHandler(this.trackBar_buffer_size_Scroll);
            // 
            // label_buffer
            // 
            this.label_buffer.AutoSize = true;
            this.label_buffer.Location = new System.Drawing.Point(24, 254);
            this.label_buffer.Name = "label_buffer";
            this.label_buffer.Size = new System.Drawing.Size(148, 20);
            this.label_buffer.TabIndex = 6;
            this.label_buffer.Text = "Buffer Size In KB: 9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "CPS and Buffer Size preset (affect quality and performance):";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(24, 375);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(38, 20);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Low";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(68, 375);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(49, 20);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Good";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(123, 375);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(242, 20);
            this.linkLabel3.TabIndex = 11;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Normal (Default. Recommended)";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(543, 365);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 41);
            this.button3.TabIndex = 12;
            this.button3.Text = "&Apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(371, 375);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(42, 20);
            this.linkLabel4.TabIndex = 13;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "High";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(434, 375);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(38, 20);
            this.linkLabel5.TabIndex = 14;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Max";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "DB Meter display values from:";
            // 
            // radioButton_db_source
            // 
            this.radioButton_db_source.AutoSize = true;
            this.radioButton_db_source.Checked = true;
            this.radioButton_db_source.Location = new System.Drawing.Point(28, 475);
            this.radioButton_db_source.Name = "radioButton_db_source";
            this.radioButton_db_source.Size = new System.Drawing.Size(187, 24);
            this.radioButton_db_source.TabIndex = 16;
            this.radioButton_db_source.TabStop = true;
            this.radioButton_db_source.Text = "Source file when read";
            this.toolTip1.SetToolTip(this.radioButton_db_source, "The DB meter will show values from source file regardless of the target settings." +
        "");
            this.radioButton_db_source.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(221, 475);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(407, 24);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.Text = "After processing audio using target playback settings";
            this.toolTip1.SetToolTip(this.radioButton1, "The DB meter will show values from source file after processing audio applying th" +
        "e target settings.\r\n");
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 695);
            this.ControlBox = false;
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioButton_db_source);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_buffer_size);
            this.Controls.Add(this.label_buffer);
            this.Controls.Add(this.trackBar_cps);
            this.Controls.Add(this.label_cps);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox_save_list_on_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_buffer_size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_save_list_on_exit;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_cps;
        private System.Windows.Forms.TrackBar trackBar_cps;
        private System.Windows.Forms.TrackBar trackBar_buffer_size;
        private System.Windows.Forms.Label label_buffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_db_source;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}