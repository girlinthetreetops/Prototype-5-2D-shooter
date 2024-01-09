using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate); // Wait for 1 second

            // Generate a random index for the target spawn
            int randomIndex = Random.Range(0, 3); // Assuming there are 3 possible target types, adjust as needed

            // Spawn a random target based on the random index
            Instantiate(targets[randomIndex], Vector3.zero, Quaternion.identity);
        }
    }

    
}
