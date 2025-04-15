using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator anim;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }

   
    void Update()
    {
        
        agent.SetDestination(target.position);

        if (agent.velocity==Vector3.zero)
        {
            anim.SetBool("isMoving", false); //ivmesine bak�yoruz karakterin  0a e�itse ismoving false
        }
        else
        {

            anim.SetBool("isMoving", true);
        }

    }
}
