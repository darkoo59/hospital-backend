

using System.ComponentModel.DataAnnotations;

namespace IntegrationLibrary.Core.Model
{
    public class User
    {
        public int Id { set; get; }
        [Required]
        public string Email { set; get; }
        public string Password { set; get; }
        [Required]
        public string AppName { set; get; }
        [Required]
        public string Server { get; set; }
    }
}
