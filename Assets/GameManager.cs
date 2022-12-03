using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CreditUI;
    public GameObject SettingUI;
    public float slowness = 10f; // slow motion khi ta thua

    public void EndGame() {
        StartCoroutine(RestartLevel());
        // Debug.Log("End");
    }

    IEnumerator RestartLevel() {

        Time.timeScale = 1f / slowness; // khien time chay se giam tan toi 0.1 frame/s
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness; // de xu ly hinh anh duoc muot hon

        yield return new WaitForSeconds(2f / slowness);
        // luu y la khi xai timeScale se anh huong den waitForSeconds() 
        // vi vay phai chia cho so sloness de chay dung so second 

        Time.timeScale = 1f; // reset time ve bt
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness; // tra lai fixdeltaTime ban dau

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
