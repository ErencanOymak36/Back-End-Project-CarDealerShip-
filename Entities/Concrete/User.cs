using Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PasswordHash { get; set; }
        public int PasswordSalt { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Customer>? Customer { get; set; }

    }
}
