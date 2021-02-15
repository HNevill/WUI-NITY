using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAndMove : MonoBehaviour
{
    public float range = 100.0f;
	private Transform Safety;
	[SerializeField] private NavMeshAgent agent; //set in inspector to reduce spawn time

	public void SetTarget(GameObject target)
	{
        Safety = target.transform;
		//TeleportToRoad();
	}

    void RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        result = Vector3.zero;

        if (NavMesh.SamplePosition(randomPoint, out hit, Mathf.Infinity, NavMesh.AllAreas)) {
            result = hit.position;
        }
    }
        
    public void TeleportToRoad()
    {
        
        Vector3 point;
        RandomPoint(transform.position, range, out point);
        Debug.Log("teleport" + point);
        agent.Warp(point);
		agent.destination = Safety.position;
    }
}
