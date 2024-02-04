using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    // Start is called before the first frame update
    public static rabbit Instance { get; private set;}
    //public bool HitPlayer { get; set; }

    
    void Start()
    {
        //Instance = this;
        //HitPlayer = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            HitPlayer = true;
            

        }
        
    }*/
    
}
