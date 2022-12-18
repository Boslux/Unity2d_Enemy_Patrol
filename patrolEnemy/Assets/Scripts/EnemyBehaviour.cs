using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed=1.5f;
    Rigidbody2D rb;
    BoxCollider2D bc;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsFaceingRight()==true)
        {
            //move right
            rb.velocity = new Vector2(speed, 0);
        }
        
        else
        {
            //move left
            rb.velocity = new Vector2(-speed, 0);
           
        }
    }
    void OnTriggerExit2D(Collider2D cls)
    {
        // for turn
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)),transform.localScale.y);

        if (cls.gameObject.CompareTag("Player"))
        {
            Destroy(cls.gameObject);
        }
    }
    private bool IsFaceingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
