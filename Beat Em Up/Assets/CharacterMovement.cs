using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float hSpeed = 10f;
    private float vSpeed = 6f;
    private Rigidbody2D rigidbody2D;
    private bool canMove = true;

    private bool facingRight = true;

    [Range(0, 1f)]
    float movementSmoothing = 0.2f;
    private Vector3 velocity = Vector3.zero;


    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float hMove, float vMove, bool jump)
    {
        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(hMove * hSpeed, vMove * vSpeed);

            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

            if (hMove > 0 && !facingRight)
            {
                flip();
            } else if (hMove < 0 && facingRight)
            {
                flip();
            }
        }
    }

    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
