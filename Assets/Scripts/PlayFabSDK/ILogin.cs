using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

public interface ILogin
{
    void Login(System.Action<LoginResult> onSuccess, System.Action<PlayFabError> onFailure);    
}
