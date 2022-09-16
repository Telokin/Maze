using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using Enemy;

namespace UI
{
    public class HardModeController : MonoBehaviour
    {

        [SerializeField] private EnemyBehaviour[] _hardModeEnemies;
        [SerializeField] private GameObject _hardModeEnemiesHolder;
        [SerializeField] private GameObject _easyModeEnemiesHolder;

        private void Start()
        {
            GameEvents.gameEvents.onPlayerCompleteLvl += HardMode;
        }

        private void HardMode()
        {
            _easyModeEnemiesHolder.SetActive(false);
            _hardModeEnemiesHolder.SetActive(true);
            for (int i = 0; i < _hardModeEnemies.Length; i++)
            {
                _hardModeEnemies[i].gameObject.SetActive(true);
                _hardModeEnemies[i].SpeedMultiplayer = 6;
            }

        }
    }
}
