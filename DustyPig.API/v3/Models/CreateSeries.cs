using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateSeries : BaseSeriesInfo, IMedia, ITopLevelMedia, IValidate, IEquatable<CreateSeries>
    {
        #region IMedia

        //Completely handled by BaseSeriesInfo

        #endregion


        #region ITopLevelMedia

        //Completely handled by BaseSeriesInfo

        #endregion


        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            lst.AddRange(Validators.Validate(this as IMedia));
            lst.AddRange(Validators.Validate(this as ITopLevelMedia));

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion


        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as CreateSeries);
        }

        public bool Equals(CreateSeries other)
        {
            return !(other is null) &&
                   base.Equals(other);
        }

        public override int GetHashCode()
        {
            return 624022166 + base.GetHashCode();
        }

        public static bool operator ==(CreateSeries left, CreateSeries right)
        {
            return EqualityComparer<CreateSeries>.Default.Equals(left, right);
        }

        public static bool operator !=(CreateSeries left, CreateSeries right)
        {
            return !(left == right);
        }

        #endregion


        public override string ToString() => base.ToString();
    }
}
