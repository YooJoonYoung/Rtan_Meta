using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;  // ī�޶� ��ü�� ������ ����

    protected override void Start()
    {
        base.Start();  // �θ� Ŭ������ Start �޼��带 ȣ��
        camera = Camera.main;  // ���� ī�޶� ������
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // �¿� ���� �Է��� ����
        float vertical = Input.GetAxisRaw("Vertical");  // ���� ���� �Է��� ����
        // �̵� ������ ���ͷ� �����ϰ� ����ȭ
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // ���콺�� ȭ�� �� ��ġ�� ������
        Vector2 mousePosition = Input.mousePosition;
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        // �÷��̾�� ���콺 ������ ���� ���� ���
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)  // ���� ������ ũ�Ⱑ 0.9f �̸��̸�
        {
            // ���콺�� �ʹ� ������ 0���� ���� (�÷��̾ �ٶ��� �ʰ� ��)
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;  // ���� ���͸� ����ȭ
        }
    }
}
