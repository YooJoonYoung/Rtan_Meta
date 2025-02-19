using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour //ĳ������ �⺻ ���� ����
{
    protected Rigidbody2D _rigidbody; // Rigidbody2D ������Ʈ

    [SerializeField] private SpriteRenderer characterRenderer; // ĳ������ �ð��� ǥ��
    [SerializeField] private Transform weaponPivot; // ���� ȸ�� �ǹ�

    protected Vector2 movementDirection = Vector2.zero; // �̵� ����
    public Vector2 MovementDirection { get { return movementDirection; } } // �̵� ���� ��ȯ

    protected Vector2 lookDirection = Vector2.zero; // �ٶ󺸴� ����
    public Vector2 LookDirection { get { return lookDirection; } } // �ٶ󺸴� ���� ��ȯ

    private Vector2 knockback = Vector2.zero; // �˹� ����
    private float knockbackDuration = 0.0f; // �˹� ���� �ð�

    protected virtual void Awake() //��ũ��Ʈ�� �ʱ�ȭ�� �� ȣ��
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ������ ����
    }

    protected virtual void Start() // ���� ���� �� �� �� ȣ��
    {
        // �ʱ�ȭ �۾��� �ʿ��� ��� ���⼭ ó��
    }

    protected virtual void Update() // �� �����Ӹ��� ȣ��
    {
        HandleAction();  // ĳ���Ͱ� ������ �׼� ó��
        Rotate(lookDirection); // �ٶ󺸴� �������� ȸ��
    }

    protected virtual void FixedUpdate() // ���� �����Ӹ��� ȣ��(�̵��� �˹� ����)
    {
        Movment(movementDirection); // �̵� ���⿡ ���� ������ �̵��� ����
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;  // �˹� �ð��� ����ϸ� ���ҽ�Ŵ
        }
    }

    protected virtual void HandleAction() // ĳ������ �׼��� ó��
    {
        // ����Ŭ�������� �������̵��Ͽ� �׼� ó�� ����
    }

    // Rigidbody2D�� �̿��� ĳ������ �̵��� ó���ϴ� �ż���
    private void Movment(Vector2 direction)
    {
        direction = direction * 5; // �ӵ� ����(5�� ���� ��)

        if (knockbackDuration > 0.0f)  // �˹��� Ȱ��ȭ�Ǿ� �ִٸ�
        {
            direction *= 0.2f; // �˹� �߿��� �ӵ� 20%�� ����
            direction += knockback; // �˹� ���� �߰�
        }

        _rigidbody.velocity = direction; // ���� �������� Rigidbody2D�� �ӵ��� ����
    }

    // �ٶ󺸴� ���⿡ ���� ĳ���Ϳ� ���⸦ ȸ����Ű�� �޼���
    private void Rotate(Vector2 direction)
    {
        // ���� ���Ϳ��� ȸ�� ������ ��� (���� -> �� ������ ��ȯ)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ȸ�� ������ 90���� ������ ������ ���� �ִٰ� �Ǵ�
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        // ĳ���Ͱ� ������ ���� ������ ��������Ʈ�� ����
        characterRenderer.flipX = isLeft;

        if (weaponPivot != null)  // ���Ⱑ �ִٸ�, ������ ȸ���� ���⿡ �°� ����
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ); // ���� �ǹ��� ȸ��
        }
    }

    // �ٸ� ��ü�κ��� �˹��� �����ϴ� ���� �޼���
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration; // �˹� ���� �ð� ����
                                      // �˹� ����� ũ�� ����
        knockback = -(other.position - transform.position).normalized * power;
    }
}
