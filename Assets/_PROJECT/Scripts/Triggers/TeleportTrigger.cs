using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Trigger {
    public class TeleportTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _teleportOut;
        [SerializeField] private GameObject _player;
        //[SerializeField] private float _rotateAfterTeleport;


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                _player.gameObject.SetActive(false); 
                other.transform.position = _teleportOut.position;
                _player.gameObject.SetActive(true);
            }
            if (other.tag == "Enemy")
            {
                other.transform.position = _teleportOut.position;
            }
        }
    }
}
