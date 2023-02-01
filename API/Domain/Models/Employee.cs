using System.ComponentModel.DataAnnotations;
public class Employee
{
    [Key]
    public string id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

}
