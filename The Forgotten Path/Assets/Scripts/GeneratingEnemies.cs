using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingEnemies : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public int PositionX1;
    public int PositionY1;
    public int PositionX2;
    public int PositionY2;
    public int NumberOfEnemies;
    void Start()
    {
        StartCoroutine(EnemyGenerate());
    }

    IEnumerator EnemyGenerate()
    {
        while(NumberOfEnemies<8)
        {
            PositionX1 = Random.Range(-6,171);
            PositionY1 = Random.Range(-6,260);
            Instantiate(Enemy1, new Vector3(PositionX1, 0, PositionY1), Quaternion.identity);
            PositionX2 = Random.Range(-6, 171);
            PositionY2 = Random.Range(-6, 260);
            Instantiate(Enemy2, new Vector3(PositionX2, 0, PositionY2), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            NumberOfEnemies += 1;
        }
    }
   
}
