using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    HomeUI homeUI; // 각각의 UI 컴포넌트들
    GameUI gameUI;

    private UIState currentState;  // 현재 UI 상태를 저장하는 변수

    private void Awake()
    {
        // UI 컴포넌트들 초기화
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        // 초기 UI 상태를 Home으로 설정
        ChangeState(UIState.Home);
    }
    public void SetPlayGame()
    {
        // UI 상태를 Game으로 변경
        ChangeState(UIState.Game);
    }



    // UI 상태를 변경하는 메서드
    public void ChangeState(UIState state)
    {
        // 현재 상태 업데이트
        currentState = state;

        // 각 UI 컴포넌트의 활성화 상태를 변경
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
    }

}
