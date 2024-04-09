using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MBullet : MonoBehaviour
{
    public float Speed = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // �浹 ó��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player")))
        {
            // �÷��̾� ������
            ObjectColor.Instance.GetHurt(collision.gameObject);

            // �÷��̾� �����
            // Destroy(collision.gameObject);

            // �̻��� �����
            Destroy(gameObject);
        }
    }

}
