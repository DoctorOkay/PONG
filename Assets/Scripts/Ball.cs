using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // step 1: move the ball
        Vector2 ballVel = new Vector2(ballSpeed, ballSpeed / 2);
        Vector2 newBallPos = new Vector2();

        newBallPos = transform.position;
        newBallPos += ballVel;

        // set up the min and max points of the screen
        Vector3 screenMin = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 screenMax = new Vector3(Screen.width, Screen.height, 0);
        screenMax = Camera.main.ScreenToWorldPoint(screenMax);

        // step 2: bounce ball around the screen
        if (newBallPos.x < screenMin.x)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.x = screenMin.x + GetComponent<SpriteRenderer>().bounds.size.x;
            ballVel.x = -ballVel.x;
        }
        if (newBallPos.x > screenMax.x)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.x = screenMax.x - GetComponent<SpriteRenderer>().bounds.size.x;
            ballVel.x = -ballVel.x;
        }
        if (newBallPos.y < screenMin.y)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.y = screenMin.y + GetComponent<SpriteRenderer>().bounds.size.y;
            ballVel.y = -ballVel.y;
        }
        if (newBallPos.y > screenMax.y)
        {
            // place the ball on the screen edge and reverse the velocity
            newBallPos.y = screenMax.y - GetComponent<SpriteRenderer>().bounds.size.y;
            ballVel.y = -ballVel.y;
        }

        transform.position = newBallPos;
    }
}
