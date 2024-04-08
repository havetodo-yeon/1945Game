using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    public int Attack = 10;
    public GameObject effect;

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

            // ���� ����, ( + ������ �ֱ�, , �� )
            // Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);


            // ����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1�� �ڿ� �����
            Destroy(go, 1);

            // �̻��� ����
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            // ����Ʈ ����
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1�� �ڿ� �����
            Destroy(go, 1);
            // �̻��� ����
            Destroy(gameObject);
            // 
        }


    }

}
