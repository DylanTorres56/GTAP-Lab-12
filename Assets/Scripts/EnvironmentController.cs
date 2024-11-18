using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

public class EnvironmentController : MonoBehaviour
{
    public List<SkyboxType> skyboxList;
    public Material skyboxMat;
    public Light light;

    private void OnEnable()
    {
        WeatherManager.onGetEvent += UpdateSkybox;
    }

    private void UpdateSkybox(WeatherAPIProfile profile)
    {
        
    }

    public SkyboxType GetSkybox(WeatherAPIProfile profile)
    {
        SkyboxType chosenSkybox = skyboxList.FirstOrDefault(x => x.skyboxName == profile.WeatherName);
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