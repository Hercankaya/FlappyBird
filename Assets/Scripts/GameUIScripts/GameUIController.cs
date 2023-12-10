using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    private bool _isGamePaused = false;
    public GameObject DeadUICanvas;
    public GameObject GameUICanvas;
    public GameObject TutorialUICanvas;
    public Text ScoreText;
    public TextMeshProUGUI DeadUI;
    private int _score ;
    
    private void Start()
    {
        TutorialUICanvas.SetActive(true);
        GameUICanvas.SetActive(true);
        _score = 0;

    }

    //
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

    private void HandlePlayerStateChanged(PlayerStateBase newState)
    {
        if (newState is PlayerStateDead)
        {
            if (DeadUICanvas != null && GameUICanvas != null )
            {
                DeadUICanvas.SetActive(true);
                GameUICanvas.SetActive(false);
                DeadUI.text = _score.ToString();
            }
        }
        if (!(newState is PlayerStateIdle)) {

            if (TutorialUICanvas != null)
            {
                TutorialUICanvas.SetActive(false);
            }
        }
    }

    /// 
    private void IncreaseScore()
    {
        _score++;
        
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        if (ScoreText != null) 
        {
            ScoreText.text = _score.ToString();
        }
    }

    /// 

    public void GamePauseToggle()
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

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
