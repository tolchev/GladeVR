using UnityEngine;
using UnityEngine.AI;

public class AICatControl : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (agent != null && animator != null)
        {
            agent.SetDestination(target.transform.position);

            if (agent.remainingDistance > 0.1)
            {
                animator.SetFloat("speed", 1);
            }
            else
            {
                animator.SetFloat("speed", 0);
            }
        }
    }
}