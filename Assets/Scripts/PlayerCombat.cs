using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

    PlayerSkin ps;
    public float delay;
    bool delayMode;
    public Transform launchPos;
    GameObject launch;
    PlayerController pc;
 

    void Start () {
        //PlayerPrefs.SetInt("skinID", pc.skin);

        ps = FindObjectOfType<PlayerSkin>();
        pc = FindObjectOfType<PlayerController>();
        
        launch = Resources.Load<GameObject>("Prefabs/Effects/Projectiles/" + PlayerPrefs.GetInt("skinID"));
        
	}
	
	public void shoot()
    {
        if (!delayMode) {
            if (ps.AttackPosition() && pc.Position() == 0)
                Instantiate(launch, launchPos.transform.position, launchPos.transform.rotation);

            if (ps.AttackPosition() && pc.Position() == 2)
                Instantiate(launch, launchPos.transform.position, launchPos.transform.rotation);

            StartCoroutine(delayProj());
        }
    }

    IEnumerator delayProj()
    {
        delayMode = true;
        yield return new WaitForSeconds(delay);
        delayMode = false;
    }
}
