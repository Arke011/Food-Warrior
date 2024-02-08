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
                await new WaitForSeconds(fruit.delay);
                Debug.Log(fruit.isBomb);
                var prefab = fruit.isBomb ? bombPrefab : fruitPrefab;
                var go = Instantiate(prefab);
                go.transform.position = new Vector3(fruit.x, -6.5f, 0);

                var rigidbody2D = go.GetComponent<Rigidbody2D>();
                rigidbody2D.velocity = fruit.velocity;

            }
            await new WaitForSeconds(3f);
        }
    }

    
}
s