using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 모든 UI 요소의 기본 클래스 (UI의 공통 기능을 제공)
public abstract class BaseUI : MonoBehaviour
{
    // UIManager를 통해 UI 요소를 관리하는 변수
    protected UIManager uiManager;

    // UIManager를 초기화하는 메서드
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager; // UIManager 객체를 할당
    }

    // 자식 클래스에서 UI 상태를 가져오는 메서드를 추상화 (구체적인 구현은 자식 클래스에서)
    protected abstract UIState GetUIState();

    // 현재 UI 상태가 주어진 상태와 일치하는지 확인하고, UI 활성화 여부를 설정
    public void SetActive(UIState state)
    {
        // 현재 UI의 상태가 전달된 상태와 일치하면 UI를 활성화하고, 그렇지 않으면 비활성화
        gameObject.SetActive(GetUIState() == state);
    }
}
