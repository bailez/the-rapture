using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    //Posições: centro = 1, direita = 2, esquerda = 0
    int position;
    PlayerSkin ps;
    bool startGameplay;
    EnemyController ec;
    UIController uc;
    //public int skin;
    public GameObject player;
    public GameObject[] pyramids;
    
  

    void Start()
    {
       // PlayerPrefs.SetInt("skinID", skin);
        uc = FindObjectOfType<UIController>();
        ec = FindObjectOfType<EnemyController>();
        ps = FindObjectOfType<PlayerSkin>();
        position = 1;
        startGameplay = false;
        
        GameObject childObj = Instantiate(pyramids[PlayerPrefs.GetInt("skinID")], player.transform.position, player.transform.rotation) as GameObject;
        childObj.transform.parent = player.transform;

    }
    public void controlChar (bool right) {

        if (!startGameplay)
        {
            uc.backButton.SetActive(false);
            uc.pauseButton.SetActive(true);
            startGameplay = true;
            StartCoroutine(ec.EnemySpawner());
        }
        //Do Centro para direita
        if (right && position == 1)
        {
            StartCoroutine(ps.rightAnimation(false,false));
            position = 2;
        }

        //Da direita para a esquerda
        if (!right && position == 2)
        {
            StartCoroutine(ps.rightAnimation(true, true));
            position = 0;
        }

        //Do Centro para esquerda
        if (!right && position == 1)
        {
            StartCoroutine(ps.leftAnimation(false, false));
            position = 0;
        }

        //Da esquerda pra direita
        if (right && position == 0)
        {
            StartCoroutine(ps.leftAnimation(true, true));
            position = 2;
        }

    }

    public int Position()
    {
        return position;
    }
}
