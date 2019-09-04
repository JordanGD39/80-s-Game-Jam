using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float form = 0;

    public float speed;
    public float maxSpeed;
    private bool damaged = false;

    // Start is called before the first frame update
    void Start()
    {
        form = GameManager.instance.form;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (form == 0)
        {
            anim.Play("PlayerForm0");
        }
        if (form == 1)
        {
            anim.Play("PlayerForm1");
        }
    }    

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            transform.position += Vector3.left * 7 * Time.deltaTime;
            transform.Rotate(0, 0, -10);
            if (transform.position.x < -8f)
            {
                speed = 80;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                damaged = false;                
            }
        }        
    }

    private void FixedUpdate()
    {
        Vector3 easeVelocity = rb.velocity;
        easeVelocity.y *= 0.75f;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.velocity = easeVelocity;

        rb.AddForce((Vector2.right * speed) * h);

        rb.AddForce((Vector2.up * speed) * v);

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
        if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxSpeed);
        }
    }

    public void Damage()
    {
        damaged = true;
        speed = 0;
    }

}
