﻿using DustyPig.API.v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DustyPig.API.v3.Models
{
    public class SetTitlePermission : IValidate
    {
        public int MediaId { get; set; }

        public int ProfileId { get; set; }

        public OverrideState OverrideState { get; set; }

        #region IValidate

        public void Validate()
        {
            var lst = new List<string>();

            Validators.ValidateId(nameof(MediaId), MediaId, lst);
            Validators.ValidateId(nameof(ProfileId), ProfileId, lst);
            if (new OverrideState[] { OverrideState.Allow, OverrideState.Block, OverrideState.Default }.Contains(OverrideState) == false)
                lst.Add($"Invalid {nameof(OverrideState)}");

            Validators.ValidateId(nameof(MediaId), MediaId, lst);

            if (lst.Count > 0)
                throw new ModelValidationException { Errors = lst };
        }


        #endregion
    }
}
