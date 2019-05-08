using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public bool needsToFlip;
    public float speed;
    bool parado;
    public int addMoney,life;
    EnemyController ec;
    SpriteRenderer sr;
    Animator anim;
    Rigidbody2D rb;
    LoseSystem ls;
    ScoreSystem ss;
	
	void Start () {

        ss = FindObjectOfType<ScoreSystem>();
        ls = FindObjectOfType<LoseSystem>();
        rb = GetComponent<Rigidbody2D>();
        ec = FindObjectOfType<EnemyController>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
       
        if(!needsToFlip)
        anim.SetBool("direita", ec.Right());

        if (ec.Right())
        {
            rb.velocity = new Vector2(-speed, 0);
            if (needsToFlip)
                sr.flipX = true;
        }
        else rb.velocity = new Vector2(speed, 0);
    }
    bool takenDamage;

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "Projectile" && !takenDamage){
            takenDamage = true;
            life--;
            takenDamage = false;
        }
    }    

  void Update()
    { 
        if(ls.Lose())
        rb.velocity = Vector2.zero;
        if (life <= 0)
            Die();
        anim.SetBool("Parado", ls.Lose());
    }

   void Die()
    {
        ss.Numbers(addMoney);
        Destroy(gameObject);
        ec.Death(this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
