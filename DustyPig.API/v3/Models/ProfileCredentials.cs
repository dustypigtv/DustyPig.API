﻿using DustyPig.API.v3.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DustyPig.API.v3.Models;

public class ProfileCredentials : IValidate
{
    public int Id { get; set; }

    public short? Pin { get; set; }

    [JsonPropertyName("fcmToken")]
    public string FCMToken { get; set; }


    /// <summary>
    /// Optional. When specified, this will delete tokens with identical device id's from the database
    /// </summary>
    public string DeviceId { get; set; }


    #region IValidate

    public void Validate()
    {
        var lst = new List<string>();

        Validators.ValidateId(nameof(Id), Id, lst);

        if (Pin.HasValue && Pin.Value < 1000)
            lst.Add($"Invalid {nameof(Pin)}");

        var chk = Validators.Validate(nameof(FCMToken), FCMToken, false, Constants.MAX_MOBILE_DEVICE_ID_LENGTH);
        if (chk.Valid)
            FCMToken = chk.Fixed;
        else
            lst.Add(chk.Error);


        chk = Validators.Validate(nameof(DeviceId), DeviceId, false, Constants.MAX_MOBILE_DEVICE_ID_LENGTH);
        if (chk.Valid)
            DeviceId = chk.Fixed;
        else
            lst.Add(chk.Error);


        if (lst.Count > 0)
            throw new ModelValidationException { Errors = lst };
    }

    #endregion

}
