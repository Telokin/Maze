using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Trigger
{
    public class PlayerDoorTrigger : MonoBehaviour
    {
        private DoorController _doorController;

        private void Awake()
        {
            _doorController = GetComponent<DoorController>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                GameEvents.gameEvents.DoorTriggerEnter(_doorController.Index);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                GameEvents.gameEvents.DoorTriggerExit(_doorController.Index);
            }
        }
    }
}
