using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAndMove : MonoBehaviour
{
    public float range = 100.0f;
    bool found_mesh = false;
    private GameObject Safehouse;
	private Transform Safety;
	private NavMeshAgent agent;

	private void Start()
	{

		agent = GetComponent<NavMeshAgent>();
		Safehouse = GameObject.FindWithTag("target");
		Debug.Log("found");
		TeleportToRoad();
	}

    void RandomPoint(Vector3 center, float range, out Vector3 result)
   {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        result = Vector3.zero;

        while(!found_mesh)
        {
        	if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        	{
            	result = hit.position;
            	found_mesh = true;
        	}
        }
    }
        
    void TeleportToRoad()
    {
        Vector3 point;
        RandomPoint(transform.position, range, out point);
        Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        Debug.Log(point);

        agent.Warp(point);
			Safety = Safehouse.transform;

		agent.destination = Safety.position;
		//found_mesh = true;

    }
}
