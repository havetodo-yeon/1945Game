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
        // 미사일 위쪽 방향으로 움직이기
        // 위의 방향 * 스피트 * 타임
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    // 화면 밖으로 나갈 경우
    private void OnBecameInvisible()
    {
        // 자기 자신 지우기
        Destroy(gameObject);
    }

    // 충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // 아이템 생성하라고 전달
            // collision.gameObject.GetComponent<Monster>().ItemDrop();

            // 몬스터 삭제, ( + 데미지 주기, , 등 )
            // Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Monster>().Damage(Attack);


            // 이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1초 뒤에 지우기
            Destroy(go, 1);

            // 미사일 삭제
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            // 이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1초 뒤에 지우기
            Destroy(go, 1);
            // 미사일 삭제
            Destroy(gameObject);
            // 
        }


    }

}
