using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ennemy"))
                {
                    hit.collider.GetComponent<Ennemies>().Die();
                }

                if(hit.collider.CompareTag("Ammo"))
                {
                    hit.collider.GetComponent<Ammos>().Destroying();
                }
                    

                    
               
            }
        }
    }

}
