using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb2d;

    bool faceRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        rb2d.AddForce(movement * speed);

        Flip(moveHorizontal);
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !faceRight ||  horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
