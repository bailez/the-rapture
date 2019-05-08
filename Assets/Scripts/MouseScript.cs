using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {
    
    PlayerController pc;
    PlayerCombat pk;
    LoseSystem ls;
    UIController uc;
    public bool right;


    void Start()
    {
        uc = FindObjectOfType<UIController>();
        ls = FindObjectOfType<LoseSystem>();
        pk = FindObjectOfType<PlayerCombat>();
        pc = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (!ls.Lose())
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && !uc.Paused())
            {
                pc.controlChar(true);
                pk.shoot();

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !uc.Paused())
            {
                pc.controlChar(false);
                pk.shoot();
            }
        }
    }
   

	void OnMouseDown()
    {
       if (!ls.Lose() && !uc.Paused())
        {
            pc.controlChar(right);
            pk.shoot();
            //Debug.Log(right);
        }     
   }
}
