using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class DetailedSeries : CreateSeries, ICredits
    {
        public int Id { get; set; }

        public string Owner { get; set; }

        public List<DetailedEpisode> Episodes { get; set; } = [];

        public bool InWatchlist { get; set; }

        public bool CanPlay { get; set; }

        public bool CanManage { get; set; }

        public TitleRequestPermissions TitleRequestPermission { get; set; }

        public OverrideRequestStatus AccessRequestedStatus { get; set; }

        public bool Subscribed { get; set; }

        #region ICredits

        public List<Person> Credits { get; set; } = [];

        #endregion

        public override string ToString() => base.ToString();
    }
}
