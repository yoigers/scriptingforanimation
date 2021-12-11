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
        
    }


    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        // Toggle pause menu
        gameUI.instance.TogglePauseMenu(gamePaused);
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
