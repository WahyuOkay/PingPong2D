using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int force;   //Adjust the speed motion of the ball
    Rigidbody2D rigid;  //Variable rigidbody
    void Start()    // Start is called before the first frame update
    {
        rigid = GetComponent<Rigidbody2D>();    //Call Rigidbody2D
        Vector2 direction = new Vector2(2, 0).normalized;   //Express the direction of the ball, which is 2 units to the right and 0 units up.
        rigid.AddForce(direction * force);  //Throw the ball according to direction and strength.
    }

    void Update()   // Update is called once per frame
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "RightEdge")  //When the ball touches the RightEdge
        {
            ResetBall();    //Call function ResetBall()
            Vector2 direction = new Vector2(2, 0).normalized;   //Express the direction of the ball, which is 2 units to the right and 0 units up.
            rigid.AddForce(direction * force);  //Throw the ball according to direction and strength.
        }
        if (coll.gameObject.name == "LeftEdge")   //When the ball touches the LeftEdge
        {
            ResetBall();    //Call function ResetBall()
            Vector2 direction = new Vector2(-2, 0).normalized;   //Express the direction of the ball, which is 2 units to the left and 0 units up.
            rigid.AddForce(direction * force);  //Throw the ball according to direction and strength.
        }
        if (coll.gameObject.name == "Paddle1" || coll.gameObject.name == "Paddle2") //When the ball touches the Paddle1 and the Paddle2
        {
            float angle = (transform.position.y - coll.transform.position.y)*5f;    //Calculate tilt the ball
            Vector2 direction = new Vector2(rigid.velocity.x, angle).normalized;    //Determine the direction of the ball to be reflected
            rigid.velocity = new Vector2(0, 0); //Stop the movement of the ball
            rigid.AddForce(direction * force * 2);  //Throw the ball according to direction and strength multiplied by 2.
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);    //Position the ball in the middle of the area
        rigid.velocity = new Vector2(0, 0); //Stop the movement of the ball
    }
}
