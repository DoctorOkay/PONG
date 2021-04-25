using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isPlayer;
    [SerializeField] Text scoreText;

    // properties
    public int score
    {
        get;
        set;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePaddle();
        scoreText.text = score.ToString();
    }

    void MovePaddle()
    {
        Vector3 velocity = new Vector3(0, speed);

        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // move up
                transform.Translate(velocity * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                // move down
                transform.Translate(-velocity * Time.fixedDeltaTime);
            }
        }
    }
}
