using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Security
{
    public class AuthenticationToken
    {
        public int Id { get; set; }

        public string AccessToken { get; set; }
    }
}
