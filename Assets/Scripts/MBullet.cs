using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float Speed = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // �浹 ó��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
