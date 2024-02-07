using System;

namespace DustyPig.API.v3.Models
{
    public class BasicLibrary : UpdateLibrary, IComparable
    {
        public string Owner { get; set; }

        #region IComparable

        public int CompareTo(object obj)
        {
            var comp = (BasicLibrary)obj;
            int ret = -string.IsNullOrWhiteSpace(Owner).CompareTo(string.IsNullOrWhiteSpace(comp.Owner));
            if (ret == 0) ret = Name.CompareTo(comp.Name);
            return ret;
        }

        #endregion

        public override string ToString() => Name;
    }
}
