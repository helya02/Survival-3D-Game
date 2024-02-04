using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance{get;set;}
    public float currentHealth;
    public float maxHealth;

    public float currentCalories;
    public float maxCalories;

    public GameObject playerBody;
    public float distanceTravelled=0;
    Vector3 lastPosition;


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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        currentCalories=maxCalories;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentHealth <= 0 ){
            //Time.timeScale = 0;
            SceneManager. LoadScene (0) ;
        }
         distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
         lastPosition = playerBody.transform.position;
        if(distanceTravelled >=5){distanceTravelled=0;
        currentCalories-=10;}


    }
}
