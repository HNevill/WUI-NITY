using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{

	public Transform goal;
	public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
      NavMeshAgent agent = GetComponent<NavMeshAgent>();
      agent.destination = goal.position;
    }


    public void Explode()
    {
    	explosion.gameObject.transform.SetParent(null);
    	explosion.Play();

    	Destroy(gameObject);
    	Destroy(explosion.gameObject, explosion.main.duration);
    }
}
