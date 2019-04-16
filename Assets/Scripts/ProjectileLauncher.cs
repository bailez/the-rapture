using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {
    public float destroyTime;
    PlayerController pc;


    void Start ()
    {
        pc = FindObjectOfType<PlayerController>();
        if (pc.Position() == 0)
            this.gameObject.transform.localScale = new Vector3(1,1,1);
       
        else
            this.gameObject.transform.localScale = new Vector3(-1,1,1);

        StartCoroutine(autoDestroy(destroyTime, this.gameObject));
	}
	
    IEnumerator autoDestroy(float seg, GameObject destroyable)
    {
        yield return new WaitForSeconds(seg);
        Destroy(destroyable);
    }
}
