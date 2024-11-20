using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class EnvironmentController : MonoBehaviour
{
    public List<SkyboxType> skyboxList;
    //public Material skyboxMat;
    public Light skyLight;

    private void OnEnable()
    {
        WeatherManager.onGetEvent += (profile) => { UpdateSkybox(profile); UpdateLight(profile); };
    }

    private void UpdateSkybox(WeatherAPIProfile profile)
    {
        SkyboxType skybox = GetSkybox(profile.WeatherName);
        if (profile.IsDaytime)
        {
            RenderSettings.skybox = skybox.skyboxDay;

        }
        else
        {
            RenderSettings.skybox = skybox.skyboxNight;
        }

    }
    private void UpdateLight(WeatherAPIProfile profile) 
    {
        if (profile.IsDaytime)
        {
            skyLight.intensity = 1;
            RenderSettings.ambientIntensity = 1;
            skyLight.color = Color.white;
        }
        else 
        {
            skyLight.intensity = 0.25f;
            RenderSettings.ambientIntensity = 0.25f;
            skyLight.color = Color.blue;
        }


    }

    public SkyboxType GetSkybox(string WeatherName)
    {
        SkyboxType chosenSkybox = skyboxList.FirstOrDefault(x => x.skyboxName ==WeatherName);
        if (chosenSkybox.skyboxName == "" || chosenSkybox.skyboxName == null)
            chosenSkybox = skyboxList[0];
        return chosenSkybox;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public struct SkyboxType 
{
    public string skyboxName;
    public Material skyboxDay;
    public Material skyboxNight;
}