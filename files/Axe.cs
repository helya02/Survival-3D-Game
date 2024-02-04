using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision!");
        if (Input.GetKeyDown(KeyCode.Q)){
       if(other.gameObject.tag == "Tree"){
            
            Destroy(other.gameObject, .1f);
            

        }

        
        }
        
    }*/

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "finish"){
            Debug.Log("Finish");
        }
        
    }
}
