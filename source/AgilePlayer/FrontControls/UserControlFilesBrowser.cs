﻿// This file is part of Agile Player
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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using APlayer.Core;
using MLV;

namespace APlayer
{
    public partial class UserControlFilesBrowser : UserControl
    {
        public UserControlFilesBrowser()
        {
            InitializeComponent();

            APCore.EndOfSourceReached += APCore_EndOfSourceReached;
            list_view = new ManagedListView();
            list_view.DrawSubItem += List_view_DrawSubItem;
            list_view.ItemDoubleClick += List_view_ItemDoubleClick;
            list_view.BackColor = Color.White;
            this.Controls.Add(list_view);

            list_view.Dock = DockStyle.Fill;

            list_view.AllowDrop = true;
            list_view.DragDrop += List_view_DragDrop;
            list_view.DragEnter += List_view_DragEnter;
            list_view.DragOver += List_view_DragOver;
            list_view.ColumnClicked += List_view_ColumnClicked;
            list_view.AllowColumnsReorder = false;
            list_view.AllowItemsDragAndDrop = true;
            list_view.AutoSetWheelScrollSpeed = true;
            list_view.ChangeColumnSortModeWhenClick = false;
            list_view.ColumnClickColor = System.Drawing.Color.PaleVioletRed;
            list_view.ColumnColor = System.Drawing.Color.White;
            list_view.ColumnHighlightColor = Color.White;
            list_view.Dock = System.Windows.Forms.DockStyle.Fill;
            list_view.DrawHighlight = true;
            list_view.ItemHighlightColor = Color.LightSteelBlue;
            list_view.ItemMouseOverColor = System.Drawing.Color.WhiteSmoke;
            list_view.ItemSpecialColor = System.Drawing.Color.YellowGreen;
            list_view.Location = new System.Drawing.Point(0, 33);
            list_view.Name = "managedListView1";
            list_view.ShowItemInfoOnThumbnailMode = true;
            list_view.ShowSubItemToolTip = true;
            list_view.StretchThumbnailsToFit = false;
            list_view.TabIndex = 1;
            list_view.ThunmbnailsHeight = 36;
            list_view.ThunmbnailsWidth = 36;
            list_view.ViewMode = MLV.ManagedListViewViewMode.Details;
            list_view.WheelScrollSpeed = 20;
            list_view.ItemMultiSelect = true;

            RefreshColumns();
        }

        private int current_song_index = 0;
        private string current_file_in_play = "";
        private APEntryPlaylist current_pl;
        private ManagedListView list_view;

        public void OpenFiles(string[] media_files, bool auto_play, bool add_to_list = false)
        {
            if (!add_to_list)
                list_view.Items.Clear();

            foreach (string file in media_files)
            {
                // 1 name
                string name = Path.GetFileName(file);

                ManagedListViewItem it = new ManagedListViewItem();

                ManagedListViewSubItem subItem = new ManagedListViewSubItem();
                subItem.Text = name;
                subItem.DrawMode = ManagedListViewItemDrawMode.UserDraw;
                subItem.ColumnID = "name";
                it.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.Text = GetFileSize(file);
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.ColumnID = "size";
                it.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.Text = Path.GetExtension(file);
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.ColumnID = "file type";
                it.SubItems.Add(subItem);

                subItem = new ManagedListViewSubItem();
                subItem.Text = file;
                subItem.DrawMode = ManagedListViewItemDrawMode.Text;
                subItem.ColumnID = "path";
                it.SubItems.Add(subItem);

                it.Tag = file;
                list_view.Items.Add(it);
            }
            list_view.RefreshScrollBarsView();
            current_song_index = -1;
            if (auto_play)
                PlayNext();
        }
        private bool OpenDragedArgs(string[] args, bool add_to_list)
        {
            // Open from args
            bool args_opened = false;
            if (args != null)
            {
                if (args.Length > 0)
                {
                    List<string> args_files = new List<string>();
                    string m3u_list = "";

                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i] != "")
                        {
                            if (FormatsManager.IsFileSupportedFormat(args[i]))
                            {
                                args_files.Add(args[i]);
                            }
                            else if (Path.GetExtension(args[i]).ToLower() == ".m3u")
                            {
                                m3u_list = args[i];
                            }
                        }
                    }

