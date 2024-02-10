using System;

namespace DustyPig.API.v3.Models
{
    public class BasicFriend : IComparable
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Initials { get; set; }

        public string AvatarUrl { get; set; }

        #region IComparable

        public int CompareTo(object obj)
        {
            var comp = obj as BasicFriend;
            return DisplayName.CompareTo(comp.DisplayName);
        }

        #endregion


        public override string ToString() => DisplayName;

    }
}
