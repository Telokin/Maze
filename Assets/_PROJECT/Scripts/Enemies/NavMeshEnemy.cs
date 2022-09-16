using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class NavMeshEnemy : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Vector3 _finalDestination;
        private float _xAxis;
        private float _zAxis;

        public Vector3 FinalDestination { get => _finalDestination; set => _finalDestination = value; }
        public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set => _navMeshAgent = value; }

        private void Awake()
        {
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            NavMeshAgent.autoBraking = false;

            _xAxis = Random.Range(-24, 24);
            _zAxis = Random.Range(-24, 24);
            NewPath();
        }

        private void Update()
        {

            NavMeshPath path = new NavMeshPath();
            NavMeshAgent.CalculatePath(FinalDestination, path);
            NavMeshAgent.SetPath(path);
            if (NavMeshAgent.remainingDistance < 0.2f)
            {
                NewPath();

            }

            NavMeshAgent.destination = FinalDestination;
        }

        public void NewPath()
        {
            NavMeshHit hit;
            _xAxis = Random.Range(-24, 24);
            _zAxis = Random.Range(-24, 24);
            Vector3 pointOnGround = new Vector3(_xAxis, 2, _zAxis);
            if (NavMesh.SamplePosition((pointOnGround), out hit, 24, 1))
            {
                FinalDestination = hit.position;
            }

        }

        
    }
}
