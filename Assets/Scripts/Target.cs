using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    public int pointValue;

    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float maxTorque = 10;
    public float xRange = 4;
    public float ySpawnPos = -6;

    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -6);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive == true)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);

            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
