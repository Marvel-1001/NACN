using System;
using System.Collections.Generic;

namespace BackEndAPI.Models
{
    public partial class MemberType
    {
        public MemberType()
        {
            Members = new HashSet<Member>();
        }

        public int IdMembertype { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
