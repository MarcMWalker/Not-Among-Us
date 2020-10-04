using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D_Movement : MonoBehaviour
{

    public float speed;
    bool faceRight = true;
    Vector3 velocity;
    Camera viewCamera;

    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);
        Flip(horizontal);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
