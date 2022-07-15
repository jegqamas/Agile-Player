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
using System;
using System.Windows.Forms;
using APlayer.Core;

namespace APlayer
{
    public partial class FormSettings : Form
    {
        const string LABEL_CPS = "Clock Per Second (CPS): ";
        const string LABEL_BUF = "Buffer Size In KB: ";

        private int cps_old;
        private int buf_old;
        public FormSettings()
        {
            InitializeComponent();

            checkBox_save_list_on_exit.Checked = Program.AppSettings.SaveListOnExit;
            checkBox1.Checked = APMain.CoreSettings.AutoSwitchTargetSettingsToMatchInput;
            cps_old = trackBar_cps.Value = APMain.CoreSettings.CPS_TargetCPS;
            buf_old = trackBar_buffer_size.Value = APMain.CoreSettings.Audio_RenderBufferInKB;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;

            radioButton_db_source.Checked = Program.AppSettings.DBMeterFromSource;
            radioButton1.Checked = !Program.AppSettings.DBMeterFromSource;
        }
        private void ApplySettings()
        {
            APMain.CoreSettings.CPS_TargetCPS = trackBar_cps.Value;
            APMain.CoreSettings.Audio_RenderBufferInKB = trackBar_buffer_size.Value;
            APCore.SetTargetCPS(APMain.CoreSettings.CPS_TargetCPS);
            Program.MainForm.ResetAudioRenderer();
        }
        // Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            if (APMain.CoreSettings.CPS_TargetCPS != cps_old || APMain.CoreSettings.Audio_RenderBufferInKB != buf_old)
            {
                APMain.CoreSettings.CPS_TargetCPS = cps_old;
                APMain.CoreSettings.Audio_RenderBufferInKB = buf_old;
                APCore.SetTargetCPS(APMain.CoreSettings.CPS_TargetCPS);
                Program.MainForm.ResetAudioRenderer();
            }
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Program.AppSettings.SaveListOnExit = checkBox_save_list_on_exit.Checked;
            APMain.CoreSettings.AutoSwitchTargetSettingsToMatchInput = checkBox1.Checked;
            APMain.CoreSettings.CPS_TargetCPS = trackBar_cps.Value;
            APMain.CoreSettings.Audio_RenderBufferInKB = trackBar_buffer_size.Value;
            Program.AppSettings.DBMeterFromSource = radioButton_db_source.Checked;

            if (APMain.CoreSettings.CPS_TargetCPS != cps_old || APMain.CoreSettings.Audio_RenderBufferInKB != buf_old)
                ApplySettings();
            Close();
        }
        // apply settings
        private void button3_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }
        private void trackBar_cps_Scroll(object sender, EventArgs e)
        {
            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
        }
        private void trackBar_buffer_size_Scroll(object sender, EventArgs e)
        {
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;
        }
        // low
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trackBar_cps.Value = 26;
            trackBar_buffer_size.Value = 7;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;
        }
        // Good
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /* trackBar_cps.Value = 47;
             trackBar_buffer_size.Value = 10;

             label_cps.Text = LABEL_CPS + trackBar_cps.Value;
             label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;*/
            trackBar_cps.Value = 37;
            trackBar_buffer_size.Value = 10;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;
        }
        // Normal
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trackBar_cps.Value = 47;
            trackBar_buffer_size.Value = 15;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;
            /* trackBar_cps.Value = 56;// 59
             trackBar_buffer_size.Value = 23;


             label_cps.Text = LABEL_CPS + trackBar_cps.Value;
             label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;*/
        }
        // High
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*trackBar_cps.Value = 62;
            trackBar_buffer_size.Value = 27;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;*/

            trackBar_cps.Value = 61;
            trackBar_buffer_size.Value = 25;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trackBar_cps.Value = trackBar_cps.Maximum;
            trackBar_buffer_size.Value = trackBar_buffer_size.Maximum;

            label_cps.Text = LABEL_CPS + trackBar_cps.Value;
            label_buffer.Text = LABEL_BUF + trackBar_buffer_size.Value;
        }
    }
}
