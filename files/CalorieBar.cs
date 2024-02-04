using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CalorieBar : MonoBehaviour
{
    private float currentCalories, maxCalories;
    public GameObject playerState;
    public TextMeshProUGUI caloriesCounter;
    public Slider slider;
    //references
    void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update(){
        //slider = GetComponent<Slider>();
        currentCalories = playerState.GetComponent<PlayerState>().currentCalories;
        maxCalories = playerState.GetComponent<PlayerState> ().maxCalories;

        float fillValue = currentCalories / maxCalories ;
        slider.value = fillValue ;
        caloriesCounter.text = currentCalories + "/" + maxCalories;
    }
}
