using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float ss = -2;   // ���� ���� x�� ó��
    public float es = 2;    // x�� ��
    public float startTime = 1; // ����
    public float spawnStop = 10; // ���� ������ �ð�

    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject monster2;
    // [SerializeField] private List<GameObject> monsters;

    bool swi = true;
    bool swi2 = true;

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", spawnStop);
    }

    // �ڷ�ƾ �Լ�
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            // 1�ʸ���
            yield return new WaitForSeconds(startTime);
            // x�� ����
            float x = Random.Range(ss, es);
            // x�� ���� y���� �ڱ� �ڽ� ��
            Vector2 r = new Vector2(x, transform.position.y);

            // ���� ����
            Instantiate(monster, r, Quaternion.identity);
        }
    }

    // �ڷ�ƾ �Լ�
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            // 3�ʸ���
            yield return new WaitForSeconds(startTime + 2);
            // x�� ����
            float x = Random.Range(ss, es);
            // x�� ���� y���� �ڱ� �ڽ� ��
            Vector2 r = new Vector2(x, transform.position.y);

            // ���� ����
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    private void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        // �� ��° ����
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", spawnStop + 20);
    }

    private void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");

        // ���� ����


    }


}