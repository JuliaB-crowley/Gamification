using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    public Vector3 playerCoordinates;
    public Player playerScript;
    public EnnemySpawn zoneScript;
    // Start is called before the first frame update
    void Awake()
    {
        playerCoordinates = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        zoneScript = GameObject.FindGameObjectWithTag("Zone").GetComponent<EnnemySpawn>();

    }

    public void Die()
    {
        //Debug.Log("bouum");
        playerScript.UpdateScore();
        zoneScript.MonsterListRemove();
        Destroy(gameObject);
    }
}
