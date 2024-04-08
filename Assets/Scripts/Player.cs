using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;   // 애니메이터를 가져올 변수

    public Transform pos = null;
    //public GameObject bullet; // 미사일 개수 여러 개
    public List<GameObject> bullet = new List<GameObject>();

    public int power = 0;

    // 레이저
    public GameObject lazer;
    public float gValue = 0;
    public Image Gage;


    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        // -1 ~ 0 ~ 1
        if (Input.GetAxis("Horizontal") <= -0.3f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= +0.3f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }


        if (Input.GetAxis("Vertical") >= +0.3f)
        {
            ani.SetBool("up", true);
        }
        else
        {
            ani.SetBool("up", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 프리팹 위치 방향 생성
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }

        //스페이스바 누르고 있을 때
        else if (Input.GetKey(KeyCode.Space))
        {
            gValue += Time.deltaTime;
            Gage.fillAmount = gValue;

            if(gValue >= 1)
            {
                // 레이저 나가기
                GameObject go = Instantiate(lazer, pos.position,
                    Quaternion.identity);
                Destroy(go, 3);
                gValue = 0;
            }

        }

        else
        {
            gValue -= Time.deltaTime;

            if(gValue <= 0)
            {
                gValue = 0;
            }

            // UI
            Gage.fillAmount = gValue;

        }


        transform.Translate(moveX, moveY, 0);

        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);   // x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y);   // y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);   // 다시월드좌표로 변환
        transform.position = worldPos;  // 좌표를 적용한다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            power++;
            if(power >= 3)
            {
                power = 3;
            }
            // 아이템 먹고 사라짐
            Destroy(collision.gameObject);
        }
    }
}
