using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Trigger
{
    public class EnemyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                GameEvents.gameEvents.PlayerHit();
            }
        }
    }
}
