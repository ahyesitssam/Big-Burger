using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private GameObject computerMenu;
    [SerializeField] private GameObject orderMenu;

    [SerializeField] private String[] currentBurger;
    private int currentIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


    private void clearArray()
    {
        currentIndex = 0;
    }
}
