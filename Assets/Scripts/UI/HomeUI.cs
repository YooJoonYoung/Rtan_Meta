using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    // UI에서 참조할 시작 버튼과 종료 버튼
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    // UI 초기화
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }
    // 시작 버튼 클릭 시 호출되는 메서드
    public void OnClickStartButton()
    {
        // 게임 시작 메서드 호출
        GameManager.instance.StartGame();
    }

    // 종료 버튼 클릭 시 호출되는 메서드
    public void OnClickExitButton()
    {
        // Mainscene으로 돌아가도록
    }
    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}