using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject [] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos; 
    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnedMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnedMonsters()
    {
      while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            //To put it in the left
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4, 10);

            }
            //To put it in the right
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }
    }
}//class







































