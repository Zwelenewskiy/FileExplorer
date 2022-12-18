using FileExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class MainForm : Form
    {
        private LinkedList<string> directories_sequence = new LinkedList<string>();
        private List<FilesTableItem> files_table_items = new List<FilesTableItem>();
        private List<FilesTableItem> files_for_process = new List<FilesTableItem>();

        public MainForm()
        {
            InitializeComponent();
            ShowFilesAndDirectories();
        }

        private void ShowFilesTableItems()
        {
            foreach (var item in files_table_items)
            {
                DGV_repo.Rows.Add(item.Name);
            }
        }

        private void ShowFilesAndDirectories(string path = null)
        {
            DGV_repo.Rows.Clear();
            files_table_items.Clear();

            if(path == null)
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    string label = string.IsNullOrEmpty(drive.VolumeLabel) ? "Локальный диск" : drive.VolumeLabel;
                    string name = $"{label} ({drive.Name.Replace("\\", string.Empty)})";

                    files_table_items.Add(new FilesTableItem()
                    {
                        Path = drive.RootDirectory.FullName,
                        Name = name,
                        Type = FilesTableItemType.Drive
                    });
                }

                ShowFilesTableItems();
            }
            else
            {
                string[] allfolders = Directory.GetDirectories(path);
                foreach (string filename in allfolders)
                {
                    files_table_items.Add(new FilesTableItem()
                    {
                        Path = filename,
                        Name = Path.GetFileName(filename),
                        Type = FilesTableItemType.Folder
                    });
                }

                string[] allfiles = Directory.GetFiles(path);
                foreach (string filename in allfiles)
                {
                    files_table_items.Add(new FilesTableItem()
                    {
                        Path = filename,
                        Name = Path.GetFileName(filename),
                        Type = FilesTableItemType.File
                    });
                }

                ShowFilesTableItems();
            }
        }

        private void ShowFilesForProcess()
        {
            DGV_process_files.Rows.Clear();

            foreach (var item in files_for_process)
            {
                DGV_process_files.Rows.Add(item.Name);
            }
        }

        private void DGV_repo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var path_item = files_table_items[e.RowIndex];

            if (path_item.Type == FilesTableItemType.Drive || path_item.Type ==  FilesTableItemType.Folder)
            {
                BT_move_back.Enabled = true;

                try
                {
                    ShowFilesAndDirectories(path_item.Path);

                    TB_current_path.Text = path_item.Path;
                    directories_sequence.AddLast(path_item.Path);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Отказано в доступе", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowFilesAndDirectories(directories_sequence.Last.Value);
                }
            }
            else
            {
                path_item.Name = Path.GetFileName(path_item.Path);
                files_for_process.Add(path_item);

                ShowFilesForProcess();
            }
        }

        private void BT_move_back_Click(object sender, EventArgs e)
        {
            var previous_item = directories_sequence.Last.Previous;
            directories_sequence.RemoveLast();

            if(previous_item != null)
            {
                ShowFilesAndDirectories(previous_item.Value);
            }
            else
            {
                BT_move_back.Enabled = false;
                ShowFilesAndDirectories();
            }
        }

        private void BT_process_files_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var file in files_for_process)
                {
                    //File.ReadAllBytes(file.Path);
                }
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
