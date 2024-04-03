using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            ItemSpawn.Instance.RandomItem(collision.transform);

        }
    }

}
