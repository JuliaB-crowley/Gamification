using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammos : MonoBehaviour
{
    public float speed;
    public Vector3 playerCoordinates;
    public Player playerScript;
    // Start is called before the first frame update
    void Awake()
    {
        playerCoordinates = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerCoordinates, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, playerCoordinates) < 0.1f)
        {
            // Swap the position of the cylinder.
            //Debug.Log("est arrivé");
            playerScript.TakeDamages();
            Destroy(gameObject);
        }
    }

    public void Destroying()
    {
        Destroy(gameObject);
    }
}
