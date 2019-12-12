using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject finish;
    public GameObject start;
    bool gameOver = false;
    float speed = 0.012f;

    // Update is called once per frame
    void Update()
    {
        if (finish.transform.position.y < transform.position.y)
        {
            gameOver = true;
        }

        if (!gameOver)
        {
            transform.Translate(Vector3.up * speed);
            if(start.transform.position.y > transform.position.y)
            {
                transform.position = start.transform.position;
            }
        }
    }

    public void downFlag(int num)
    {
        transform.Translate(Vector3.down * 0.5f * num);
    }
}
