namespace Finance.Tests.Fixtures
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryDto
    {
        [MaxLength(80)]
        public string Name { get; set; }
    }
}