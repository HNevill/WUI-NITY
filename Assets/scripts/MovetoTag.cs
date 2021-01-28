using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovetoTag : MonoBehaviour
{
	
	private GameObject Safehouse;
	private Transform Safety;

   // Start is called before the first frame update
    void update()
    {
     Safehouse = GameObject.FindWithTag("target");
     Safety = Safehouse.transform;

     NavMeshAgent agent = GetComponent<NavMeshAgent>();
     agent.destination = Safety.position;
    }


}
