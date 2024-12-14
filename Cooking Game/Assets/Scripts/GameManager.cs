using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject Player;
    public int gameState;
    public bool paused;
    public bool inMenu;
    

    void Start()
    {
        updateGameState(0); //Main menu
        paused = false;
        inMenu = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (!paused)
            {
                paused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                unlockCursor();
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
                Player.SetActive(false);

            }
            else if (gameState == 1) // Tutorial
            {
                mainMenu.SetActive(false);
                Player.SetActive(true);
                lockCursor();
            }
        }
    }
    
    public void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   

} // End Class
