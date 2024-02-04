using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Blueprint : MonoBehaviour
{
    public string itemName;
    public string Req1; // Add this property
    public int Req1amount; // Add this property
    public string Req2; // Add this property
    public int Req2amount; // Add this property
    public int numOfRequirements; 
 
    public Blueprint(string name, int reqNUM, string R1, int R1num, string R2, int R2num)
    {
        itemName = name;
        numOfRequirements = reqNUM;
        Req1 = R1;
        Req1amount = R1num;
        Req2 = R2;
        Req2amount = R2num;
    }
}