using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _range;
    
    private Vector3 _target;
    private Enemy _enemy;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    
    private IEnumerator Patrouling()
    {
        while (true)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (TryRandomPoint(transform.position, _range, out _target))
                {
                    Debug.DrawRay(_target, Vector3.up, Color.blue, 2f);
                    _agent.SetDestination(_target);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void StartPatroul(float patroulSpeed)
    {
        _agent = _enemy.Agent;
        _agent.speed = patroulSpeed;
        StartCoroutine(Patrouling());
    }

    private bool TryRandomPoint(Vector3 center, float range, out Vector3 randomPoint)
    {
        Vector3 randomSpherePoint = center + Random.insideUnitSphere * range;
        if (NavMesh.SamplePosition(randomSpherePoint,  out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            randomPoint = hit.position;
            return true;
        }

        randomPoint = Vector3.zero;
        return false;
    }
}
