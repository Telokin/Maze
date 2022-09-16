using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Trigger
{
    public class DoorTrigger : MonoBehaviour
    {
        private DoorController _doorController;

        private void Awake()
        {
            _doorController = GetComponent<DoorController>();
        }
        private void OnTriggerEnter(Collider other)
        {
            GameEvents.gameEvents.DoorTriggerEnter(_doorController.Index);
        }

        private void OnTriggerExit(Collider other)
        {
            GameEvents.gameEvents.DoorTriggerExit(_doorController.Index);
        }
    }
}
