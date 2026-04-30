using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace mod10.Models;

public class Pet
{
    public int PetId { get; set; } = 0;

    [Column(TypeName = "nvarchar(30)")]

    public string PetName { get; set; }
    public string Type { get; set; }
    public string? PictureUrl { get; set; }
    public string? Owner { get; set; }
    public DateTime? AdopDate { get; set; }

}

public class PetContext : DbContext
{
    public PetContext(DbContextOptions<PetContext> options) : base(options)
    {

    }
    public DbSet<Pet> Pets { get; set; }
}

