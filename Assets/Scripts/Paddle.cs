using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 10f;
    [SerializeField] float cameraHeight = 4f;

    SpriteRenderer paddleSprite;

    // Start is called before the first frame update
    void Start()
    {
        paddleSprite = GetComponent<SpriteRenderer>();
    }   

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }
    private void MovePaddle()
    {
        Vector2 paddlePos = new Vector2();
        Vector3 spriteBounds = paddleSprite.sprite.bounds.size;

        float maxPaddle_Y = cameraHeight - spriteBounds.y;
        float minPaddle_Y = -cameraHeight + spriteBounds.y;
        float scaledPaddleSpeed = paddleSpeed * Time.deltaTime;

        paddlePos.x = transform.position.x;
        paddlePos.y = transform.position.y;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            paddlePos.y = Mathf.Clamp((paddlePos.y + scaledPaddleSpeed), minPaddle_Y, maxPaddle_Y);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            paddlePos.y = Mathf.Clamp((paddlePos.y - scaledPaddleSpeed), minPaddle_Y, maxPaddle_Y);
        }

        transform.position = paddlePos;
    }
}
