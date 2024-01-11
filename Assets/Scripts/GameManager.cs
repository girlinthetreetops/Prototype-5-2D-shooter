using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //singleton stuff
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    //UI references
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public GameObject areYouSureYouWantToReturnScreen;
    public GameObject scoreDisplay;

    //Other
    public List<GameObject> targets;
    private float spawnRate = 2f;

    //Key game stats
    public bool isGameActive = false;
    public int score = 0;
    public int difficulty = 1;

    public void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
    }

    public void StartGame()
    {
        if (startScreen != null) { startScreen.SetActive(false); }
        if (scoreDisplay != null) { scoreDisplay.SetActive(true); }
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
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
        if (scoreText != null) { scoreText.SetText("Score: " + score.ToString()); }
    }

    public void GameOver()
    {
        isGameActive = false;
        Debug.Log("Game over");

        if(gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void OpenConfirmationScreenToConfirmReturnToMainMenu()
    {
        if (areYouSureYouWantToReturnScreen != null) { areYouSureYouWantToReturnScreen.SetActive(true); }
    }
    public void CloseConfirmationScreenToConfirmReturnToMainMenu()
    {
        if (areYouSureYouWantToReturnScreen != null) { areYouSureYouWantToReturnScreen.SetActive(false); }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void LoadGamePlayScene()
    {
        Debug.Log("Buttonclick detected");
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    //debug

    public void PrintMessage()
    {
        Debug.Log("Hey!");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameOver();
        }
    }
}
