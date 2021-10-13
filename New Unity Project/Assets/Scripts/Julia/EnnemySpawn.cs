using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawn : MonoBehaviour
{
    public Vector2 centerOfArea, sizeOfArea;
    public List<GameObject> ennemies;
    public int numberAlreadySpawned =0;
    float timeSinceLastSpawn;
    public float timeBetweenSpawn;
    public int numberAlive, numberCap = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawn && numberAlive <= numberCap)
        {
            timeSinceLastSpawn = 0;
            int index = Random.Range(0, ennemies.Count);
            //Vector2 random = 
            Vector2 pos = centerOfArea + new Vector2(Random.Range(-sizeOfArea.x / 2, sizeOfArea.x / 2), Random.Range(-sizeOfArea.y / 2, sizeOfArea.y / 2));
            //Debug.Log(pos);
            Instantiate(ennemies[index], pos, Quaternion.identity);
            numberAlreadySpawned++;
            MonsterListAdd();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centerOfArea, sizeOfArea);
    }

    void MonsterListAdd()
    {
        numberAlive++;
    }

    public void MonsterListRemove()
    {
        numberAlive--;
    }
}
