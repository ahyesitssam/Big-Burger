using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
   [SerializeField] private GameObject rawBurgerHolding;
    private Player P;

    private void Start()
    {
        P = GetComponent<Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                rawBurgerHolding.SetActive(true);
                Debug.Log("picked up raw burger");  
                P.isHolding = true;
            }
        }
    }
}
