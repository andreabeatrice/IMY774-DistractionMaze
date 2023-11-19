using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLightChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAmbientIntensityHalf(){
        RenderSettings.ambientIntensity = 0.5f;
    }

    public void SetAmbientIntensityQuarter(){
        RenderSettings.ambientIntensity = 0.25f;
    }

    public void SetAmbientIntensityNone(){
        RenderSettings.ambientIntensity = 0f;
    }

    public void SetAmbientIntensityFull(){
        RenderSettings.ambientIntensity = 1f;
    }
}
