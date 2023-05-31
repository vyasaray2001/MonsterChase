using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] Transform left,right;
    [SerializeField]
    private GameObject[] gameObjects;
    private GameObject spawnedMonster;
    private int ranIndex, ranSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.RandomRange(1, 5));
            ranIndex = Random.Range(0, gameObjects.Length);
            ranSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(gameObjects[ranIndex]);

            if (ranSide == 0)
            {
                spawnedMonster.transform.position = left.position;
                spawnedMonster.GetComponent<MonsterMovement>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = right.position;
                spawnedMonster.GetComponent<MonsterMovement>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
