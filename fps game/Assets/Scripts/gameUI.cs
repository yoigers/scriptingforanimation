using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    // Instance / Singleton
    public static gameUI instance;

    void Awake()
    {
        // Set instance to this script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void UpdateHealthBar(int curHp, int maxHp)
    {
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;
    }


    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }


    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }


    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }


    public void SetEndGameScreen(bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? "You Win!" : "You Lose!";
        endGameHeaderText.color = won == true ? Color.blue : Color.yellow;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }


    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }


    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }


    public void OnResumeButton()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
