namespace Finance.Tests.Fixtures
{
    using System.ComponentModel.DataAnnotations;

    public class CreditorDto
    {
        [MaxLength(80)]
        public string CreditorName { get; set; }

        public int Id { get; set; }
    }
}