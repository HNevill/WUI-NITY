using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationExample : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public SpawnAndMove myPrefab;
    public int noOfAgents = 40;
    public GameObject Safehouse;

    public MeshFilter roadMeshParent;
    private Mesh roadMesh;
    

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

        transform.position = roadMeshParent.transform.position;
        transform.rotation = roadMeshParent.transform.rotation;
        roadMesh = roadMeshParent.mesh;

        var points = evenlyDistributedPointsOnMesh(noOfAgents);
        for (int i = 0; i < noOfAgents; i++)
        {
            var agent = Instantiate(myPrefab, transform.position, Quaternion.identity, transform);
            agent.transform.localPosition = Vector3.Scale(points[i], roadMeshParent.transform.lossyScale);
            agent.SetTarget(Safehouse);
            agent.TeleportToRoad();
        }
    }

    List<Vector3> evenlyDistributedPointsOnMesh(int pointCount) {

        var result = new List<Vector3>();
        int spacing = roadMesh.vertexCount / pointCount;



        for (int i = 0; i< pointCount; i++) {
            var point = roadMesh.vertices[i * spacing];

            //scale?
            result.Add(point);
        }
        return result;
    }
}
        
