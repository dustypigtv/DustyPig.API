namespace DustyPig.API.v3.Models;

/// <summary>
/// Returned when calling <see cref="Clients.EpisodesClient.GetDetailsAsync"/>
/// </summary>
public class DetailedEpisodeEx : DetailedEpisode
{
   public DetailedSeries Series { get; set; }
}
