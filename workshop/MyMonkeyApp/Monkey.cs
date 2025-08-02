namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with all relevant information
/// </summary>
public class Monkey
{
    /// <summary>
    /// The name of the monkey species
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The geographic location where this monkey species is found
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of the monkey species
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// URL to an image of the monkey species
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Current population count of this monkey species
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Latitude coordinate of the monkey's primary habitat
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude coordinate of the monkey's primary habitat
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Determines if this is a wild species or a special friend
    /// </summary>
    public bool IsWildSpecies => Population > 1;

    /// <summary>
    /// Gets the conservation status based on population
    /// </summary>
    public string ConservationStatus
    {
        get
        {
            return Population switch
            {
                <= 1000 => "Critically Endangered",
                <= 5000 => "Endangered",
                <= 10000 => "Vulnerable",
                <= 20000 => "Near Threatened",
                _ => "Least Concern"
            };
        }
    }

    /// <summary>
    /// Returns a formatted string representation of the monkey
    /// </summary>
    public override string ToString()
    {
        return $"{Name} - {Location} (Population: {Population:N0})";
    }

    /// <summary>
    /// Returns detailed information about the monkey
    /// </summary>
    public string GetDetailedInfo()
    {
        return $"""
            🐵 {Name}
            📍 Location: {Location}
            👥 Population: {Population:N0}
            🌍 Coordinates: {Latitude:F6}, {Longitude:F6}
            🚨 Status: {ConservationStatus}
            📝 Details: {Details}
            """;
    }
}
