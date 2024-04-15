using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject effect;
    Transform pos;

    int Attack = 10;

    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
        SoundManager.Instance.SetAudio(3);
    }

    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            StartCoroutine(DamageMonster(collision));
        }

        if(collision.tag == "Boss")
        {
            StartCoroutine(DamageBoss(collision));
        }
    }

    IEnumerator DamageMonster(Collider2D collisionObject)
    {
        while(true)
        {
            collisionObject.gameObject.GetComponent<Monster>().Damage(Attack);
            // 이펙트 생성
            //GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //이펙트 1초 뒤 지우기
            GameManager.Instance.GetHurt(collisionObject.gameObject);
            //Destroy(go, 1);
            yield return new WaitForSeconds(0.9f);

        }
    }

    IEnumerator DamageBoss(Collider2D collisionObject)
    {
        while(true)
        {
            collisionObject.gameObject.GetComponent<Boss>().Damage(Attack);
            // 이펙트 생성
            //GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //이펙트 1초 뒤 지우기
            GameManager.Instance.GetHurt(collisionObject.gameObject);

            //Destroy(go, 1);
            yield return new WaitForSeconds(0.9f);

        }
    }

}
