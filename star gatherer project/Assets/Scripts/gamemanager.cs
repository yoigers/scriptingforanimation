using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public int starsToWin;
    public int curStarcount;
    public bool gamePaused;


    //Instance
    public static gamemanager instance;


    void Awake()
    {
        // Instance is set to this
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }


    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        // Toggle pause menu
        gameUI.instance.TogglePauseMenu(gamePaused);
    }


    public void AddStars(int starCount)
    {
        curStarcount += starCount;

        // Update star score text
        gameUI.instance.UpdateStarText(curStarcount);

        // Do you have enough stars to win???
        if(curStarcount >= starsToWin)
        {
            WinGame();
        }
    }


    void WinGame()
    {
        // Win screen
        gameUI.instance.SetEndGameScreen(true, curStarcount);
    }


    public void LoseGame()
    {
        // Load end game screen
        gameUI.instance.SetEndGameScreen(false, curStarcount);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            TogglePauseGame();
        }
    }
}
