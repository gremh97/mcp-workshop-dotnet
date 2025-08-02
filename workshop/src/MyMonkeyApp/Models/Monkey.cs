namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with its characteristics and population data.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the common name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary geographic location or habitat of the monkey.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population count of the species.
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Gets or sets additional details about the monkey species.
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the conservation status of the species.
    /// </summary>
    public string ConservationStatus { get; set; } = string.Empty;

    /// <summary>
    /// Returns a formatted string representation of the monkey.
    /// </summary>
    public override string ToString()
    {
        return $"{Name} from {Location} (Population: {Population:N0}, Status: {ConservationStatus})";
    }
}