                    if (args_files.Count > 0)
                    {
                        OpenFiles(args_files.ToArray(), !add_to_list, add_to_list);
                        args_opened = true;
                    }
                    else if (m3u_list != "")
                    {
                        OpenMU3List(m3u_list, true);
                        args_opened = true;
                    }
                }
            }
            return args_opened;
        }
        private void RefreshColumns()
        {
            list_view.Columns.Clear();
            current_pl = new APEntryPlaylist();
            current_pl.BuildDefaultColumns(new string[] { });

            foreach (ColumnItem column in current_pl.Columns)
            {
                if (column.Visible)
                {
                    ManagedListViewColumn listColumn = new ManagedListViewColumn();
                    listColumn.HeaderText = column.ColumnName;
                    listColumn.ID = column.ColumnID;
                    listColumn.SortMode = ManagedListViewSortMode.None;
                    listColumn.Width = column.Width;
                    list_view.Columns.Add(listColumn);
                }
            }
            list_view.Columns[0].Width = 200;
            list_view.Columns[3].Width = 250;
        }
        private void RefreshFiles()
        {

        }

        public void SelectAll()
        {
            foreach (ManagedListViewItem item in list_view.Items)
                item.Selected = true;
            list_view.Invalidate();
        }
        public void DeleteSelected()
        {
            if (MessageBox.Show("Are you sure you want to delete selected files from the list ?", "Delete files from the list", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ManagedListViewItem item in list_view.SelectedItems)
                {
                    list_view.Items.Remove(item);
                }
                list_view.Invalidate();
            }
        }

        public bool CanSaveList
        {
            get { return list_view.Items.Count > 0; }
        }
        public void OpenMU3List(string list_file, bool auto_play)
        {
            M3UList op = new M3UList();
            string[] files = op.Load(list_file);

            OpenFiles(files, auto_play);
        }
        public void SaveMU3List(string list_file)
        {
            List<string> files = new List<string>();
            foreach (ManagedListViewItem it in list_view.Items)
            {
                files.Add(it.Tag.ToString());
            }

            M3UList sav = new M3UList();
            sav.Save(list_file, files.ToArray());
        }

        public void PlayNext()
        {
            if (list_view.Items.Count < 1)
                return;

            // TODO: repeat list on finish
            if ((current_song_index + 1) >= list_view.Items.Count)
                return;

            current_song_index++;

            current_file_in_play = list_view.Items[current_song_index].Tag.ToString();

            if (!FormatsManager.LoadMediaFile(current_file_in_play, true))
            {
                // failure playing the song, play next
                PlayNext();
            }
            else
            {
                list_view.ScrollToItem(list_view.Items[current_song_index]);
            }

            list_view.Invalidate();
        }
        public void PlayPrevious()
        {
            if (list_view.Items.Count < 1)
                return;


            // TODO: repeat list on finish
            if ((current_song_index - 1) < 0)
                return;
            if ((current_song_index - 1) >= list_view.Items.Count)
                return;

            current_song_index--;
            current_file_in_play = list_view.Items[current_song_index].Tag.ToString();

            if (!FormatsManager.LoadMediaFile(current_file_in_play, true))
            {
                // failure playing the song, play next
                PlayNext();
            }
            else
            {
                list_view.ScrollToItem(list_view.Items[current_song_index]);
            }

            list_view.Invalidate();
        }
        string GetFileSize(string FilePath)
        {
            if (File.Exists(Path.GetFullPath(FilePath)) == true)
            {
                FileInfo Info = new FileInfo(FilePath);
                string Unit = " Byte";
                double Len = Info.Length;
                if (Info.Length >= 1024)
                {
                    Len = Info.Length / 1024.00;
                    Unit = " KB";
                }
                if (Len >= 1024)
                {
                    Len /= 1024.00;
                    Unit = " MB";
                }
                if (Len >= 1024)
                {
                    Len /= 1024.00;
                    Unit = " GB";
                }
                return Len.ToString("F2") + Unit;
            }
            return "";
        }
        private void List_view_DrawSubItem(object sender, ManagedListViewSubItemDrawArgs e)
        {
            if (e.ColumnID == "name")
            {
                e.TextToDraw = e.ParentItem.SubItems[0].Text;

                string file = e.ParentItem.Tag.ToString();
                if (file == current_file_in_play)
                {
                    e.ImageToDraw = Properties.Resources.control_play_blue;
                }
                else
                    e.ImageToDraw = Properties.Resources.empty;
            }
        }
        private void List_view_ItemDoubleClick(object sender, ManagedListViewItemDoubleClickArgs e)
        {
            if (e.ClickedItemIndex >= 0 && e.ClickedItemIndex < list_view.Items.Count)
            {
                current_file_in_play = list_view.Items[current_song_index = e.ClickedItemIndex].Tag.ToString();

                if (!FormatsManager.LoadMediaFile(current_file_in_play, true))
                {
                    // failure playing the song, play next
                    PlayNext();
                }
                else
                {

                }

                list_view.Invalidate();
            }
        }
        private void APCore_EndOfSourceReached(object sender, EventArgs e)
        {
            if (!InvokeRequired)
                PlayNext();
            else
                Invoke(new Action(PlayNext));
        }

        private void CheckDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (ModifierKeys == Keys.Shift)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void List_view_DragOver(object sender, DragEventArgs e)
        {
            CheckDrop(e);
        }
        private void List_view_DragEnter(object sender, DragEventArgs e)
        {
            CheckDrop(e);
        }
        private void List_view_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                OpenDragedArgs(droppedfiles, e.Effect == DragDropEffects.Move);
            }
        }
        private void List_view_ColumnClicked(object sender, ManagedListViewColumnClickArgs e)
        {
            //get column and detect sort information
            ManagedListViewColumn column = list_view.Columns.GetColumnByID(e.ColumnID);
            if (column == null) return;
            bool az = false;
            switch (column.SortMode)
            {
                case ManagedListViewSortMode.AtoZ: az = false; break;
                case ManagedListViewSortMode.None:
                case ManagedListViewSortMode.ZtoA: az = true; break;
            }
            foreach (ManagedListViewColumn cl in list_view.Columns)
                cl.SortMode = ManagedListViewSortMode.None;

            if (az)
                column.SortMode = ManagedListViewSortMode.AtoZ;
            else
                column.SortMode = ManagedListViewSortMode.ZtoA;
            // Do sort
            list_view.Items.Sort(new ListComparer(az, e.ColumnID));

        }
    }
}
