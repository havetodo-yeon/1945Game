using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int HP = 100;

    public int score = 100;
    public float Speed = 3;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;

    public GameObject effect;

    // 아이템 가져오기
    public GameObject Item;

    void Start()
    {
        // 한 번 함수 호출
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        // 재귀 호출
        Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        // 아래 방향으로 움직이기
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // 미사일에 따른 데미지 입는 함수
    public void Damage(int attack)
    {
        HP -= attack;
        if(HP <= 0)
        {
            ItemDrop();

            // 이펙트 생성
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            // 1초 뒤에 지우기
            Destroy(go, 1);

            UIManager.Instance.ScoreSet(score);

            Destroy(gameObject);
        }
    }

    public void ItemDrop()
    {
        // 아이템 생성
        Instantiate(Item, transform.position, Quaternion.identity);
    }

     

}
