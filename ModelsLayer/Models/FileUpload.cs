using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsLayer.Models
{
    public abstract class FileUpload
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "File Type")]
        public string FileType { get; set; }
        [Display(Name = "File Extension")]
        public string Extension { get; set; }
        public string Description { get; set; }
        [Display(Name = "Uploaded By")]
        public string UploadedBy { get; set; }
        [DataType(DataType.Date), Display(Name = "Time stamp"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedOn { get; set; }
    }
}
