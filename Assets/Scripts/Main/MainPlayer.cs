using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayer : MonoBehaviour //캐릭터의 기본 동작 제어

{
    public float moveSpeed = 5f;  // 이동 속도

    private Rigidbody2D rb;  // Rigidbody2D
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;  // 이동 방향

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
        // SpriteRenderer 컴포넌트 가져오기
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    void Update()
    {
        // WASD 키 입력 받기
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D 키 또는 왼쪽/오른쪽 화살표
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S 키 또는 위/아래 화살표
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;  // 오른쪽으로 이동하면 반전 안 함
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;   // 왼쪽으로 이동하면 반전
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2D의 velocity로 이동
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    // 충돌 처리 예시
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 다른 오브젝트와 충돌했을 때
        if (collision.gameObject.CompareTag("Portal"))
        {
            Debug.Log("Portal 충돌!");

            SceneManager.LoadScene("Flappy");
            // 충돌 시 flappy scene으로 넘어가도록
            //SceneManager.LoadScene("Flappy");
        }
    }
}
