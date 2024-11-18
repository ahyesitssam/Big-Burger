using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseText;
    [SerializeField] private GameObject Player;
    public int gameState;
    private bool paused;
    

    void Start()
    {
        //updateGameState(0); //Main menu
        paused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameState != 0)
        {
            if (!paused)
            {
                paused = true;
                pauseText.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                paused = false;
                pauseText.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void updateGameState(int gameState)
    {
        if (!paused) // If the game is not paused, update the gameState
        {
            if (gameState == 0) // Main Menu
            {
                mainMenu.SetActive(true);
                
            }
            else if (gameState == 1) // Tutorial
            {
                mainMenu.SetActive(false);
                Instantiate(Player, new Vector3(-0.5f, 0.204999998f, 19.4200001f), Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
  

}
