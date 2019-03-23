using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddharVerification.Models
{
    public class PassportApprove
    {

        public int Id { get; set; }
        public bool Status { get; set; }
        public string PassportId { get; set; }
        public string AppuserId { get; set; }
    }
}
