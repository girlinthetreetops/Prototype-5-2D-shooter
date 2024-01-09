using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public int score = 0;

    private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        isGameActive = true;
    }

    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.SetText("Score: " + score.ToString());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(spawnRate); 
            int randomIndex = Random.Range(0, 4); 
            Instantiate(targets[randomIndex], Vector3.zero, Quaternion.identity);
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        Debug.Log("Game over");
        gameOverScreen.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
