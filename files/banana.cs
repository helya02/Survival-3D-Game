using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    // Start is called before the first frame update

    public static banana Instance { get; private set;}
    public bool BananaHitPlayer { get; set; }
    void Start()
    {
        Instance = this;
        BananaHitPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            BananaHitPlayer = true;
            Destroy(gameObject, .1f);
            

        }
        
    }

}
