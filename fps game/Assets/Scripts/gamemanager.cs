using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    
    // Instance
    public static gamemanager instance;


    void Awake()
    {
        // Set the instance to this script
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

        // Toggle pause menu and cursor
        gameUI.instance.TogglePauseMenu(gamePaused);

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }


    public void AddScore(int score)
    {
        curScore += score;

        //Update score text
        gameUI.instance.UpdateScoreText(curScore);

        // Have enough points to win?
        if(curScore >= scoreToWin)
        {
            WinGame();
        }
    }


    void WinGame()
    {
        // Show win screen
        gameUI.instance.SetEndGameScreen(true, curScore);
    }


    public void LoseGame()
    {
        // Load and set end game screen
        gameUI.instance.SetEndGameScreen(false, curScore);
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
