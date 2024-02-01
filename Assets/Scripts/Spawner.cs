using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruit;
    public List<GameObject> fruits;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    void Spawn()
    {
        int count = Random.Range(1, 6); 

        for (int i = 0; i < count; i++)
        {
            float randomHeight = Random.Range(-5f, -12f);
            Vector3 randomPosition = new Vector3(Random.Range(-3f, 5f), randomHeight, 0); 

            var obj = Instantiate(fruits[Random.Range(0, fruits.Count)], randomPosition, Quaternion.identity);
        }
    }
}
