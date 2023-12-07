using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    private bool _isGamePaused = false;
 
    private void GamePause()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
