using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {

        [SerializeField] private float speedMultiplayer = 3;
        private NavMeshEnemy _navMeshEnemy;
        private float _speed;

        public float SpeedMultiplayer { get => speedMultiplayer; set => speedMultiplayer = value; }

        private void Start()
        {
            _navMeshEnemy = GetComponent<NavMeshEnemy>();
            _speed = _navMeshEnemy.NavMeshAgent.speed;
        }
        void FixedUpdate()
        {
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Player")
                {
                    _navMeshEnemy.FinalDestination = hit.collider.gameObject.transform.position;
                    _navMeshEnemy.NavMeshAgent.speed = _speed * SpeedMultiplayer;
                }
                else
                {
                    _navMeshEnemy.NavMeshAgent.speed = _speed;
                }
            }
        }
    }
}
