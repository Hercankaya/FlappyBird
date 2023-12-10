using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    private void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
