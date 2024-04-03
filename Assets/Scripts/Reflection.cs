using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Item"))
            {
                Item b = collision.gameObject.GetComponent<Item>();

                //            b.StopCoroutine("Reflect");
                //            b.speed *= -1;
                //            b.StartCoroutine("Reflect");
                
                Vector3 income = b.MovePos; // 입사벡터
                Vector3 normal = collision.contacts[0].normal; // 법선벡터
                b.MovePos = Vector3.Reflect(income, normal).normalized; // 반사벡터
            }
        }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item b = collision.gameObject.GetComponent<Item>();
        if (collision.gameObject.tag.Equals("Item"))
        {

            Vector3 income = b.MovePos; // 입사 벡터
            Vector3 normal = new Vector2(1, 0); // 예시로 설정한 법선 벡터, 실제 사용 시 적절하게 설정 필요

            // 2D 반사 벡터 직접 계산
            Vector3 reflect = Vector2.Reflect(income, normal).normalized;
            b.MovePos = reflect;
        }
    }

}
