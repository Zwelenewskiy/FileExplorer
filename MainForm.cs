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

        private delegate void changeEnabled(bool enable);

        public MainForm()
        {
            InitializeComponent();

            ShowFilesAndDirectories();
            BT_move_back.Enabled = false;
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
                    if (drive.IsReady)
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
                TB_current_path.Text = previous_item.Value;
                ShowFilesAndDirectories(previous_item.Value);
            }
            else
            {
                BT_move_back.Enabled = false;
                TB_current_path.Text = null;

                ShowFilesAndDirectories();
            }
        }

        private void BT_process_files_Click(object sender, EventArgs e)
        {
            if(files_for_process.Count < 2)
            {
                MessageBox.Show("Для обработки требуются 2 файла", "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BT_process_files.Enabled = false;

            System.Threading.Tasks.Task.Factory.StartNew(() => 
            {
                try
                {
                    FileStream fs1 = new FileStream(files_for_process[0].Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    FileStream fs2 = new FileStream(files_for_process[1].Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    FileStream fs_result = new FileStream(Path.GetDirectoryName(files_for_process[1].Path) + "/xor_res.dat", FileMode.Create);

                    byte[] arr1 = new byte[1024];
                    byte[] arr2 = new byte[1024];

                    byte[] arr_result = new byte[1024];

                    int num_read1;
                    int num_read2;
                    int min;
                    while (true)
                    {
                        num_read1 = fs1.Read(arr1, 0, arr1.Length);
                        num_read2 = fs2.Read(arr2, 0, arr2.Length);

                        if (num_read1 == 0 || num_read2 == 0)
                            break;

                        // ищу минимальный массив
                        min = num_read1 > num_read2 ? num_read2 : num_read1;

                        for (int i = 0; i < min; i++)
                            arr_result[i] = (byte)(arr1[i] ^ arr2[i]);

                        fs_result.Write(arr_result, 0, min);
                    }

                    fs1.Close();
                    fs2.Close();
                    fs_result.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка выполнения операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                BT_process_files.BeginInvoke(new changeEnabled((enable) => BT_process_files.Enabled = enable), true);
            });            
        }


        private void DGV_process_files_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= files_for_process.Count)
                return;

            files_for_process.RemoveAt(e.RowIndex);
            ShowFilesForProcess();
        }
    }
}
