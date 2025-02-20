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

    private int currentScore = 0;  // ���� ������ ������ ����
    private int highScore = 0;  // �ְ� ������ ������ ����
    private bool isGameOver = true;  // ���� ���� ���¸� �����ϴ� ����


    private void Awake()
    {
        gameManager = this;
        // ���� ���� �� ����� �ְ� ���� �ҷ�����
        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }
    private void Start()
    {
        Debug.Log("High Score: " + highScore); // �ֿܼ� �ְ� ���� ���
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // �ְ� ������ ����
        if (currentScore > highScore)
        {
            highScore = currentScore;
            // ���ο� �ְ� ������ PlayerPrefs�� ����
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();  // ���� ������ ����
        }

        Debug.Log("High Score: " + highScore);  // ���� ���� �� �ְ� ���� ���

    }
    public void StartGame()
    {
        // ���� �ʱ�ȭ
        currentScore = 0;
        isGameOver = false;

        Debug.Log("Game Started");
    }

    public void RestartGame()
    {
        

        // ���� ���� ���� ����
        isGameOver = false;

    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
      

    }
    // ���� ������ ��ȯ�ϴ� �޼��� 
    public int GetCurrentScore()
    {
        return currentScore;
    }

    // �ְ� ������ ��ȯ�ϴ� �޼���
    public int GetHighScore()
    {
        return highScore;
    }

}