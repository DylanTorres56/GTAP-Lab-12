using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] string skyboxName;
    [SerializeField] Material skyboxDay;
    [SerializeField] Material skyboxNight;
}