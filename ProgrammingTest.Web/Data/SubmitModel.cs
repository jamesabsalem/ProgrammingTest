using System.ComponentModel.DataAnnotations;

namespace ProgrammingTest.Web.Data
{
    public class SubmitModel
    {
        [Required(ErrorMessage = "File size is required.")]
        public string FileSize { get; set; }
    }
}
