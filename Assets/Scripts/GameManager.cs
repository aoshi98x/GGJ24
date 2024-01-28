using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int time = 0;
    [SerializeField] int score;
    [SerializeField] int health;
    [SerializeField] public float gameDifficulty = 1;
    public float timeToSpawn;
    [SerializeField] public bool isGameOver;
    [SerializeField] GameObject spawner, uiGameplay,rayLeft, rayRight;
    AudioSource output;
    [SerializeField]AudioClip winSound;

    public int Health
    {
        get => health;
        set
        {
            health += value;
            //Update game UI with the actual score
            UIManager.Instance.UpdateUIHealth(health);
        }
    }
    public int Score
    {
        get => score;
        set
        {
            score += value;
            //Update game UI with the actual score
            UIManager.Instance.UpdateUIScore(score);
        }
    }
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        output = FindObjectOfType<AudioSource>();
        StartCoroutine(PlayTimer());
    }
    IEnumerator PlayTimer()
    {
        while (health > 0 && time < 90)
        {
            UIManager.Instance.UpdateUIScore(score);
            UIManager.Instance.UpdateUIHealth(health);
            //UIManager.Instance.UpdateUITime(time);
            yield return new WaitForSeconds(1);
             if (time % 20 == 0)
            {    
                gameDifficulty+=0.6f;
                if (timeToSpawn > 0.7)
                {
                    timeToSpawn = (timeToSpawn / gameDifficulty) * 1.75f;
                }
                //updateAudio();
            }
            time++;
        }
        UIManager.Instance.UpdateUIScore(score);
        UIManager.Instance.UpdateUIHealth(0);
        if(health <= 0)
        {
            GameOver();
        }
        else
        {
            WinGame();
            output.Stop();
            PlaySfx(winSound);
        }
    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

     
    public void GameOver(){
        UIManager.Instance.ShowGameOverScreen();
        spawner.GetComponent<SpawnManager>().enabled = false;
        uiGameplay.SetActive(false);
        rayLeft.SetActive(true);
        rayRight.SetActive(true);
    }
    public void WinGame()
    {
        UIManager.Instance.ShowWinGameScreen();
        spawner.GetComponent<SpawnManager>().enabled = false;
        uiGameplay.SetActive(false);
        rayLeft.SetActive(true);
        rayRight.SetActive(true);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void PlaySfx(AudioClip clipSound)
    {
        output.PlayOneShot(clipSound);
    }
    
}
