using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingShelf : MonoBehaviour
{
    [SerializeField] private GameObject toppingMenu;
    [SerializeField] private GameObject lettuceHolding;
    [SerializeField] private GameObject tomatoHolding;
    [SerializeField] private GameObject cheeseHolding;
    [SerializeField] private GameObject topbunHolding;
    [SerializeField] private GameObject bottombunHolding;

    private Player P;

    private void Start()
    {
        P = GetComponent<Player>();
        toppingMenu.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //If the player is not already holding something, activate the topping menu
            if (Input.GetKeyDown(KeyCode.E))
            {
                    toppingMenu.SetActive(true);
                    Cursor.lockState = CursorLockMode.None; // to unlock cursor
                    Cursor.visible = true; // to make cursor visible
            }
        }
    }

    private void OnTriggerExit(Collider other) //If the menu is still open when the player walks away, close the menu
    {
        if(toppingMenu.activeSelf)
        {
            toppingMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;
        }
    }

    public void lettuce()
    {
        toppingMenu.SetActive(false);
        lettuceHolding.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        P.isHolding = true;
    }

    public void cheese()
    {
        toppingMenu.SetActive(false);
        cheeseHolding.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        P.isHolding = true;
    }

    public void tomato() 
    { 
        toppingMenu.SetActive(false);
        tomatoHolding.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        P.isHolding = true;
    }

    public void topBun()
    {
        toppingMenu.SetActive(false);
        topbunHolding.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        P.isHolding = true;
    }

    public void bottomBun()
    {
        toppingMenu.SetActive(false);
        bottombunHolding.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        P.isHolding = true;
    }
}
