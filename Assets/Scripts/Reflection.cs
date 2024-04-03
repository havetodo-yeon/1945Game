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
                
                Vector3 income = b.MovePos; // �Ի纤��
                Vector3 normal = collision.contacts[0].normal; // ��������
                b.MovePos = Vector3.Reflect(income, normal).normalized; // �ݻ纤��
            }
        }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item b = collision.gameObject.GetComponent<Item>();
        if (collision.gameObject.tag.Equals("Item"))
        {

            Vector3 income = b.MovePos; // �Ի� ����
            Vector3 normal = new Vector2(1, 0); // ���÷� ������ ���� ����, ���� ��� �� �����ϰ� ���� �ʿ�

            // 2D �ݻ� ���� ���� ���
            Vector3 reflect = Vector2.Reflect(income, normal).normalized;
            b.MovePos = reflect;
        }
    }

}
