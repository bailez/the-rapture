using UnityEngine;
using System.Collections;

public class CloudScript : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public float segundos;
    public GameObject posicaoInicial;
    public bool inicial;
    
    void Start()
    {
        StartCoroutine("retorno");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

   IEnumerator retorno()
    {
        if (inicial)
        {
            yield return new WaitForSeconds(segundos / 2);
        }
        else if (!inicial)
        {
            yield return new WaitForSeconds(segundos);
        }
        gameObject.transform.position = new Vector3(posicaoInicial.transform.position.x, posicaoInicial.transform.position.y, posicaoInicial.transform.position.z);
        inicial = false;
        StartCoroutine("retorno");
    }
}
