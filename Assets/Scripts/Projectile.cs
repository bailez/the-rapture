using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    Rigidbody2D rb;
    PlayerController pc;
    public float bulletSpeed;
    public GameObject projectileExplosion;

	void Start () {
        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        if(pc.Position() == 2)
        rb.velocity = new Vector2(bulletSpeed,0);
        else
            rb.velocity = new Vector2(-bulletSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(projectileExplosion,gameObject.transform.position,gameObject.transform.rotation);
            

        }

    }
}
