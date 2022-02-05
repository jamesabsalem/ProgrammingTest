using System.ComponentModel.DataAnnotations;

namespace ProgrammingTest.Web.Models
{
    public class SubmitModel
    {
        [Required(ErrorMessage = "File size is required.")]
        public string FileSize { get; set; }
    }
}
