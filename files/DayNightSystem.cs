using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour{ 
        public Light directionallight; 
        public float dayDurationInSeconds = 24.0f; 
        public int currentHour; 
        public float currentTimeOfDay = 0.0f; 
        public SkyboxTimeMapping [] TimeMappings; 
        
void Update() 
{
     currentTimeOfDay += Time.deltaTime / dayDurationInSeconds; 
     currentTimeOfDay %= 1;  
     currentHour = Mathf.FloorToInt (currentTimeOfDay * 24); 
     //Update the directional light's rotation 
     directionallight.transform.rotation = Quaternion.Euler(new Vector3 ((currentTimeOfDay*360) -90 , 170 , 0)); 
     //Update the skybox material based on the time of day. 
     UpdateSkybox(); } 
     private void UpdateSkybox() 
     { 
        //Find the appropriate skybox material for the current hour. 
        Material currentSkybox = null; 
        foreach (SkyboxTimeMapping mapping in TimeMappings) 
        {
                if (currentHour == mapping.hour) 
                { 
                    currentSkybox = mapping.skyboxMaterial;
                 
                    break; 
                } 
                       
                if (currentSkybox != null) 
                { 
                     RenderSettings.skybox = currentSkybox; 
                } 
                            
        } 
     }

}
[System.Serializable] 
public class SkyboxTimeMapping
{ 
        public string phaseName;
        public int hour; 
        public Material skyboxMaterial; 
}

