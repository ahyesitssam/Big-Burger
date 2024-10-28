using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    RaycastHit hitData;
    public bool isHolding = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    // Update is called once per frame
    private void Update()
    {
        // If the player clicks, create a ray from the center of their view
        if (Input.GetMouseButtonDown(0))
        {
            fireRay();
        }
        
    }

    public bool getPlayerHolding()
    {
        return isHolding;
    }

    private void fireRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10);

        float hitDistance = hitData.distance;
        string hitTag = hitData.collider.tag;
        Debug.Log("Ray hit " + hitTag + " from distance " + hitDistance);   
    }

  
}
