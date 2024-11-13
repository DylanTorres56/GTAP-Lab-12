using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherManager : MonoBehaviour
{

    public int townID;
    public Vector2[] towns;
    private int currentTownID;

    public float autoUpdateRate = 5 * 60 * 60;

    private float autoUpdateTimer = 0;


    public void Awake()
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

    public void UpdateWeather() => StartCoroutine(CallAPI(xmlApi, null));


    //Unknown functionality
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Orlando,us&mode=xml&appid=APIKEY";

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
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
                callback(request.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

}
