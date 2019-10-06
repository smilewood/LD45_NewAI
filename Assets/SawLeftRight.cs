using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawLeftRight : MonoBehaviour
{
    public bool direction;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.position = rb.position + new Vector2((direction ? 1f : -1f) * speed, 0f) * Time.deltaTime;
    }
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (!collision.gameObject.tag.Equals("EnviromentalDeath"))
            direction = !direction;
    }
}
