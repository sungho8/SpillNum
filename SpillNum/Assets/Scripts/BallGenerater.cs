using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerater : MonoBehaviour
{
    public GameObject ball;
    GameObject temp;

    private float TimeLeft = 1.0f;
    private float nextTime = 0.0f;

    public void MakeBall()
    {
        temp = Instantiate(ball, new Vector2(Random.Range(-1.5f, 1.5f), transform.position.y), Quaternion.identity);
        temp.name = CutClone(temp.name);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localScale = new Vector2(80, 80);
    }

    string CutClone(string name)
    {
        string result;
        int cut = name.Length - 7;
        result = name.Substring(0, cut);
        return result;
    }
}
