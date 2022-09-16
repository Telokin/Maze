using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace UI
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameObject _easyModeEnemies;

        [SerializeField] private GameObject _hardModeEnemies;
        [SerializeField] private GameObject _easyModeCoins;
        [SerializeField] private GameObject _hardModeCoins;

        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject[] _safeZones;

        void Start()
        {
            _easyModeEnemies.SetActive(true);
            _hardModeEnemies.SetActive(false);
            _easyModeCoins.SetActive(true);
            _hardModeCoins.SetActive(false);
            GameEvents.gameEvents.onDifficultyChanged += ChangeDifficulty;
        }

        private void OnDestroy()
        {
            GameEvents.gameEvents.onDifficultyChanged -= ChangeDifficulty;
        }

        private void ChangeDifficulty()
        {
            int randomSafeZone = Random.Range(0, _safeZones.Length - 1);
            _player.gameObject.SetActive(false);
            _player.transform.position = _safeZones[randomSafeZone].transform.position;
            _easyModeEnemies.SetActive(false);
            _hardModeEnemies.SetActive(true);
            _easyModeCoins.SetActive(false);
            _hardModeCoins.SetActive(true);
            _player.gameObject.SetActive(true);
        }
    }
}
