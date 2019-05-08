using UnityEngine;
using System.Collections;

public class UIAnimations : MonoBehaviour {

    Animator anim;
    UIController uc;
    
	void Start ()
    {
        anim = GetComponent<Animator>();
        uc = FindObjectOfType<UIController>();
	}
	
    void Update()
    {
        anim.SetBool("paused", uc.Paused());
      
    }
}
