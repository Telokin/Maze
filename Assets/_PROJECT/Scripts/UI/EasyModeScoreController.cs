using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using TMPro;

namespace UI
{
    public class EasyModeScoreController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _easyModecoins;
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _score;

        private void Start()
        {
            GameEvents.gameEvents.onGetPoint += ScoreUpdate;
            _scoreText.text = "Score: " + "0" + " / " + _easyModecoins.Length.ToString();
        }

        private void OnDestroy()
        {
            GameEvents.gameEvents.onGetPoint -= ScoreUpdate;
        }

        private void ScoreUpdate()
        {
            _score++;
            _scoreText.text = "Score: " + _score.ToString() + " / " + _easyModecoins.Length.ToString();
            if(_score == _easyModecoins.Length)
            {
                GameEvents.gameEvents.PlayerCompleteLevel();
            }
        }
    }
}
