using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public int score = 0;

    private float spawnRate = 2f;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        startScreen.SetActive(false);

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

    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.SetText("Score: " + score.ToString());
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
