using UnityEngine;
using UnityEngine.AI;

public class AICatControl : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent == null)
        {
            return;
        }

        agent.SetDestination(target.transform.position);
    }
}