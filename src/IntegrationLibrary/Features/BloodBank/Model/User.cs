using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IntegrationLibrary.Features.BloodBank.Model
{
    public class User
    {
        public int Id { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [JsonIgnore]
        public string Password { set; get; }
        [Required]
        [MaxLength(30)]
        public string AppName { set; get; }
        [Required]
        public string Server { get; set; }


        public class DuplicateEMailException : Exception
        {
            public DuplicateEMailException(string message) : base(message) { }
        }
        public class BadPasswordException : Exception
        {
            public BadPasswordException(string message) : base(message) { }
        }
    }
}
