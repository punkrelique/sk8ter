using Sk8ter.Domain.Enums;

namespace Sk8ter.Domain.Entities;

public class Trick
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }
}