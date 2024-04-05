using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;

    public Transform pos1;
    public Transform pos2;

    void Start()
    {
        StartCoroutine(BossMissle());   // �ڷ�ƾ ����
        StartCoroutine(CirceFire());   // �ڷ�ƾ ����
    }

    IEnumerator BossMissle()
    {
        while (true)
        {
            // �̻��� �� ��
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    // ���������� �̻��� �߻�
    IEnumerator CirceFire()
    {
        // ���� �ֱ�
        float attackRate = 3;
        // �߻�ü ���� ����
        int count = 30;
        // �߻�ü ������ ����
        float intervalAngle = 360 / count;
        // ���ߵǴ� ���� (�׻� ���� ��ġ�� �߻����� �ʵ��� ����
        float weightAngle = 0f;

        // �� ���·� �߻��ϴ� �߻�ü ����(count ������ŭ)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                // �߻�ü ����
                GameObject clone = Instantiate(mb2, transform.position, Quaternion.identity);
                // �߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                // �߻�ü �̵�(����)
                // Cos(����)���� ������ ���� ǥ���� ���� pi/180�� ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                // Sin(����)���� ������ ���� ǥ���� ���� pi/180�� ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                // �߻�ü �̵� ���� ����
                clone.GetComponent<BossBullet>().Move(new Vector2(x, y));
            }

            // �߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;

            // 3�ʸ��� �̻��� �߻�
            yield return new WaitForSeconds(attackRate);

        }
    }


    void Update()
    {
        if(transform.position.x > 1)
        {
            flag *= -1;
        }
        if(transform.position.x < -1)
        {
            flag *= -1;
        }

        transform.Translate(flag * speed * Time.deltaTime, 0, 0);

    }
}