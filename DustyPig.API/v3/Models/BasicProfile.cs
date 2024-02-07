using System;

namespace DustyPig.API.v3.Models
{
    public class BasicProfile : IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsMain { get; set; }

        public bool HasPin { get; set; }

        #region IComparable

        public int CompareTo(object obj)
        {
            var comp = obj as BasicProfile;
            int ret = -IsMain.CompareTo(comp.IsMain);
            if (ret == 0) ret = Name.CompareTo(comp.Name);
            return ret;
        }

        #endregion

        public override string ToString() => Name;
    }
}