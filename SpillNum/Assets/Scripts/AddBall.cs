using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    public GameObject ball;
    GameObject temp;

    public void Ball()
    {
        string n = this.gameObject.name;
        int l = this.gameObject.name.Length;
        int num = int.Parse(n.Substring(l - 1));

        MakeBall((int)Mathf.Pow(2, num));
        Destroy(this.gameObject);
    }

    public void MakeBall(int num)
    {
        temp = Instantiate(ball, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        temp.name = CutClone(temp.name);
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        temp.transform.localScale = new Vector2(80, 80);

        temp.GetComponent<BallNumber>().SetNumber(num);
    }

    string CutClone(string name)
    {
        string result;
        int cut = name.Length - 7;
        result = name.Substring(0, cut);
        return result;
    }
}
