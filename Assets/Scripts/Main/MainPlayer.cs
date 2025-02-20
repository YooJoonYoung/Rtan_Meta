using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayer : MonoBehaviour //ĳ������ �⺻ ���� ����

{
    public float moveSpeed = 5f;  // �̵� �ӵ�

    private Rigidbody2D rb;  // Rigidbody2D
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;  // �̵� ����

    void Start()
    {
        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
        // SpriteRenderer ������Ʈ ��������
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    void Update()
    {
        // WASD Ű �Է� �ޱ�
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A/D Ű �Ǵ� ����/������ ȭ��ǥ
        moveInput.y = Input.GetAxisRaw("Vertical");   // W/S Ű �Ǵ� ��/�Ʒ� ȭ��ǥ
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;  // ���������� �̵��ϸ� ���� �� ��
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;   // �������� �̵��ϸ� ����
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2D�� velocity�� �̵�
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    // �浹 ó�� ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٸ� ������Ʈ�� �浹���� ��
        if (collision.gameObject.CompareTag("Portal"))
        {
            Debug.Log("Portal �浹!");

            SceneManager.LoadScene("Flappy");
            // �浹 �� flappy scene���� �Ѿ����
            //SceneManager.LoadScene("Flappy");
        }
    }
}
