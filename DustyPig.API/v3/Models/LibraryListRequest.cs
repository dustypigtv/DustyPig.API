﻿using DustyPig.API.v3.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DustyPig.API.v3.Models
{
    public class LibraryListRequest : ListRequest, IValidate
    {
        [JsonProperty("library_id")]
        public int LibraryId { get; set; }

        public new void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(LibraryId), LibraryId, lst);
            try { base.Validate(); }
            catch (ModelValidationException ex) { lst.AddRange(ex.Errors); }

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }
    }
}
