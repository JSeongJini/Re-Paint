using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    [SerializeField] private Light worldLight = null;

    [SerializeField] private float worldTime = 0;
    private float nightFogDensity = 0.0025f;

    [SerializeField] private Material skyNight = null;
    [SerializeField] private Material skyDay = null;

    private bool isNight = false;


    private void Start()
    {
        Light[] lights = GameObject.FindObjectsOfType<Light>();

        foreach(Light light in lights)
        {
            if(light.gameObject.name.StartsWith("Directional Light"))
            {
                worldLight = light;
                break;
            }
        }
    }


    void FixedUpdate()
    {
        SunAndMoon();
    }

    private void SunAndMoon()
    {
        worldLight.transform.Rotate(Vector3.right, 0.1f * worldTime * Time.deltaTime);

        if (worldLight.transform.eulerAngles.x >= 200f)
        {
            isNight = true;
            RenderSettings.skybox = skyNight;
            RenderSettings.fogDensity = nightFogDensity;
        }
        else if (worldLight.transform.eulerAngles.x >= 0f)
        {
            isNight = false;
            RenderSettings.skybox = skyDay;
            RenderSettings.fogDensity = 0.001f;
        }
    }
}
