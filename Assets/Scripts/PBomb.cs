using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBomb : MonoBehaviour
{
    public int Attack = 50;

    private void Start()
    {
        SoundManager.Instance.SetAudio(1);
        Destroy(gameObject, 1.5f);
    }

    // �浹ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // ���� ����, ( + ������ �ֱ�, , �� )
            // Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);

            GameManager.Instance.GetHurt(collision.gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            GameManager.Instance.GetHurt(collision.gameObject);

            collision.gameObject.GetComponent<Boss>().Damage(Attack);

        }
    }


}
