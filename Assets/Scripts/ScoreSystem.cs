using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

    int score, money;
 
    void Start()
    {
        score = 0;
        money = PlayerPrefs.GetInt("money");
        

    }

    public void Numbers(int modifier)
    {
        score++;
        money = money + modifier;
        PlayerPrefs.SetInt("money", money);
        if (score > PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore", score);
    }   

	public int Score()
    {
       
        return score;
    }

    public int Money()
    {
       
        return money;
    }

    public int bruteScore(int divisor)
    {
        int bruteScore, unidades;
        unidades = score % divisor;
        bruteScore = score - unidades;
        return bruteScore;
    }
}
