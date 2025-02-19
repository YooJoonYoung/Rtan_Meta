using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour //캐릭터의 기본 동작 제어
{
    protected Rigidbody2D _rigidbody; // Rigidbody2D 컴포넌트

    [SerializeField] private SpriteRenderer characterRenderer; // 캐릭터의 시각적 표현
    [SerializeField] private Transform weaponPivot; // 무기 회전 피벗

    protected Vector2 movementDirection = Vector2.zero; // 이동 방향
    public Vector2 MovementDirection { get { return movementDirection; } } // 이동 방향 반환

    protected Vector2 lookDirection = Vector2.zero; // 바라보는 방향
    public Vector2 LookDirection { get { return lookDirection; } } // 바라보는 방향 반환

    private Vector2 knockback = Vector2.zero; // 넉백 방향
    private float knockbackDuration = 0.0f; // 넉백 지속 시간

    protected virtual void Awake() //스크립트가 초기화될 때 호출
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져와 저장
    }

    protected virtual void Start() // 게임 시작 시 한 번 호출
    {
        // 초기화 작업이 필요한 경우 여기서 처리
    }

    protected virtual void Update() // 매 프레임마다 호출
    {
        HandleAction();  // 캐릭터가 수행할 액션 처리
        Rotate(lookDirection); // 바라보는 방향으로 회전
    }

    protected virtual void FixedUpdate() // 물리 프레임마다 호출(이동과 넉백 적용)
    {
        Movment(movementDirection); // 이동 방향에 따른 물리적 이동을 적용
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;  // 넉백 시간이 경과하면 감소시킴
        }
    }

    protected virtual void HandleAction() // 캐릭터의 액션을 처리
    {
        // 서브클래스에서 오버라이드하여 액션 처리 가능
    }

    // Rigidbody2D를 이용해 캐릭터의 이동을 처리하는 매서드
    private void Movment(Vector2 direction)
    {
        direction = direction * 5; // 속도 조정(5는 임의 값)

        if (knockbackDuration > 0.0f)  // 넉백이 활성화되어 있다면
        {
            direction *= 0.2f; // 넉백 중에는 속도 20%로 감소
            direction += knockback; // 넉백 방향 추가
        }

        _rigidbody.velocity = direction; // 계산된 방향으로 Rigidbody2D의 속도를 설정
    }

    // 바라보는 방향에 따라 캐릭터와 무기를 회전시키는 메서드
    private void Rotate(Vector2 direction)
    {
        // 방향 벡터에서 회전 각도를 계산 (라디안 -> 도 단위로 변환)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 회전 각도가 90도를 넘으면 왼쪽을 보고 있다고 판단
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        // 캐릭터가 왼쪽을 보고 있으면 스프라이트를 반전
        characterRenderer.flipX = isLeft;

        if (weaponPivot != null)  // 무기가 있다면, 무기의 회전을 방향에 맞게 조정
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ); // 무기 피벗을 회전
        }
    }

    // 다른 객체로부터 넉백을 적용하는 공개 메서드
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration; // 넉백 지속 시간 설정
                                      // 넉백 방향과 크기 설정
        knockback = -(other.position - transform.position).normalized * power;
    }
}
