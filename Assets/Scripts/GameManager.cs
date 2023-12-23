using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGamePaused = false;
    private float _score ;
    public float Score => _score;

 
    private void Start()
    {
        _score = 0;
    }

    private void Update()
    {
        
    }
    private void GamePauseToggle()
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

        GameEvents.TriggerGamePausedStateChanged(_isGamePaused);
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;

    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;

    }
    private void OnEnable()
    {
        GameEvents.OnPlayerStateChanged += HandlePlayerStateChanged;
        GameEvents.OnScoreIncreased += IncreaseScore;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerStateChanged -= HandlePlayerStateChanged;
        GameEvents.OnScoreIncreased -= IncreaseScore;
    }
    //karakterin ölme durumunda oyunun durdurulmasý.
    private void HandlePlayerStateChanged(PlayerStateBase newState)
    {
        if (newState is PlayerStateDead)
        {
            Time.timeScale = 0f;
        }
    }
    //Scorun arttýrýlmasý
    private void IncreaseScore()
    {
        _score++;
    }

    //MenuScene den GameScene geçiþ .
    private void GameScene()
    {
        SceneManager.LoadScene("GameScene");

    }
   

}
