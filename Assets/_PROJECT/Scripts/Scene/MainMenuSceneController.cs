using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class MainMenuSceneController : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
