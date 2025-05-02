using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public Transform target;
    public float killDistance = 1.2f;

    [Header("UI")]
    [Tooltip("Inspector'dan sürükle býrak: GameOverPanel objesi")]
    public GameObject gameOverPanel;

    private NavMeshAgent agent;
    private Animator anim;
    private bool gameOverTriggered = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // Panel oyunda baþta kapalý olsun:
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameOverTriggered)
            return;  // bir kez tetiklendiyse artýk iþlemleri pas geç

        agent.SetDestination(target.position);
        bool isMoving = agent.velocity.sqrMagnitude > 0.01f;
        anim.SetBool("isMoving", isMoving);

        float dist = Vector3.Distance(transform.position, target.position);
        if (dist <= killDistance)
        {
            gameOverTriggered = true;

            // Hareketi durdur:
            agent.isStopped = true;
            anim.SetBool("isMoving", false);

            // Paneli aç, zamaný durdurabilirsin:
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
