using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace UI
{
    public class Coin : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameEvents.gameEvents.GetPoint();
                gameObject.SetActive(false);
            }
        }
    }
}
