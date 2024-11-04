using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseText;
    public int gameState;
    private bool paused;
    

    // Start is called before the first frame update
    void Start()
    {
        gameState = 0; //Main menu
        paused = false;
    }

    // Update is called once per frame
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

    public void updateGameState(int temp)
    {
        gameState = temp;
        if (!paused)
        {

        }
        if (gameState == 0) // Main Menu
        {
            mainMenu.SetActive(true);
        } 
        else if (gameState == 1) // Tutorial
        {
            mainMenu.SetActive(false);
        }
    }
  

}
