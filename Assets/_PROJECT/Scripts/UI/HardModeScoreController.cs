using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using TMPro;

namespace UI
{
    public class HardModeScoreController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hardModecoins;
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _score;

        private void Start()
        {
            GameEvents.gameEvents.onGetHardPoint += ScoreUpdate;
            GameEvents.gameEvents.onDifficultyChanged += StartHardModeScore;
            
        }

        private void OnDestroy()
        {
            GameEvents.gameEvents.onGetHardPoint -= ScoreUpdate;
            GameEvents.gameEvents.onDifficultyChanged -= StartHardModeScore;
        }

        private void StartHardModeScore()
        {
            _scoreText.text = "Score: " + "0" + " / " + _hardModecoins.Length.ToString();
        }

        private void ScoreUpdate()
        {
            _score++;
            _scoreText.text = "Score: " + _score.ToString() + " / " + _hardModecoins.Length.ToString();
            if (_score == _hardModecoins.Length)
            {
                GameEvents.gameEvents.PlayerWin();
            }
        }
    }
}