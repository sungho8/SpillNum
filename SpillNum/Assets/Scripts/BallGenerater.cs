using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerater : MonoBehaviour
{
    public GameObject ball;
    GameObject temp;

    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 해상도 대응
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;

            MakeBall();
        }
    }

    public void MakeBall()
    {
        temp = Instantiate(ball, new Vector2(Random.Range(-1.5f, 1.5f), transform.position.y), Quaternion.identity);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localScale = new Vector2(80, 80);
    }
}
