using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject computerMenu;
    [SerializeField] private GameObject orderText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject toppingMenu;

    [Header("----Toppings Held----")]
    public GameObject lettuceHolding;
    public GameObject tomatoHolding;
    public GameObject cheeseHolding;
    public GameObject topbunHolding;
    public GameObject bottombunHolding;

    [SerializeField] private String[] currentBurger;
    private int currentIndex = 0;
    private GameManager GM;
    private Player P;


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        P = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void useComupter()
    {
        computerMenu.SetActive(true);
        GM.unlockCursor();
    }



    public void playButton()
    {
        GM.updateGameState(1); // Start tutorial
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void resumeButton()
    {
        GM.paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GM.lockCursor();
    }

    public void closeComputer()
    {
        computerMenu.SetActive(false); 
        GM.lockCursor();
        GM.inMenu = false;
    }

    public void takeOrderButton()
    {
        orderText.SetActive(true);
        closeComputer();
    }


    // ---- Topping Shelf Buttons ----

    private void closeShelf()
    {
        GM.lockCursor();
        toppingMenu.SetActive(false);
        P.isHolding = true;
        GM.inMenu = false;
    }

    public void lettuce()
    {
        if (P.isHolding)
        {
            closeShelf();
        } else
        {
            P.playerHolding = "Lettuce";
            lettuceHolding.SetActive(true);
            closeShelf();
        }
    }

    public void cheese()
    {
        if (P.isHolding)
        {
            closeShelf();
        }
        else
        {
            P.playerHolding = "Cheese";
            cheeseHolding.SetActive(true);
            closeShelf();
        }
    }

    public void tomato()
    {
        if (P.isHolding)
        {
            closeShelf();
        }
        else
        {
            P.playerHolding = "Tomato";
            tomatoHolding.SetActive(true);
            closeShelf();
        }
    }

    public void topBun()
    {
        if (P.isHolding)
        {
            closeShelf();
        }
        else
        {
            P.playerHolding = "Top Bun";
            topbunHolding.SetActive(true);
            closeShelf();
        }
    }

    public void bottomBun()
    {
        if (P.isHolding)
        {
            closeShelf();
        }
        else
        {
            P.playerHolding = "Bottom Bun";
            bottombunHolding.SetActive(true);
            closeShelf();
        }
    }



    // ---- Build Burger Buttons ----

    public void addTopBun()
    {
        currentBurger[currentIndex] = "Top Bun";
        currentIndex++;
    }

    public void addBottomBun()
    {
        currentBurger[currentIndex] = "Bottom Bun";
        currentIndex++;
    }

    public void addPatty()
    {
        currentBurger[currentIndex] = "Patty";
        currentIndex++;
    }

    public void addLettuce()
    {
        currentBurger[currentIndex] = "Lettuce";
        currentIndex++;
    }

    public void addTomato()
    {
        currentBurger[currentIndex] = "Tomato";
        currentIndex++;
    }

    public void addCheese()
    {
        currentBurger[currentIndex] = "Cheese";
        currentIndex++;
    }




    public void clearArray()
    {
        while(currentBurger.Length > 0)
        {
            currentBurger[currentIndex] = null;
        }
        currentIndex = 0;
    }

    public void finishBurger() 
    { 
        //close menu
        //set ticket to active
        //pick up and place it wherever in kitchen to make the order
    }
}
