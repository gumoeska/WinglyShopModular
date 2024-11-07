using System.ComponentModel.DataAnnotations;

namespace WinglyShop.API.Settings;

public class WinglySettings
{
	public const string ConfigurationSection = "WinglyShop";

	[Required]
	public string AccessToken { get; init; } = string.Empty;

	[Required]
	public string UserAgent { get; init; } = string.Empty;
}
