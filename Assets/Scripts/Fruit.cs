using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject explosionParticles;
    public Color juiceColor;
    public AudioClip spawnSound;
    public AudioClip sliceSound;
    public AudioClip missSound;
    public List<AudioClip> splatterSounds;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = Random.Range(100, 300);
        AudioSystem.Play(spawnSound);
    }

    void Update()
    {
        if (transform.position.y < -7)
        {
            if (CompareTag("bomb"))
            {
                GameManager.instance.LeaveScoreAlone();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("ohmaygot");
                AudioSystem.Play(missSound);
                Destroy(gameObject);
                GameManager.instance.DecreaseHP(); 
            }
        }
    }


    public void Slice()
    {
        var particles = Instantiate(explosionParticles);
        particles.transform.position = transform.position;

        if (!CompareTag("bomb"))
        {
            Split(particles);
            GameManager.instance.IncreaseScore(1);
            AudioSystem.Play(sliceSound);
            AudioSystem.Play(splatterSounds[Random.Range(0, 2)]);
        }
        else
        {
            GameManager.instance.DecreaseHP();
            GameManager.instance.DecreaseScore(3);
            AudioSystem.Play(sliceSound);
        }

        

        Destroy(gameObject);
    }

    void Split(GameObject particles)
    {
        var children = GetComponentsInChildren<MeshRenderer>();
        foreach (var child in children)
        {
            var childRB = child.gameObject.AddComponent<Rigidbody2D>();
            childRB.velocity = rb.velocity + Random.insideUnitCircle;
        }
        transform.DetachChildren();

        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = juiceColor;
    }
}
