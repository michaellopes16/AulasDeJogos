using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GostAgent : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent gostAgent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gostAgent = gameObject.GetComponent<NavMeshAgent>();

        gostAgent.updateRotation = false;
        gostAgent.updateUpAxis = false;
        gostAgent.stoppingDistance = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        gostAgent.SetDestination(player.transform.position);
    }
}
