using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // ������ �÷��̾��� Transform
    public float smoothSpeed = 0.125f;  // ī�޶� �̵� �ӵ� (�ε巴�� �̵��ϴ� ����)
    public Vector3 offset;  // ī�޶�� �÷��̾� ������ ������� ��ġ




    void Start()
    {
        // ����� �������� ���� ���, ī�޶� �ƹ��͵� ������ �ʰ� ��
        if (player == null)
            return;

      
    }

    void LateUpdate()
    {
        // ī�޶��� ��ǥ ��ġ�� �÷��̾��� ��ġ�� �������� ���� ������ ����
        Vector3 desiredPosition = player.position + offset;

        desiredPosition.z = -10;  // Z ��ǥ�� ���������� ���� (-10)

        // ī�޶��� ���� ��ġ�� ��ǥ ��ġ ���̸� �ε巴�� ���� (smooth)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ī�޶� �ε巴�� ��ǥ ��ġ�� �̵���Ŵ
        transform.position = smoothedPosition;
    }
}
