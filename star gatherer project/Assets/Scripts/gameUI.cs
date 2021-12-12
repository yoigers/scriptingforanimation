using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI starText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    // Instance
    public static gameUI instance;


    void Awake()
    {
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

    public void UpdateStarText(int stars)
    {
        starText.text = "Star x " + stars;
    }


    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }


    public void SetEndGameScreen(bool won, int stars)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? "You made it!" : "You died.";
        endGameHeaderText.color = won == true ? Color.yellow : Color.red;
        endGameScoreText.text = "<b>Stars</b>\n" + stars;
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
