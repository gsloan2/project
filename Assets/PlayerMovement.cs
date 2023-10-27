using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public Rigidbody2D playerBody;
    private Animator animator;
    public SpriteRenderer spriteRenderer;

    Vector2 dir;


    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetFloat("X", -1);
            animator.SetFloat("Y", 0);
            spriteRenderer.flipX = true;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetFloat("X", 1);
            animator.SetFloat("Y", 0);
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", 1);
            spriteRenderer.flipX = false;
            if (Input.GetKey(KeyCode.A))
            {
                spriteRenderer.flipX = true;
            }
            else spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", -1);
            if (Input.GetKey(KeyCode.A))
            {
                spriteRenderer.flipX = true;
            }
            else spriteRenderer.flipX = false;

        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
        
    }


}
