using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class LoginManager
{
    private ILogin loginMethod;
    public void SetLoginMethod(ILogin method) 
    {
        loginMethod = method;
    }

    public void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure)
    {
        if (loginMethod != null)
        {
            loginMethod.Login(onSuccess, onFailure);
        }
        else 
        {
            Debug.LogError("No login method set!");
        }
    }

}
