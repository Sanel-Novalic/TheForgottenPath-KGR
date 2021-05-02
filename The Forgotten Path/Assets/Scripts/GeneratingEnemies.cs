using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy1;
    [SerializeField]
    private GameObject Enemy2;
    private int PositionX1;
    private int PositionY1;
    private int PositionX2;
    private int PositionY2;
    [SerializeField]
    private int MaxNumberOfEnemies;
    private int NumberOfEnemies;
    
    void Start()
    {

        StartCoroutine(EnemyGenerate());
    }

    IEnumerator EnemyGenerate()
    {
        while(NumberOfEnemies<MaxNumberOfEnemies)
        {
            PositionX1 = Random.Range(0,115);
            PositionY1 = Random.Range(0,260);
            Instantiate(Enemy1, new Vector3(PositionX1, 0, PositionY1), Quaternion.identity);
            PositionX2 = Random.Range(-6, 171);
            PositionY2 = Random.Range(-6, 260);
            Instantiate(Enemy2, new Vector3(PositionX2, 0, PositionY2), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            NumberOfEnemies += 1;
        }
    }
   
}
