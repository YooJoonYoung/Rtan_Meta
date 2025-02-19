using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UI ������ �⺻ Ŭ����, �ٸ� UI ������Ʈ���� �̸� ��ӹ޾� ����� �� ����
public abstract class BaseUI : MonoBehaviour
{
    // UIManager �ν��Ͻ�
    protected UIManager uiManager;

    // UIManager�� �ʱ�ȭ�ϴ� �޼���
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;  // UIManager �ν��Ͻ��� ����
    }

    // UI ���¸� ��ȯ�ϴ� �߻� �޼��� (��ӹ��� Ŭ�������� �����ؾ� ��)
    protected abstract UIState GetUIState();

    // ���� UI ���¿� �°� UI�� Ȱ��ȭ ���θ� �����ϴ� �޼���
    public void SetActive(UIState state)
    {
        // UI ���°� ��û�� ���¿� ��ġ�ϸ� UI�� Ȱ��ȭ, �׷��� ������ ��Ȱ��ȭ
        this.gameObject.SetActive(GetUIState() == state);
    }
}
