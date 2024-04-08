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
    }

    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //이펙트 1초 뒤 지우기
            Destroy(go, 1);
        }

        if(collision.tag == "Boss")
        {
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //이펙트 1초 뒤 지우기
            Destroy(go, 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //이펙트 1초 뒤 지우기
            Destroy(go, 1);
        }

        if(collision.tag == "Boss")
        {
            // 이펙트 생성
            GameObject go = Instantiate(effect, collision.transform.position, Quaternion.identity);
            //이펙트 1초 뒤 지우기
            Destroy(go, 1);
        }
    }

}
