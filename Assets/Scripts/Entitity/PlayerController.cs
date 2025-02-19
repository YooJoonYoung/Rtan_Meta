using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;  // 카메라 객체를 저장할 변수

    protected override void Start()
    {
        base.Start();  // 부모 클래스의 Start 메서드를 호출
        camera = Camera.main;  // 메인 카메라를 가져옴
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // 좌우 방향 입력을 받음
        float vertical = Input.GetAxisRaw("Vertical");  // 상하 방향 입력을 받음
        // 이동 방향을 벡터로 설정하고 정규화
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // 마우스의 화면 상 위치를 가져옴
        Vector2 mousePosition = Input.mousePosition;
        // 마우스 위치를 월드 좌표로 변환
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        // 플레이어와 마우스 사이의 방향 벡터 계산
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)  // 방향 벡터의 크기가 0.9f 미만이면
        {
            // 마우스가 너무 가까우면 0으로 설정 (플레이어가 바라보지 않게 함)
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;  // 방향 벡터를 정규화
        }
    }
}
