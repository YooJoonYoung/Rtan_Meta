using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // 추적할 플레이어의 Transform
    public float smoothSpeed = 0.125f;  // 카메라 이동 속도 (부드럽게 이동하는 정도)
    public Vector3 offset;  // 카메라와 플레이어 사이의 상대적인 위치




    void Start()
    {
        // 대상이 설정되지 않은 경우, 카메라가 아무것도 따라가지 않게 함
        if (player == null)
            return;

      
    }

    void LateUpdate()
    {
        // 카메라의 목표 위치를 플레이어의 위치와 오프셋을 더한 값으로 설정
        Vector3 desiredPosition = player.position + offset;

        desiredPosition.z = -10;  // Z 좌표는 고정값으로 설정 (-10)

        // 카메라의 현재 위치와 목표 위치 사이를 부드럽게 보간 (smooth)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라를 부드럽게 목표 위치로 이동시킴
        transform.position = smoothedPosition;
    }
}
