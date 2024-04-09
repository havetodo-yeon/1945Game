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

    // 충돌 처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player")))
        {
            // 플레이어 데미지
            ObjectColor.Instance.GetHurt(collision.gameObject);

            // 플레이어 지우기
            // Destroy(collision.gameObject);

            // 미사일 지우기
            Destroy(gameObject);
        }
    }

}
