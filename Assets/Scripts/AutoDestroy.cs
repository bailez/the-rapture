using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

    public float seg;
 
    void Start()
    {
        StartCoroutine(autoDestroy());
    }
	public IEnumerator autoDestroy()
    {
        yield return new WaitForSeconds(seg);
        Destroy(gameObject);
    }
}
