using System.ComponentModel.DataAnnotations.Schema;

namespace Report.API.Models
{
    public enum FileStatus
    {
        Creating,
        Completed
    }
    public class ContactFile
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public FileStatus FileStatus { get; set; }

        [NotMapped]
        public string GetCreatedDate => CreatedDate.HasValue ? CreatedDate.Value.ToShortDateString() : "-";
    }
}
