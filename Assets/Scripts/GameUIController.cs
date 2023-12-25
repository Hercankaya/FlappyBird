using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [SerializeField] Image PlayImage;
    [SerializeField] Image PauseImage;
    public GameObject DeadUICanvas;
    public GameObject GameUICanvas;
    public GameObject TutorialUICanvas;
    public Text ScoreText;
    public TextMeshProUGUI DeadUI;
    public GameManager GameManager;
    
    private void Start()
    {
        TutorialUICanvas.SetActive(true);
        GameUICanvas.SetActive(true);
    }
    private void Update()
    {
        UpdateScoreUI();
    }
    private void OnEnable()
    {
        GameEvents.OnPlayerStateChanged += HandlePlayerStateChanged;
        GameEvents.OnGamePausedStateChanged += HandleGamePausedStateChanged;
        GameEvents.OnGround += DeadStateUIActive;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerStateChanged -= HandlePlayerStateChanged;
        GameEvents.OnGamePausedStateChanged -= HandleGamePausedStateChanged;
        GameEvents.OnGround -= DeadStateUIActive;
    }

    private void HandlePlayerStateChanged(PlayerStateBase newState)
    {
        if (!(newState is PlayerStateIdle)) {

            if (TutorialUICanvas != null)
            {
                TutorialUICanvas.SetActive(false);
            }
        }
    }
    private void DeadStateUIActive()
    {
        if (DeadUICanvas != null && GameUICanvas != null)
        {
            DeadUICanvas.SetActive(true);
            GameUICanvas.SetActive(false);
            DeadUI.text = GameManager.Score.ToString();
        }
    }
    private void UpdateScoreUI()
    {
        if (ScoreText != null)
        {
            ScoreText.text = GameManager.Score.ToString();
        }
    }

    //Pause butonun ýmage deðiþikliði .
    private void HandleGamePausedStateChanged(bool isGamePaused)
    {
       
        if (isGamePaused)
        {
            PauseImage.enabled = false;
            PlayImage.enabled = true;
            //Debug.Log("Oyun durdu ");
        }
        else
        {
            PlayImage.enabled = false;
            PauseImage.enabled = true;
            //Debug.Log("Oyun baþladý ");
        }
    }



}
