using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace UI
{
    public class HardCoin : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameEvents.gameEvents.GethardPoint();
                gameObject.SetActive(false);
            }
        }
    }
}
