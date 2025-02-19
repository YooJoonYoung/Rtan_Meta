using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    // UI���� ������ ���� ��ư�� ���� ��ư
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    // UI �ʱ�ȭ
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }
    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickStartButton()
    {
        // ���� ���� �޼��� ȣ��
        GameManager.instance.StartGame();
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnClickExitButton()
    {
        // Mainscene���� ���ư�����
    }
    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}