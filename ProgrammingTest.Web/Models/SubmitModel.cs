using System.ComponentModel.DataAnnotations;

namespace ProgrammingTest.Web.Models
{
    public class SubmitModel
    {
        [Required(ErrorMessage = "File size is required.")]
        public string FileSize { get; set; }
        [Range(0,100,ErrorMessage = "Out of range.")]
        public int IntPercentage { get; set; }
        [Range(0, 100, ErrorMessage = "Out of range.")]
        public int FloatPercentage { get; set; }
        [Range(0, 100, ErrorMessage = "Out of range.")]
        public int StringPercentage { get; set; }
    }
}
