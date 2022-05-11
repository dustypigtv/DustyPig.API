using DustyPig.API.v3.BaseClasses;
using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateSeries : BaseSeriesInfo, IMedia, ITopLevelMedia, IValidate
    {
        #region IMedia

        //Completely handled by BaseSeriesInfo

        #endregion


        #region ITopLevelMedia

        //Completely handled by BaseSeriesInfo

        #endregion




        public void Validate()
        {
            var lst = new List<string>();

            lst.AddRange(Validators.Validate(this as IMedia));
            lst.AddRange(Validators.Validate(this as ITopLevelMedia));

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
