using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{

    int score = 0;
    int score = 0;
    int score = 0;
    List<int> ScoreList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        score = 2; //récupérer le score du mini-jeu de Julia
        score2 = 3;
        score3 = 1;
        ScoreList.Add(score,score2,score3);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<ScoreList.Count; i++)
        {
            /*if (ScoreList[i]-ScoreList[i+1]>0
            {
                int exchange = ScoreList[i];
            }*/
            Debug.Log(ScoreList[i]);
        }

        ScoreList.Sort;

        for (int i = 0; i < ScoreList.Count; i++)
        {
            Debug.Log(ScoreList[i]);
        }

    }
}
