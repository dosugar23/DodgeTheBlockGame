using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject CreditUI;
    public GameObject SettingUI;
    public float slowness = 10f; // slow motion khi ta thua
    [SerializeField] TextMeshProUGUI scoreTextComponent;  //text score
    [SerializeField] TextMeshProUGUI highScoreTextComponent; //highscore
    private int score = 0;  //score hien tai 
    private int highscore = 0; //highscore
    private float secondTimer = 0f;    //dem thoi gian

    public void EndGame() 
    {
        score = 0;
        StartCoroutine(RestartLevel());
        // Debug.Log("End");
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt ("highscore", highscore);
        highScoreTextComponent.text = "High Score: " + highscore.ToString();
    }
    IEnumerator RestartLevel() {

        Time.timeScale = 1f / slowness; // khien time chay se giam tan toi 0.1 frame/s
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness; // de xu ly hinh anh duoc muot hon

        yield return new WaitForSeconds(2f / slowness);
   
        Time.timeScale = 1f; // reset time ve bt
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness; // tra lai fixdeltaTime ban dau

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        secondTimer = secondTimer + Time.deltaTime;
        if (secondTimer >= 0.1f)
            {
            AddScore();
            secondTimer = secondTimer - 0.1f;
            }
        if (score > highscore)
        {
            highscore = score;
            highScoreTextComponent.text = "High Score: " + highscore.ToString();
            PlayerPrefs.SetInt ("highscore", highscore);
        }
         
        
    }
     
    private void AddScore()
    {
        score++;
        scoreTextComponent.text = "Score: " + score.ToString();
    }
    private void ResetScore()
    {
        score = 0;
    }

    public void exitgame() {
        Application.Quit();
    }

    public void openCredit() {
        CreditUI.SetActive(true); 
    }

    public void closeCredit() {
        CreditUI.SetActive(false);
    }
    public void openSetting() {
        SettingUI.SetActive(true); 
    }

    public void closeSetting() {
        SettingUI.SetActive(false);
    }

    public void startGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void returnToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
