using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homming : MonoBehaviour
{
    GameObject target;  // ���⼭�� �÷��̾�
    public float speed = 3f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        // �÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Player");

        // A - B = A�� �ٶ󺸴� ���Ͱ� ���� : �÷��̾ �ٶ󺸴� ����
        dir = target.transform.position - transform.position;
        // ���⺤�͸� ���ϱ� : ��������(ũ�� 1)�� �����
        dirNo = dir.normalized;
        
        // �ӵ� �����ϴ� ����Ƽ ���� �Լ�!!
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
            // �÷��̾� ������
            ObjectColor.Instance.GetHurt(collision.gameObject);

            // �÷��̾� �����
            // Destroy(collision.gameObject);

            // �̻��� �����
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
