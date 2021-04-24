// The sprite will fall under its weight.  After a short time the
// sprite will start its upwards travel due to the thrust force that is added
// in the opposite direction


using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float thrust = 10.0f;

    void Start()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        //transform.position = new Vector3(0.0f, -2.0f, 0.0f);
    }

    void FixedUpdate()
    {
        rb2D.AddForce(transform.up * thrust);
    }
}