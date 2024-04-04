using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    public int Attack = 10;


    void Update()
    {
        // �̻��� ���� �������� �����̱�
        // ���� ���� * ����Ʈ * Ÿ��
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    // ȭ�� ������ ���� ���
    private void OnBecameInvisible()
    {
        // �ڱ� �ڽ� �����
        Destroy(gameObject);
    }

    // �浹ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // ������ �����϶�� ����
            // collision.gameObject.GetComponent<Monster>().ItemDrop();

            // ���� ����, ( + ������ �ֱ�, ����Ʈ ����, �� )
            // Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);


            // �̻��� ����
            Destroy(gameObject);
        }
    }

}
