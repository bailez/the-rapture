using UnityEngine;
using System.Collections;

public class SegundosSpawn : MonoBehaviour {
    public int[] respectiveScore;
    public float[] segundos;
    float seg;
    ScoreSystem ss;
    EnemyController ec;

	void Start () {
       
        ec = FindObjectOfType<EnemyController>();
        ss = FindObjectOfType<ScoreSystem>();
        for(int i = 0; i < ec.npc.Length - 2; i++)
        {
            respectiveScore[i] = i * ec.enemyVariant;
        }
	}

    int currentBs;
    int currentV;

    void Update () {
                
       currentBs = ss.bruteScore(ec.enemyVariant);
       currentV = currentBs / ec.enemyVariant;

        if (respectiveScore[currentV] == currentBs) 
            seg = segundos[currentV];


        else
            seg = segundos[0];
    }

    public float Seg()
    {
        if (seg == 0)
            seg = 0.5f;
        return seg;
    }
}
