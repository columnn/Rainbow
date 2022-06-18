using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rainbow;

public class Color
{
    public int ColorId { get; set; }
    [Required, MinLength(3, ErrorMessage = "Name must be more than 3 characters"), MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string? Name { get; set; }
    [Required, RegularExpression(@"^#([1234567890a-fA-F]){6}$", ErrorMessage = "Color must be 6 digit hexdecimal prefixed with '#'")]
    public string? Hex { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public float Hue { get; set; }
    public float Saturation { get; set; }
    public float Value { get; set; }
    public string? Username { get; set; }

    public override string ToString() => JsonSerializer.Serialize<Color>(this);
}