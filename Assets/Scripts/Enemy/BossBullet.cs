using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float Speed = 3f;

    Vector2 vec2 = Vector2.down;

    // ������ �����ϴ� �Լ�
    public void Move(Vector2 vec)
    {
        vec2 = vec;
    }

    void Update()
    {
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // �̻��� ����
            Destroy(gameObject);
        }
    }


}
