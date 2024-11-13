using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{

    public int townID;
    public string[] towns;
    private int currentTownID;

    public float autoUpdateRate = 5 * 60 * 60;

    private float autoUpdateTimer = 0;

    public TMPro.TextMeshPro debugText;

    private void Awake()
    {
        UpdateWeather();
    }

    public void Update()
    {
        autoUpdateTimer += Time.deltaTime;
        if(autoUpdateTimer >= autoUpdateRate)
        {
            UpdateWeather();
            autoUpdateTimer %= autoUpdateRate;

        }

        if(currentTownID != townID)
        {
            currentTownID = townID;
            UpdateWeather();
            autoUpdateTimer = 0;
        }

    }

    private string URL => $"http://api.openweathermap.org/data/2.5/weather?q={towns[townID]}&mode=json&appid={APIKEY}";

    private const string APIKEY = "c7ce360dc9c6e5c1353d0aaa5ab7a187";

    public void UpdateWeather() => StartCoroutine(CallAPI(URL, PostAPI));

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError($"network problem: {request.error}");
        }
        else if (request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"response error: {request.responseCode}");
        }
        else
        {
            callback.Invoke(request.downloadHandler.text);
        }
    }

    public void PostAPI(string json)
    {
        debugText.text = json;
        profile = WeatherAPIProfile.FromJson(json);

        // Do data change with the Weather data.



    }
    public WeatherAPIProfile profile;
}
 