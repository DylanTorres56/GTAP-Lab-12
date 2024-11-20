using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class EmailLogin : ILogin
{
    private string email, password;
    public EmailLogin(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public void Login(Action<LoginResult> onSuccess, Action<PlayFabError> onFailure)
    {
        var request = new LoginWithEmailAddressRequest 
        { 
            Email = email, 
            Password = password
        };  
        
        PlayFabClientAPI.LoginWithEmailAddress(request, onSuccess, onFailure);
    }

}
