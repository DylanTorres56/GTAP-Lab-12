using System;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class WeatherAPIProfile
{
    public Coord coord;
    public Weather[] weather;
    public string _base;
    public Main main;
    public int visibility;
    public Wind wind;
    public Rain rain;
    public Clouds clouds;
    public int dt;
    public Sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;

    [Serializable]
    public class Coord
    {
        public float lon;
        public float lat;
    }
    [Serializable]
    public class Main
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public int pressure;
        public int humidity;
        public int sea_level;
        public int grnd_level;
    }
    [Serializable]
    public class Wind
    {
        public float speed;
        public int deg;
        public float gust;
    }
    [Serializable]
    public class Rain
    {
        public float _1h;
    }
    [Serializable]
    public class Clouds
    {
        public int all;
    }
    [Serializable]
    public class Sys
    {
        public int type;
        public int id;
        public string country;
        public int sunrise;
        public int sunset;
    }
    [Serializable]
    public class Weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }


    public static WeatherAPIProfile FromJson(string json) => JsonUtility.FromJson<WeatherAPIProfile>(json);

    public string WeatherName => weather[0].main;

    //DO THING
    public bool IsDaytime { get 
        {
            float time = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds - timezone;
            if (time > 43200)
            {
                return true;
            }
            return false;
        } }


}