using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homming : MonoBehaviour
{
    GameObject target;  // 여기서는 플레이어
    public float speed = 3f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        // 플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Player");

        // A - B = A를 바라보는 벡터가 나옴 : 플레이어를 바라보는 벡터
        dir = target.transform.position - transform.position;
        // 방향벡터만 구하기 : 단위벡터(크기 1)로 만든다
        dirNo = dir.normalized;
        
        // 속도 유도하는 유니티 전용 함수!!
        // Vector3.MoveTowards

    }

    void Update()
    {
        transform.Translate(dirNo * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 플레이어 데미지
            ObjectColor.Instance.GetHurt(collision.gameObject);

            // 플레이어 지우기
            // Destroy(collision.gameObject);

            // 미사일 지우기
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
