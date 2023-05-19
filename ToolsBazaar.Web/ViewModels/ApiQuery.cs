using System.ComponentModel.DataAnnotations;

namespace ToolsBazaar.Web.ViewModels
{
    public class ApiQuery
    {
        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        public int Count { get; set; } = 5;
    }
}
