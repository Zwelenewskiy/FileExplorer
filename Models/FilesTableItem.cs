namespace FileExplorer.Models
{
    public enum FilesTableItemType
    {
        Drive,
        Folder,
        File
    }

    public class FilesTableItem
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public FilesTableItemType Type { get; set; }
    }
}
