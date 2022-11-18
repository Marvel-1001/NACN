namespace BackEndAPI.DTOs
{
    public class MemberDTO
    {
        public int IdMember { get; set; }
        public int? IdMembertype { get; set; }
        public string? MembertypeName { get; set; }
        public string? FullName { get; set; }
        public string? Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? IDNumber { get; set; }
        public string? Region { get; set; }
        public string? Constituency { get; set; }
        public string? PostalAddress { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }
        public string? WorkNumber { get; set; }
        public string? Email { get; set; }
        public string? Disability { get; set; }
        public string? Pensioner { get; set; }
        public string? Learner { get; set; }
        public string? Employed { get; set; }
        public string? StageName { get; set; }
        public string? ArtDiscipline { get; set; }
        public int? YearsInIndustry { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaidMembership { get; set; }
        public string? OrgasinationName { get; set; }
        public DateTime? FinancialYear { get; set; }
    }
}
