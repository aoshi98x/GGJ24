using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public int time = 0;
    [SerializeField] int score;
    [SerializeField] public bool gameOver;
    [SerializeField] public int gameDifficulty = 1;
    AudioSource[] allAudios;
    public int Score
    {
        get => score;
        set
        {
            score += value;
            //Update game UI with the actual score
            //UIManager.Instance.UpdateUIScore(score);
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
        while (time >=0 )
        {
            //UIManager.Instance.UpdateUITime(time);
            yield return new WaitForSeconds(1);
            time++;
        }
        //UIManager.Instance.ShowGameOverScreen();
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Inicio");
    }
}
