using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    /*int score1;
    int score2;
    int score3;
    int score4;
    int score5;
    int score6;
    int score7;
    int score8;
    int score9;*/


    int score = 0;
    int scoreb = 0;
    int scorec = 0;
    List<int> ScoreList = new List<int>();
    //List<int> ScoreList2 = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        //RankingGenerator();
        score = 2;
        scoreb = 3;
        scorec = 1;
        ScoreList.Add(score);
        ScoreList.Add(scoreb);
        ScoreList.Add(scorec);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= ScoreList.Count;)
        {
            if (ScoreList[i]-ScoreList[i+1]>0)
            {
                int exchange = ScoreList[i];
                ScoreList[i] = ScoreList[i + 1];
                ScoreList[i + 1] = exchange;
                i--;
                if (i<1)
                {
                    i = 1;
                }
            } else
            {
                i++;
            }

            Debug.Log(ScoreList[i]);
        }



        for (int i = 0; i <= ScoreList.Count; i++)
        {
            Debug.Log(ScoreList[i]);
        }


    }


    /*void RankingGenerator()
    {
        score1 = Random.Range(5,51);
        score2 = Random.Range(5,51);
        score3 = Random.Range(5,51);
        score4 = Random.Range(5,51);
        score5 = Random.Range(5,51);
        score6 = Random.Range(5,51);
        score7 = Random.Range(5,51);
        score8 = Random.Range(5,51);
        score9 = Random.Range(5,51);
    }*/



}



