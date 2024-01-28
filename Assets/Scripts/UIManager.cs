using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI  healthText;
    [SerializeField] TextMeshProUGUI  finalScoreText;
    [SerializeField] GameObject gameOverScreen, winGameScreen;

private void Awake(){
    if(Instance == null){
        Instance = this;
    }
}
    public void UpdateUIScore(int newScore){
        scoreText.text = newScore.ToString();
    }

    public void UpdateUIHealth(int newHealth){
        healthText.text = newHealth.ToString();
    }
    public void ShowGameOverScreen(){
        gameOverScreen.SetActive(true);
        finalScoreText.text = "" + GameManager.Instance.Score;
    }
    public void ShowWinGameScreen()
    {
        winGameScreen.SetActive(true);
        finalScoreText.text = "" + GameManager.Instance.Score;
    }

}
