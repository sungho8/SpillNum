using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    TextMesh scoreText;
    public GameObject scoreEffect;
    public GameObject comboEffect2;
    public GameObject comboEffect3;
    public GameObject comboEffect4;
    public GameObject comboEffect5;
    int turn;
    int combo;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMesh>();
        turn = 0;
        combo = 0;
    }

    public void SetTurn()
    {
        ++turn;
        combo = 0;
    }

    public void SetScoreText(Score score)
    {
        GameObject sEffect = Instantiate(scoreEffect);
        sEffect.name = CutClone(sEffect.name);
        sEffect.transform.SetParent(GameObject.Find("Canvas").transform);
        sEffect.transform.localPosition = score.position + new Vector3(-6,60);
        sEffect.transform.localPosition = new Vector3(sEffect.transform.localPosition.x, sEffect.transform.localPosition.y,0);
        TextMesh effectText = sEffect.GetComponent<TextMesh>();

        combo++;
        scoreText.text = (int.Parse(scoreText.text.ToString()) + combo * score.number).ToString();

        GameObject cEffect = null;
        switch (combo)
        {
            case 2:
                cEffect = Instantiate(comboEffect2);
                break;
            case 3:
                cEffect = Instantiate(comboEffect3);
                break;
            case 4:
                cEffect = Instantiate(comboEffect4);
                break;
            case 5:
                cEffect = Instantiate(comboEffect5);
                break;
        }
        if(cEffect != null)
        {
            cEffect.transform.SetParent(GameObject.Find("Canvas").transform);
            cEffect.transform.localScale = new Vector2(4, 4);
            cEffect.transform.localPosition = score.position + new Vector3(-6, 60);
            cEffect.transform.localPosition = new Vector3(sEffect.transform.localPosition.x, sEffect.transform.localPosition.y, 0);
        }

        effectText.text = "+" + (combo * score.number);
    }

    string CutClone(string name)
    {
        string result;
        int cut = name.Length - 7;
        result = name.Substring(0, cut);
        return result;
    }
}
