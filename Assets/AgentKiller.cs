using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentKiller : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.CompareTag("agent"))
    	{
    		Debug.Log("collided with agent");
    		other.gameObject.GetComponent<AgentScript>().Explode();
    	}
    }
}
