using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    HomeUI homeUI; // ������ UI ������Ʈ��
    GameUI gameUI;

    private UIState currentState;  // ���� UI ���¸� �����ϴ� ����

    private void Awake()
    {
        // UI ������Ʈ�� �ʱ�ȭ
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        // �ʱ� UI ���¸� Home���� ����
        ChangeState(UIState.Home);
    }
    public void SetPlayGame()
    {
        // UI ���¸� Game���� ����
        ChangeState(UIState.Game);
    }



    // UI ���¸� �����ϴ� �޼���
    public void ChangeState(UIState state)
    {
        // ���� ���� ������Ʈ
        currentState = state;

        // �� UI ������Ʈ�� Ȱ��ȭ ���¸� ����
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
    }

}
