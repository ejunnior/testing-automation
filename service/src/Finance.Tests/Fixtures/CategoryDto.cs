namespace Finance.Tests.Fixtures
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryDto
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }
    }
}