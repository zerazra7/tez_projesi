using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerr : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.SetDestination(target.position);
        if (navMeshAgent.velocity==Vector3.zero)
        {
            anim.SetBool("IsMoving?", false);
        }
        else
        {
            anim.SetBool("IsMoving?", true);
        }
    }
}
