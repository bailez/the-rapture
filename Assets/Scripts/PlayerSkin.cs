using UnityEngine;
using System.Collections;




public class PlayerSkin : MonoBehaviour {

    bool attackPosition;
    public float movementDelay;
    private SpriteRenderer sprt;
    Sprite r, tr, c, tl, l;
    Sprite[] sprites;
    string[] names;
    PlayerCombat pc;
    LoseSystem ls;
    PlayerController p;

    void Start()
    {
        p = FindObjectOfType<PlayerController>();
       // PlayerPrefs.SetInt("skinID", p.skin);
        ls = FindObjectOfType<LoseSystem>();
        pc = FindObjectOfType<PlayerCombat>();
        sprt = GetComponent<SpriteRenderer>();

        //Preparo de Animação
        sprites = Resources.LoadAll<Sprite>("skins/" + PlayerPrefs.GetInt("skinID"));
            c = sprites[0];
            tl = sprites[1];
            l = sprites[2];
            tr = sprites[4];
            r = sprites[5];

            sprt.sprite = c;


    }


    

    public IEnumerator rightAnimation(bool rTc, bool rTl)
    {
        attackPosition = false;

        //direita para o centro
        if (rTc)
        {
            //-----------------------------------direita
            sprt.sprite = r;
            yield return new WaitForSeconds(movementDelay);
            //virada pra direita
            sprt.sprite = tr;
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------centro
            sprt.sprite = c;
            attackPosition = true;
            

            //-----------------------------------direita para a esquerda
            if (rTl)
            {
                StartCoroutine(leftAnimation(false, false));
            }
        }

        //-----------------------------------centro para direita
        else
        {
            //-----------------------------------centro
             sprt.sprite = c;
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------virando para direita
              sprt.sprite = tr;
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------direita
            sprt.sprite = r;
            attackPosition = true;
            if (!ls.Lose())
                pc.shoot();
        }


    }

    public IEnumerator  leftAnimation(bool lTc, bool lTr)
    {
        attackPosition = false;
        //-----------------------------------esquerda para o centro
        if (lTc)
        {

            //-----------------------------------esquerda
                  sprt.sprite = l;
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------virando para esquerda
                  sprt.sprite = tl;
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------centro
                 sprt.sprite = c;

            attackPosition = true;

            //-----------------------------------esquerda para direita
            if (lTr)
            {
                StartCoroutine(rightAnimation(false, false));
            }
        }
        //-----------------------------------centro para a esquerda
        else
        {
            //-----------------------------------centro
                  sprt.sprite = c;           
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------virando para a esquerda
                    sprt.sprite = tl;    
            yield return new WaitForSeconds(movementDelay);
            //-----------------------------------esquerda
            sprt.sprite = l;
            attackPosition = true;
            if(!ls.Lose())
            pc.shoot();
        }
    }

    public bool AttackPosition()
    {
        return attackPosition;
    }
}
