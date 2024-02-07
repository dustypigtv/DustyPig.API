using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class HomeScreenList : IComparable
    {
        public long ListId { get; set; }

        public string Title { get; set; }

        public List<BasicMedia> Items { get; set; }

        public int CompareTo(object obj)
        {
            return ListId.CompareTo((obj as HomeScreenList).ListId);
        }

        public override string ToString() => Title;
    }
}
