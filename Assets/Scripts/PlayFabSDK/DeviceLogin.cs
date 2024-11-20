using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class DeviceLogin : ILogin
{
    private string deviceID;
    public DeviceLogin(string deviceID) 
    {
        this.deviceID = deviceID;
    }

    public void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure)
    {
        var request = new LoginWithCustomIDRequest 
        {
            CustomId = deviceID,
            CreateAccount = true // Create account if it doesn't exist already
        };
        PlayFabClientAPI.LoginWithCustomID(request, onSuccess, onFailure);
    }
}
