

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationLibrary.Core.Model
{
    public class User
    {
        public int Id { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
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
    }
}
