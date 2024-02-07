using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using DustyPig.API.v3.MPAA;
using System;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class CreateSeries : BaseSeriesInfo, IMedia, ITopLevelMedia, IValidate
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

            if (Rated == TVRatings.None)
            {
                lst.Add(nameof(Rated) + " not specified");
            }
            else
            {
                bool realRating = false;
                foreach (TVRatings rating in Enum.GetValues(typeof(TVRatings)))
                {
                    if (rating == Rated)
                    {
                        realRating = true;
                        break;
                    }
                }
                if (!realRating)
                    lst.Add($"Invalid {nameof(Rated)}");
            }


            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }

        #endregion

        public override string ToString() => base.ToString();
    }
}
