using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float movement;
    public static Rigidbody2D bgBody;

    private void Start()
    {
        bgBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            bgBody.velocity = new Vector2(movement * -1, bgBody.velocity.y);
        }
        else if (movement < 0)
        {
            bgBody.velocity = new Vector2(movement * -1, bgBody.velocity.y);
        }
    }
}
