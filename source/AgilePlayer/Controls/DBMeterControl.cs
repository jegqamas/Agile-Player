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
using System.Drawing;
using System.Windows.Forms;

namespace APlayer
{
    public partial class DBMeterControl : Control
    {
        public DBMeterControl()
        {
            InitializeComponent();

            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);

            MaxDB = -20 * Math.Log10(1.0 / int.MaxValue);// Max of 32 bit ?
            db_spacing = 13;
            surr_thick = 7;
            draw_surr = true;
            draw_texts = true;
            draw_lines = true;
            bar_coloring_sp = 26;
            SetValues(0, 0, 16);
        }
        private bool draw_surr;
        private bool draw_texts;
        private bool draw_lines;
        public bool IsStereo { get; set; }
        public double MaxDB { get; set; }
        private double current_max_db;
        private int db_spacing = 40;
        private int surr_thick;
        private int bar_coloring_sp;
        double channelLeft;
        double channelRight;

        public void LoadSettings()
        {
            draw_texts = Program.AppSettings.DBMeterShowTexts;
            draw_lines = Program.AppSettings.DBMeterShowLines;
            draw_surr = Program.AppSettings.DBMeterShowSurrounding;
        }
        public void SaveSettings()
        {
            Program.AppSettings.DBMeterShowTexts = draw_texts;
            Program.AppSettings.DBMeterShowLines = draw_lines;
            Program.AppSettings.DBMeterShowSurrounding = draw_surr;
        }
        public void SetValues(double channelLeft_sample, double channelRight_sample, int bits_per_sample)
        {
            // More information about db fix can be found here <https://github.com/jegqamas/Docs/blob/main/Audio%20And%20DB.txt>. 

            switch (bits_per_sample)
            {
                case 8:
                    {
                        int left_val = (int)channelLeft_sample - sbyte.MaxValue;
                        int right_val = (int)channelRight_sample - sbyte.MaxValue;

                        MaxDB = 20 * Math.Log10(sbyte.MaxValue);
                        MaxDB += 4;

                        current_max_db = 20 * Math.Log10(sbyte.MaxValue);//  20 * Log10( [sbyte.MaxValue] / 1)

                        channelLeft = 20 * Math.Log10(Math.Abs(left_val));//  20 * Log10( [left_val] / 1)
                        channelRight = 20 * Math.Log10(Math.Abs(right_val));
                        break;
                    }
                case 16:
                    {
                        MaxDB = 20 * Math.Log10(short.MaxValue);
                        MaxDB += 4;

                        current_max_db = 20 * Math.Log10(short.MaxValue);

                        // No need to calculate the case of 0 sample which is infinity , it will be 0 in c# anyway ..
                        channelLeft = 20 * Math.Log10(Math.Abs(channelLeft_sample));
                        channelRight = 20 * Math.Log10(Math.Abs(channelRight_sample));
                        break;
                    }
                case 24:
                    {
                        MaxDB = 20 * Math.Log10(8388607);
                        MaxDB += 4;

                        current_max_db = 20 * Math.Log10(8388607);

                        channelLeft = 20 * Math.Log10(Math.Abs(channelLeft_sample));
                        channelRight = 20 * Math.Log10(Math.Abs(channelRight_sample));
                        break;
                    }
                case 32:
                    {

                        MaxDB = 20 * Math.Log10(int.MaxValue);
                        MaxDB += 4;

                        current_max_db = 20 * Math.Log10(int.MaxValue);

                        channelLeft = 20 * Math.Log10(Math.Abs(channelLeft_sample));
                        channelRight = 20 * Math.Log10(Math.Abs(channelRight_sample));
                        break;
                    }
            }

            Invalidate();
        }
        private int dbToPixel(double db)
        {
            return (int)((db * Height) / MaxDB);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (IsStereo)
            {
                // Draw both channels
                int left = dbToPixel(channelLeft);
                int right = dbToPixel(channelRight);
                int max = dbToPixel(current_max_db);

                for (int i = 0; i < left; i++)
                {
                    int y = Height - i;

                    if (y < bar_coloring_sp - 6)
                    {
                        pe.Graphics.DrawLine(Pens.Red, 0, y, Width / 2, y);
                    }
                    else if (y > Height - bar_coloring_sp)
                    {
                        pe.Graphics.DrawLine(Pens.YellowGreen, 0, y, Width / 2, y);
                    }
                    else
                    {
                        pe.Graphics.DrawLine(Pens.MediumSeaGreen, 0, y, Width / 2, y);
                    }
                }
                for (int i = 0; i < right; i++)
                {
                    int y = Height - i;

                    if (y < bar_coloring_sp - 6)
                    {
                        pe.Graphics.DrawLine(Pens.Red, Width / 2, y, Width, y);
                    }
                    else if (y > Height - bar_coloring_sp)
                    {
                        pe.Graphics.DrawLine(Pens.YellowGreen, Width / 2, y, Width, y);
                    }
                    else
                    {
                        pe.Graphics.DrawLine(Pens.MediumSeaGreen, Width / 2, y, Width, y);
                    }
                }
            }
            else
            {
                int left = dbToPixel(channelLeft);
                //pe.Graphics.FillRectangle(Brushes.MediumSeaGreen, new Rectangle(0, Height - left, Width, left));

                for (int i = 0; i < left; i++)
                {
                    int y = Height - i;

                    if (y < bar_coloring_sp - 6)
                    {
                        pe.Graphics.DrawLine(Pens.Red, 0, y, Width, y);
                    }
                    else if (y > Height - bar_coloring_sp)
                    {
                        pe.Graphics.DrawLine(Pens.YellowGreen, 0, y, Width, y);
                    }
                    else
                    {
                        pe.Graphics.DrawLine(Pens.MediumSeaGreen, 0, y, Width, y);
                    }
                }
            }

            int space = db_spacing;
            int dd = (int)((current_max_db * Height) / MaxDB);

            if (draw_surr)
            {
                pe.Graphics.FillRectangle(Brushes.LightGray, 0, 0, surr_thick, Height);
                pe.Graphics.DrawLine(Pens.Black, surr_thick, 0, surr_thick, Height);

                pe.Graphics.FillRectangle(Brushes.LightGray, Width - surr_thick - 1, 0, surr_thick, Height);
                pe.Graphics.DrawLine(Pens.Black, Width - surr_thick - 1, 0, Width - surr_thick - 1, Height);

                pe.Graphics.DrawLine(Pens.Black, 0, Height - dd, Width, Height - dd);
                pe.Graphics.FillRectangle(Brushes.LightGray, 0, 0, Width, Height - dd);
            }

            //pe.Graphics.DrawString(current_max_db.ToString("F0") + " dB", Font, Brushes.Black, 1, 0);

            for (double i = 0; i <= MaxDB; i++)
            {
                dd = (int)((i * Height) / MaxDB);

                if (dd - space >= 0)
                {
                    if (draw_lines)
                        pe.Graphics.DrawLine(Pens.Black, 0, Height - dd, Width, Height - dd);

                    if (Height - dd - 13 >= 0 && draw_texts)
                        pe.Graphics.DrawString(((int)i).ToString("D2") + " dB", Font, Brushes.Black, draw_surr ? surr_thick : 1, Height - dd - 13);

                    space = dd + db_spacing;
                }


            }
            if (IsStereo)
            {
                pe.Graphics.DrawLine(Pens.Black, Width / 2, 0, Width / 2, Height);
                if (draw_texts)
                {
                    pe.Graphics.DrawString("Left", Font, Brushes.Black, draw_surr ? surr_thick : 1, Height - 14);
                    pe.Graphics.DrawString("Right", Font, Brushes.Black, (Width / 2) + 1, Height - 14);
                }
            }

            pe.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);



        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                draw_texts = !draw_texts;
            }
            if (e.Button == MouseButtons.Right)
            {
                draw_lines = !draw_lines;
            }
            if (e.Button == MouseButtons.Middle)
            {
                draw_surr = !draw_surr;
            }
        }
    }
}
