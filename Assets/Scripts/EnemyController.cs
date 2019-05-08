using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    bool right;
    public int enemyVariant;
    int maxNPC;
    public GameObject explosion;
    public GameObject[] npc;
    public Transform [] spawnPositions;
    ScoreSystem ss;
    LoseSystem ls;
    SegundosSpawn sp;
    void Start()
    {
        maxNPC = npc.Length - 1;
        sp = FindObjectOfType<SegundosSpawn>();
        ss = FindObjectOfType<ScoreSystem>();
        ls = FindObjectOfType<LoseSystem>();
    }	

    
    public IEnumerator EnemySpawner()
    {
        while(!ls.Lose())
        {
            if (randomicNumber(0, 100) > 50) {
                Instantiate(Enemy(), spawnPositions[0].position, spawnPositions[0].rotation);
                right = true;
            }
            else {
                right = false;
                Instantiate(Enemy(), spawnPositions[1].position, spawnPositions[1].rotation);
            }

            yield return new WaitForSeconds(sp.Seg());
        }
    }

    GameObject Enemy()
    {
        GameObject currentNpc,enemy1,enemy2,enemy3;
        int npcID = 0,ran;
        ran = randomicNumber(0, enemyVariant * 3);
      

        if (maxNPC >= (ss.bruteScore(enemyVariant)/enemyVariant) + 2)
        {
            npcID = ss.bruteScore(enemyVariant) / enemyVariant;
            enemy1 = npc[npcID]; enemy2 = npc[npcID + 1]; enemy3 = npc[npcID + 2];
        }
        else
        {
            npcID = randomicNumber(0, maxNPC);
            enemy1 = npc[npcID]; enemy2 = npc[npcID]; enemy3 = npc[npcID];
        }

        if (ran < enemyVariant)
            currentNpc = enemy1;
        else if (ran > enemyVariant*2)
            currentNpc = enemy2;
        else
            currentNpc = enemy3;

        return currentNpc;
    }

    public void Death(Vector3 position, Quaternion rotation)
    {
        Instantiate(explosion, position, rotation);
    }

    public int randomicNumber(int min, int max)
    {
        int ran;
        ran = Random.Range(min, max);
        return ran;
    }

    public bool Right()
    {
        return right;
    }
}
