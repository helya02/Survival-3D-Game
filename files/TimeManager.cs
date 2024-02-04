using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour 
{ 
    public static TimeManager Instance { get; set; } 
    private void Awake()
    {
        if (Instance !=null && Instance !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public int dayInGame = 1;
     
    public void TriggerNextDay() 
    {dayInGame= 1; 
    } 
    }
