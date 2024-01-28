using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int time = 0;
    [SerializeField] int score;
    [SerializeField] public int health = 5;
    [SerializeField] public int gameDifficulty = 1;
    [SerializeField] public bool isGameOver;
    [SerializeField] GameObject spawner, uiGameplay;
    AudioSource[] allAudios;
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
        allAudios = Camera.main.gameObject.GetComponents<AudioSource>();
        

        StartCoroutine(PlayTimer());
    }
    IEnumerator PlayTimer()
    {
        while (health > 0 )
        {
            UIManager.Instance.UpdateUIScore(score);
            UIManager.Instance.UpdateUIHealth(health);
            //UIManager.Instance.UpdateUITime(time);
            yield return new WaitForSeconds(1);
             if (time % 5 == 0)
            {    
                gameDifficulty+=1;
                //updateAudio();
            }
            time++;
        }
        UIManager.Instance.UpdateUIScore(score);
        UIManager.Instance.UpdateUIHealth(0);
        GameOver();
    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     
    public void GameOver(){
        UIManager.Instance.ShowGameOverScreen();
        spawner.SetActive(false);
        uiGameplay.SetActive(false);
    }

    public void TakeDamage()
    {
        health -= 1;
    }
}
