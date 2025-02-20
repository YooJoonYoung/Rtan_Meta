using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HomeUI�� BaseUI�� ��ӹ޾� ���� ȭ�� UI�� ó���ϴ� Ŭ�����Դϴ�.
public class ScoreUI : BaseUI
{
    // UIState�� Game�� �� Ȱ��ȭ�ǵ��� UIState�� ��ȯ�ϴ� �޼���
    protected override UIState GetUIState()
    {
        return UIState.Score; // ���� UI ���°� 'Score'���� ��ȯ
    }

    // UIManager�� �ʱ�ȭ �޼��带 ȣ���ϴ� �������̵�� Init �޼���
    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager); // �θ� Ŭ������ Init �޼��带 ȣ���Ͽ� UIManager�� �ʱ�ȭ
    }

}
