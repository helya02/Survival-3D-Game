using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private float currentHealth, maxHealth;
    public GameObject playerState;
    public TextMeshProUGUI healthCounter;
    public Slider slider;
    //references
    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update(){
        //slider = GetComponent<Slider>();
        currentHealth = playerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = playerState.GetComponent<PlayerState> ().maxHealth;

        float fillValue = currentHealth / maxHealth ;
        slider.value = fillValue ;
        healthCounter.text = currentHealth + "/" + maxHealth;
    }

}
