using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Home,   // Ȩ ȭ��
    Game,   // ���� ȭ��
    Score,  // ���� ȭ��
}

public class UIManager : MonoBehaviour
{
    // UIManager�� �̱��� �ν��Ͻ��� �����ϴ� ����
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance; // �̱��� �ν��Ͻ��� ��ȯ
        }
    }

    // ���� UI ���¸� �����ϴ� ���� (�⺻ ���´� Home)
    UIState currentState = UIState.Home;

    // �� UI ȭ���� ���� ���� (Ȩ, ����, ���� UI)
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;

    // ������ �ֿ� ������ ����ϴ� Flappy ���� ����
   
    private void Awake()
    {
        // UIManager �ν��Ͻ� ����
        instance = this;
    

        // �� UI ��� �ʱ�ȭ (�ڽ� UI ������Ʈ���� ������Ʈ�� ã�� �ʱ�ȭ)
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this); // HomeUI �ʱ�ȭ
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this); // GameUI �ʱ�ȭ
        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this); // ScoreUI �ʱ�ȭ

        // �⺻ UI ���¸� Home���� ����
        ChangeState(UIState.Home);
    }
    public void ChangeState(UIState state)
    {
        currentState = state; // ���� ���� ����

        // �� UI ��Ұ� ���� ���¿� �°� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼��� (���� ȭ������ ��ȯ)
    public void OnClickStart()
    {

        // ���� ȭ������ ��ȯ
        homeUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼��� (���ø����̼� ����)
    public void OnClickExit()
    {
        Debug.Log("���� ����");
    }
    public void UpdateScore()
    {
    
    }
}