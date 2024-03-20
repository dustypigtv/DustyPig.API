namespace DustyPig.API.v3.Models;

/// <summary>
/// Returned when calling <see cref="Clients.SeriesClient.GetDetailsAsync"/>
/// </summary>
public class DetailedEpisode : CreateEpisode
{
    public int Id { get; set; }

    public double? Played { get; set; }

    public bool UpNext { get; set; }

    public override string ToString() => base.ToString();
}
