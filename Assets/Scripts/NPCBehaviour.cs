using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{

    public Player player;
    public float chaseTriggerDistance;
    public NavMeshAgent agent;
    public List<Vector3> patrolPositions = new List<Vector3>();


    void Update()
    {
        Transform playerTransform = player.GetComponent<Transform>();
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance < chaseTriggerDistance && distance > 2)
        {
            agent.SetDestination(playerTransform.position);

        }

        else if (agent.hasPath == false && patrolPositions.Count != 0)
        {
            agent.SetDestination(patrolPositions[Random.Range(0, patrolPositions.Count)]);
        }
    }
}
