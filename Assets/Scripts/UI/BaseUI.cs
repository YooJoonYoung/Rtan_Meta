using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI 관리의 기본 클래스, 다른 UI 컴포넌트들이 이를 상속받아 사용할 수 있음
public abstract class BaseUI : MonoBehaviour
{
    // UIManager 인스턴스
    protected UIManager uiManager;

    // UIManager를 초기화하는 메서드
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;  // UIManager 인스턴스를 저장
    }

    // UI 상태를 반환하는 추상 메서드 (상속받은 클래스에서 구현해야 함)
    protected abstract UIState GetUIState();

    // 현재 UI 상태에 맞게 UI의 활성화 여부를 설정하는 메서드
    public void SetActive(UIState state)
    {
        // UI 상태가 요청된 상태와 일치하면 UI를 활성화, 그렇지 않으면 비활성화
        this.gameObject.SetActive(GetUIState() == state);
    }
}
