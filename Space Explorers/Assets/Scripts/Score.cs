using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    uint  score;
    uint maxscore;
    void ChangeScore(uint newScore)
    {
        maxscore = newScore;
    }
    void IncreaseScoreBy(uint iScore)
    {
        if(score >= maxscore)
        {
            score = maxscore;
        }
        else
        {
            score += iScore;
        }
       
    }
    void DecreaseScoreBy(uint iScore)
    {
        if (score-iScore < 0)
        {
            score = 0;
        }
        else
        {
            score -= iScore;
        }
       
    }

}
