using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject computerMenu;
    [SerializeField] private GameObject orderMenu;
    

    [SerializeField] private String[] currentBurger;
    private int currentIndex = 0;
    private GameManager GM;


    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playButton()
    {
        GM.updateGameState(1); // Start tutorial
    }

    public void quitButton()
    {
        Application.Quit();
    }


    public void takeOrderButton()
    {
        computerMenu.SetActive(false);
        orderMenu.SetActive(true);
    }

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
