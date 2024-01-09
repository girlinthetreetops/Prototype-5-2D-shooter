using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.SetText("Score: " + score.ToString());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate); 
            int randomIndex = Random.Range(0, 4); 
            Instantiate(targets[randomIndex], Vector3.zero, Quaternion.identity);
        }
    }

    
}
