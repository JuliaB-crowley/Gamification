using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinter : Ennemies
{
    public float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerCoordinates, speed*Time.deltaTime);
        if (Vector3.Distance(transform.position, playerCoordinates) < 0.1f)
        {
            // Swap the position of the cylinder.
            //Debug.Log("est arrivé");
            playerScript.TakeDamages();
            zoneScript.MonsterListRemove();
            Destroy(gameObject);
        }
    }
}
