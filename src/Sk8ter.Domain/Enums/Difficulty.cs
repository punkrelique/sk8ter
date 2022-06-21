using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Sk8ter.Domain.Enums;

public enum Difficulty
{
    [EnumMember(Value = "Easy")]
    Easy,
    Medium,
    Hard
}