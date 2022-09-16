using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Events;
using UnityEngine.InputSystem;

namespace Scene
{
    public class GameSceneController : MonoBehaviour
    {
        

        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _lostPanel;
        [SerializeField] private GameObject _lvlComplete;
        [SerializeField] private GameObject _winPanel;

        InputAction inputAction;
        private void Start()
        {
            inputAction = new InputAction(binding: "<UI/RightClick>");
            GameEvents.gameEvents.onPlayerLost += LostGame;
            GameEvents.gameEvents.onPlayerCompleteLvl += LvlComplete;
            GameEvents.gameEvents.onPlayerWin += WinGame;
        }
        private void OnDestroy()
        {
            GameEvents.gameEvents.onPlayerLost -= LostGame;
            GameEvents.gameEvents.onPlayerCompleteLvl -= LvlComplete;
            GameEvents.gameEvents.onPlayerWin -= WinGame;
        }

        private void LvlComplete()
        {
            StartCoroutine(LvlCompleteHolder());
        }

        private IEnumerator LvlCompleteHolder()
        {
            _lvlComplete.SetActive(true);
            yield return new WaitForSeconds(3f);
            _lvlComplete.SetActive(false);
            GameEvents.gameEvents.DifficultyChanged();
            yield return null;
        }

        private void WinGame()
        {
            _winPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        public void RestartGame()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            Cursor.visible = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void LostGame()
        {
            _lostPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        public void ResumeGame()
        {
            _pausePanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        private void PauseGame()
        {
            _pausePanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
            Cursor.visible = true;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
