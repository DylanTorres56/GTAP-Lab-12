using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;

public class PlayFabManager: MonoBehaviour
{
    private LoginManager loginManager;
    private string savedEmailKey = "SavedEmail";
    private string userEmail;    

    // Start is called before the first frame update
    void Start()
    {
        loginManager = new LoginManager();

        // Check if the email is saved
        if (PlayerPrefs.HasKey(savedEmailKey)) 
        {
            string savedEmail = PlayerPrefs.GetString(savedEmailKey);

            // Auto-login with saved email!
            EmailLoginButtonClicked(savedEmail, "SavedPassword");
        }
    }

    // Example method for triggering email login
    public void EmailLoginButtonClicked(string email, string password) 
    {
        userEmail = email;
        loginManager.SetLoginMethod(new EmailLogin(email, password));
        loginManager.Login(OnLoginSuccess, OnLoginFailure);
    }

    void OnLoginSuccess(LoginResult result) 
    {
        Debug.Log("Login successful!");
        
        // Load any needed data
        
        // Save email for future login        
        if (!string.IsNullOrEmpty(userEmail)) 
        {
            PlayerPrefs.SetString(savedEmailKey, userEmail);
        }

        // Load player data
        LoadPlayerData(result.PlayFabId);
    }

    void OnLoginFailure(PlayFabError error) 
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
    }

    private void LoadPlayerData(string playFabID) 
    {
        var request = new GetUserDataRequest 
        { 
            PlayFabId = playFabID 
        };

        PlayFabClientAPI.GetUserData(request, OnDataSuccess, OnDataFailure);
    }
    
    void OnDataSuccess(GetUserDataResult result)
    {
        // Process player data here
        Debug.Log("Player data loaded successfully.");
    }

    void OnDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to load player data: " + error.ErrorMessage);
    }
}
