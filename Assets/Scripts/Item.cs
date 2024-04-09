using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    /*    public Vector3 MovePos; // 이동벡터
        public float speed = 4f;

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
    */

    // 아이템 가속 속도 
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;
    public GameObject text;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

}
