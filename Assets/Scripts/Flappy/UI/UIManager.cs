using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Home,   // 홈 화면
    Game,   // 게임 화면
    Score,  // 점수 화면
}

public class UIManager : MonoBehaviour
{
    // UIManager의 싱글톤 인스턴스를 저장하는 변수
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance; // 싱글톤 인스턴스를 반환
        }
    }

    // 현재 UI 상태를 저장하는 변수 (기본 상태는 Home)
    UIState currentState = UIState.Home;

    // 각 UI 화면의 참조 변수 (홈, 게임, 점수 UI)
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;

    // 게임의 주요 로직을 담당하는 Flappy 참조 변수
   
    private void Awake()
    {
        // UIManager 인스턴스 설정
        instance = this;
    

        // 각 UI 요소 초기화 (자식 UI 오브젝트에서 컴포넌트를 찾고 초기화)
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this); // HomeUI 초기화
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this); // GameUI 초기화
        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this); // ScoreUI 초기화

        // 기본 UI 상태를 Home으로 설정
        ChangeState(UIState.Home);
    }
    public void ChangeState(UIState state)
    {
        currentState = state; // 현재 상태 변경

        // 각 UI 요소가 현재 상태에 맞게 활성화 또는 비활성화
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    // 시작 버튼 클릭 시 호출되는 메서드 (게임 화면으로 전환)
    public void OnClickStart()
    {

        // 게임 화면으로 전환
        homeUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
    }

    // 종료 버튼 클릭 시 호출되는 메서드 (애플리케이션 종료)
    public void OnClickExit()
    {
        Debug.Log("게임 종료");
    }
    public void UpdateScore()
    {
    
    }
}