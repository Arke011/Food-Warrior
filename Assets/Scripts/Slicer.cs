using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;
    Fruit fruit;
    public int comboCount;
    public float comboTimeLeft;
    public List<AudioClip> comboSounds;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        rb.MovePosition(worldPos);
        comboTimeLeft -= Time.deltaTime;

        if (comboTimeLeft <= 0)
        {
            if (comboCount > 2)
            {
                AudioSystem.Play(comboSounds[comboCount - 3]);
                GameManager.instance.IncreaseScoreForCombo(comboCount);
                Debug.Log("COMBO!");
            }
            comboCount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var fruit = other.gameObject.GetComponent<Fruit>();
        fruit.Slice();

       
        

        comboCount++;
        comboTimeLeft = 0.2f;
    }
}
