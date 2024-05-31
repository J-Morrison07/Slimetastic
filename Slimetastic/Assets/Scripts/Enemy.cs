using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Animator animator;
    public bool agro = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agro)
        {
            agent.destination = player.position; 
        } 
        if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("walking", false);
        } else
        {
            animator.SetBool("walking", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        agro = true;
    }

    private void OnTriggerExit(Collider other)
    {
        agro = false;
    }
}
