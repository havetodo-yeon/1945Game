using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn Instance;

    public float ss = -2;   // 몬스터 생성 x값 처음
    public float es = 2;    // x값 끝
    public float startTime = 1; // 시작
    public float spawnStop = 10; // 생성 끝나는 시간

    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject monster2;
    // [SerializeField] private List<GameObject> monsters;
    [SerializeField] private GameObject Boss;

    bool swi = true;
    bool swi2 = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", spawnStop);
    }

    // 코루틴 함수
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            // 1초마다
            yield return new WaitForSeconds(startTime);
            // x값 랜덤
            float x = Random.Range(ss, es);
            // x값 랜덤 y값은 자기 자신 값
            Vector2 r = new Vector2(x, transform.position.y);

            // 몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
        }
    }

    // 코루틴 함수
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            // 3초마다
            yield return new WaitForSeconds(startTime + 2);
            // x값 랜덤
            float x = Random.Range(ss, es);
            // x값 랜덤 y값은 자기 자신 값
            Vector2 r = new Vector2(x, transform.position.y);

            // 몬스터 생성
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    private void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        // 두 번째 몬스터
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", spawnStop + 20);
    }

    private void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");

        // 보스 몬스터
        UIManager.Instance.BossTextSet("Boss Warning!", 2f);

        Vector3 pos = new Vector3(0, 3.1f, 9);
        
        Instantiate(Boss, pos , Quaternion.identity);   


    }


}
