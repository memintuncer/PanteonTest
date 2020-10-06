using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Animator anim;
    private Vector3 startpos;
    public NavMeshAgent agent;
    public Camera cam;
    public Transform Finish;
    public GameObject player;
    [SerializeField] float destinationReachedTreshold;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        startpos = transform.position;
        agent.SetDestination(Finish.position+new Vector3 (0,0,1f));
        anim.SetBool("Run", true);
    }

    
    void Update()
    {
        if (player.gameObject.GetComponent<PlayerController>().isStart == true)
        {
            
            
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Destroy(gameObject);
                    }
                }
            }

            else
            {
                Run();
            }

        }

       
    }


    void Run()
    {
        

        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            transform.position = startpos;

        }

    }

    


}




