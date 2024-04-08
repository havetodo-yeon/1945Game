using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator ani;   // �ִϸ����͸� ������ ����

    public Transform pos = null;
    //public GameObject bullet; // �̻��� ���� ���� ��
    public List<GameObject> bullet = new List<GameObject>();
    //public List<GameObject> bombImage = new List<GameObject>();   // ��ź ���� ī����

    public int power = 0;
    public int bomb = 0;

    // ������
    public GameObject lazer;
    public float gValue = 0;
    public Image Gage;
    private bool isGaugeFull = false;


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
            // ������ ��ġ ���� ����
            Instantiate(bullet[power], pos.position, Quaternion.identity);
        }

        //�����̽��� ������ ���� ��
        else if (Input.GetKey(KeyCode.Space))
        {
            if (gValue < 1 && !isGaugeFull)
            {
                gValue += Time.deltaTime;
                Gage.fillAmount = gValue;
                if (gValue >= 1)
                {
                    isGaugeFull = true;
                    // ������ ������
                    GameObject go = Instantiate(lazer, pos.position,
                        Quaternion.identity);
                    Destroy(go, 2.5f);
                    gValue = 0;
                    Invoke("GaugeFalse", 2.5f);
                }
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

        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);   // x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y);   // y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);   // �ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos;  // ��ǥ�� �����Ѵ�.
    }

    public void GaugeFalse()
    {
        isGaugeFull = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Power")
        {
            if(power < 3)
            {
                Item item = collision.GetComponent<Item>();
                bomb++;
                GameObject go = Instantiate(item.text, transform.position, Quaternion.identity);
                Destroy(go, 0.5f);
            }
            // ������ �԰� �����
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Bomb")
        {
            if(bomb < 3)
            {
                Item item = collision.GetComponent<Item>();
                power++;
                GameObject go = Instantiate(item.text, transform.position, Quaternion.identity);
                Destroy(go, 0.5f);
            }
            // ������ �԰� �����
            Destroy(collision.gameObject);
        }
    }
}
