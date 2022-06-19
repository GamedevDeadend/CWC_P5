using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public bool gameActive;
    public TextMeshProUGUI gameOver;

    public GameObject startScreen;
    public Button restartButton;
    private int score;
    public TextMeshProUGUI scoreText;
    public float spawnRate;
    public List<GameObject> targets;
    // Start is called before the first frame update

    void Start()
    {

    }
    public void StartGame(int difficulty)
    {
        gameActive = true;
        StartCoroutine(SpawnTargets());
        startScreen.SetActive(false);
        spawnRate = difficulty;
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; 
        scoreText.text = "score:" + score;
    }

    IEnumerator SpawnTargets()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = targets.Count;
            Instantiate(targets[Random.Range(0,index)]);
        }
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
