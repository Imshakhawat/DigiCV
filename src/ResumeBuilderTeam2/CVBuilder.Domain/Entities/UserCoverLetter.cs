using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Domain.Entities
{
    public class UserCoverLetter : IEntity<int>
    {
        public Guid UserId { get; set; }
        public string Heading { get; set; }
        public DateTime Date { get; set; }
        public string HiringBody { get; set; }
        public string CompanyAddress { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public int Id { get; set; }
    }
}
