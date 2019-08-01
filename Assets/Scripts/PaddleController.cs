using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed; //Speed motion
    public string axis; //Setting keyboard input
    public float topEdge;
    public float bottomEdge;
    void Start()    // Start is called before the first frame update
    {
        
    }

    void Update()   // Update is called once per frame
    {
        float motion = Input.GetAxis(axis) * speed * Time.deltaTime;    //Get the paddle movement
        float nextPos = transform.position.y + motion; //Predict the next position
        if (nextPos > topEdge) {
            motion = 0;
        }
        if (nextPos < bottomEdge) {
            motion = 0;
        }
        transform.Translate(0, motion, 0);  //Implementation to Paddle
    }
}
