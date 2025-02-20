using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HomeUI는 BaseUI를 상속받아 게임 화면 UI를 처리하는 클래스입니다.
public class ScoreUI : BaseUI
{
    // UIState가 Game일 때 활성화되도록 UIState를 반환하는 메서드
    protected override UIState GetUIState()
    {
        return UIState.Score; // 현재 UI 상태가 'Score'임을 반환
    }

    // UIManager의 초기화 메서드를 호출하는 오버라이드된 Init 메서드
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager); // 부모 클래스의 Init 메서드를 호출하여 UIManager를 초기화
    }

}
