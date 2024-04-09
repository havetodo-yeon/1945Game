using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int HP = 1000;

    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;

    public Transform pos1;
    public Transform pos2;

    public GameObject deadEffect;


    void Start()
    {
        // 1초 뒤에 Hide 함수 호출
        Invoke("Hide", 1);

        StartCoroutine(BossMissle());   // 코루틴 실행
        StartCoroutine(CirceFire());   // 코루틴 실행
    }

    void Hide()
    {
        // 보스 텍스트 객체 이름 검색해서 찾기
        GameObject.Find("TextBossWarning").SetActive(false);
    }

    IEnumerator BossMissle()
    {
        while (true)
        {
            // 미사일 두 개
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    // 원방향으로 미사일 발사
    IEnumerator CirceFire()
    {
        // 공격 주기
        float attackRate = 3;
        // 발사체 생성 개수
        int count = 30;
        // 발사체 사이의 각도
        float intervalAngle = 360 / count;
        // 가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정
        float weightAngle = 0f;

        // 원 형태로 발사하는 발사체 생성(count 갯수만큼)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                // 발사체 생성
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);
                // 발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                // 발사체 이동(벡터)
                // Cos(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                // Sin(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                // 발사체 이동 방향 설정
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }

            // 발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            // 3초마다 미사일 발사
            yield return new WaitForSeconds(attackRate);

        }
    }

    public void Damage(int attack)
    {
        HP -= attack;
        if (HP <= 0)
        {
            // 이펙트 생성
            GameObject go = Instantiate(deadEffect, transform.position, Quaternion.identity);
            // 1초 뒤에 지우기
            Destroy(go, 2);

            Destroy(gameObject);
        }
    }



    void Update()
    {
        if(transform.position.x > 0.6f)
        {
            flag *= -1;
        }
        if(transform.position.x < -0.6f)
        {
            flag *= -1;
        }

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);

    }
}
