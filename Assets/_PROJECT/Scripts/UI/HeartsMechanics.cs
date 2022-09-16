using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Events;

namespace UI
{
    public class HeartsMechanics : MonoBehaviour
    {
        [SerializeField] private Image[] hearts;
        private int _heartsAmount;

        private void Start()
        {
            GameEvents.gameEvents.onPlayerHit += LostHeart;
            _heartsAmount = hearts.Length;
        }

        private void OnDestroy()
        {
            GameEvents.gameEvents.onPlayerHit -= LostHeart;
        }

        private void LostHeart()
        {
            hearts[_heartsAmount - 1].gameObject.SetActive(false);
            _heartsAmount--;
            if (_heartsAmount == 0)
            {
                GameEvents.gameEvents.PlayerLost();
            }
        }
    }
}
