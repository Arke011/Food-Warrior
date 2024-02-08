using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    
    public List<Wave> waves;

    async void Start()
    {
        foreach (var wave in waves)
        {
            foreach (var fruit in wave.items)
            {
                var prefab = fruit.isBomb ? bombPrefab : fruitPrefab;
                var go = Instantiate(prefab);
                go.transform.position = new Vector3(fruit.x, -7f, 0);

            }
            await new WaitForSeconds(3f);
        }
    }

    
}
