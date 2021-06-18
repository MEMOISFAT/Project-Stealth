using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDetection : MonoBehaviour
{
    public LayerMask layerMask;
    private Transform player;
    private NavMeshAgent agent;
    public float radius;
    private bool playerDetected;
    public float minDist;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDetected = Physics.CheckSphere(gameObject.transform.position, radius, layerMask, QueryTriggerInteraction.UseGlobal);
        float dist = Vector3.Distance(transform.position, player.position);
        Debug.Log(dist);

        if (playerDetected)
        {
            agent.SetDestination(player.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}
