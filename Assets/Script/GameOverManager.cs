using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI finalScore;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);

        finalScore.text = currentScore.text;

        currentScore.gameObject.SetActive(false);

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("GamePlay");
    }
}