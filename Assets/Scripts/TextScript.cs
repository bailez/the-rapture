using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

    ScoreSystem ss;
    Text text;
    public string which,more;
    void Start()
    {
        
        text = GetComponent<Text>();
        ss = FindObjectOfType<ScoreSystem>();
    }

   void Update()
    {
        if (which == "Highscore")
            text.text = more + PlayerPrefs.GetInt("highScore") ;

        if (which == "Score")
           text.text = more + ss.Score();
       
        if(which == "Money")
            text.text = more + "$" + ss.Money();

    }
}
