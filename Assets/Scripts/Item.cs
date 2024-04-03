using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Item : MonoBehaviour
{
    public Vector3 MovePos; // 이동벡터
    public float speed = 4f;

/*    private void Start()
    {
        MovePos = -new Vector2(1f, 1f).normalized;
        StartCoroutine("Reflect");
    }

    IEnumerator Reflect()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            float distanceY = speed * Time.deltaTime;
            float distanceX = speed * Time.deltaTime;
            transform.Translate(distanceX, -distanceY, 0);
        }
    }*/


    void Start()
    {
        MovePos = new Vector2(-1f, -1f).normalized;
    }

    void Update()
    {
        transform.position += MovePos * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }


    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
