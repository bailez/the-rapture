using UnityEngine;
using System.Collections;

public class LoseSystem : MonoBehaviour {

    bool lose;
    UIController uc;
	void Start () {
        uc = FindObjectOfType<UIController>();
        lose = false;
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            lose = true;
            uc.GameOver();
        }

        
     
    }
    public bool Lose()
    {
        return lose;
    }
}
