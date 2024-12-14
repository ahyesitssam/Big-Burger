using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float rayDistance = 50f;
    public bool isHolding = false;
    public string playerHolding = "";
    private int toppingCount = 0;

    [SerializeField] private GameObject toppingMenu;
    [SerializeField] private GameObject rawPattyHolding;
    [SerializeField] private GameObject cookedPattyHolding;
    [SerializeField] private GameObject winScreen;

    [Header("----Plate Toppings----")]
    [SerializeField] private GameObject plateBottomBun;
    [SerializeField] private GameObject plateTopBun;
    [SerializeField] private GameObject plateLettuce;
    [SerializeField] private GameObject plateTomato;
    [SerializeField] private GameObject plateCheese;
    [SerializeField] private GameObject plateCookedPatty;

    [Header("----Pan Patties----")]
    [SerializeField] private GameObject panRawPatty;

    private GameManager GM;
    private UIManager UI;


    // Start is called before the first frame update
    void Start()
    {

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        UI = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (toppingCount == 6)
        {
            winScreen.SetActive(true);
            GM.unlockCursor();
            GM.inMenu = true;
        }



        // If the player clicks, create a ray from the center of their view
        if (!GM.inMenu && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Check if the object has a tag
                string objectTag = hit.collider.tag;

                if (!string.IsNullOrEmpty(objectTag))
                {
                    Debug.Log($"An object tagged '{objectTag}' was hit!");

                    if (objectTag == "Computer") // Use the computer
                    {
                        UI.useComupter();
                        GM.inMenu = true;

                    } else if (objectTag == "Fridge") // Get a raw patty
                    {
                        if (!isHolding)
                        {
                            isHolding = true;
                            playerHolding = "Raw Patty";
                            rawPattyHolding.SetActive(true);
                        }
                    } else if (objectTag == "Plate")
                    {
                        if (isHolding)
                        {
                            isHolding = false;
                            if (playerHolding == "Bottom Bun")
                            {
                                UI.bottombunHolding.SetActive(false);
                                plateBottomBun.SetActive(true);
                            } else if (playerHolding == "Top Bun")
                            {
                                UI.topbunHolding.SetActive(false);
                                plateTopBun.SetActive(true);
                            } else if (playerHolding == "Lettuce")
                            {
                                UI.lettuceHolding.SetActive(false);
                                plateLettuce.SetActive(true);
                            } else if (playerHolding == "Tomato")
                            {
                                UI.tomatoHolding.SetActive(false);
                                plateTomato.SetActive(true);
                            } else if (playerHolding == "Cheese")
                            {
                                UI.cheeseHolding.SetActive(false);
                                plateCheese.SetActive(true);
                            } else if (playerHolding == "Cooked Patty")
                            {
                                cookedPattyHolding.SetActive(false);
                                plateCookedPatty.SetActive(true);
                            }

                            toppingCount++;
                            playerHolding = "";
                        }
                    } else if (objectTag == "Shelf")
                    {
                        toppingMenu.SetActive(true);
                        GM.unlockCursor();
                        GM.inMenu = true;
                    } else if (objectTag == "Pan")
                    {
                        if (playerHolding == "Raw Patty")
                        {
                            rawPattyHolding.SetActive(false);
                            panRawPatty.SetActive(true);
                            StartCoroutine(cookPatty());
                        } 
                    }
                }
            }
        }
    }

    private IEnumerator cookPatty()
    {
        yield return new WaitForSeconds(5);

        Debug.Log("Patty Cooked");
        panRawPatty.SetActive(false);
        cookedPattyHolding.SetActive(true);
        playerHolding = "Cooked Patty";
    }

    

  
}
