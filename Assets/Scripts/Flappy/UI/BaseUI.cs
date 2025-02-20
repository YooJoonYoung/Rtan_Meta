using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� UI ����� �⺻ Ŭ���� (UI�� ���� ����� ����)
public abstract class BaseUI : MonoBehaviour
{
    // UIManager�� ���� UI ��Ҹ� �����ϴ� ����
    protected UIManager uiManager;

    // UIManager�� �ʱ�ȭ�ϴ� �޼���
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager; // UIManager ��ü�� �Ҵ�
    }

    // �ڽ� Ŭ�������� UI ���¸� �������� �޼��带 �߻�ȭ (��ü���� ������ �ڽ� Ŭ��������)
    protected abstract UIState GetUIState();

    // ���� UI ���°� �־��� ���¿� ��ġ�ϴ��� Ȯ���ϰ�, UI Ȱ��ȭ ���θ� ����
    public void SetActive(UIState state)
    {
        // ���� UI�� ���°� ���޵� ���¿� ��ġ�ϸ� UI�� Ȱ��ȭ�ϰ�, �׷��� ������ ��Ȱ��ȭ
        gameObject.SetActive(GetUIState() == state);
    }
}
