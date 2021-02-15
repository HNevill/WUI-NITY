using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstantiationExample : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public int noOfAgents = 40;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

        for (int i = 0; i < noOfAgents; i++)
        {
            Instantiate(myPrefab, transform.position , Quaternion.identity);

        }
    }
}
        
