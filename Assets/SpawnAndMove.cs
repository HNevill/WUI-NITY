using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAndMove : MonoBehaviour
{
    public float range = 10.0f;
    bool found_mesh = false;
    private GameObject Safehouse;
	private Transform Safety;

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                found_mesh = true;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    // Start is called before the first frame update
        
    // Update is called once per frame
    void Update()
    {
    	        if (found_mesh == false)
        {
            Vector3 point;
            if (RandomPoint(transform.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                Debug.Log("did a thing");
                NavMeshAgent agent = GetComponent<NavMeshAgent>();

                agent.Warp(point);

                Safehouse = GameObject.FindWithTag("target");
     			Safety = Safehouse.transform;

   				agent.destination = Safety.position;
    

            }
        }
        
    }
}
