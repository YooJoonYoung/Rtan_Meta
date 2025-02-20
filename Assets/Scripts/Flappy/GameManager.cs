using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;  // 현재 점수를 저장할 변수
    private int highScore = 0;  // 최고 점수를 저장할 변수
    private bool isGameOver = true;  // 게임 오버 상태를 추적하는 변수


    private void Awake()
    {
        gameManager = this;
        // 게임 시작 시 저장된 최고 점수 불러오기
        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }
    private void Start()
    {
        Debug.Log("High Score: " + highScore); // 콘솔에 최고 점수 출력
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // 최고 점수를 갱신
        if (currentScore > highScore)
        {
            highScore = currentScore;
            // 새로운 최고 점수를 PlayerPrefs에 저장
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();  // 변경 사항을 저장
        }

        Debug.Log("High Score: " + highScore);  // 게임 오버 후 최고 점수 출력

    }
    public void StartGame()
    {
        // 점수 초기화
        currentScore = 0;
        isGameOver = false;

        Debug.Log("Game Started");
    }

    public void RestartGame()
    {
        

        // 게임 오버 상태 해제
        isGameOver = false;

    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
      

    }
    // 현재 점수를 반환하는 메서드 
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // 최고 점수를 반환하는 메서드
    public int GetHighScore()
    {
        return highScore;
    }

}