using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallNumber : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip[] bubbleSound;

    float[] r;
    float[] g;
    float[] b;

    SpriteRenderer render;
    ParticleSystem particle;
    Animation anim;
    public int number;
    TextMesh numText;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        particle = transform.GetChild(0).GetComponent<ParticleSystem>();
        particle.Stop();
        anim = gameObject.GetComponent<Animation>();
        numText = transform.GetChild(1).GetComponent<TextMesh>();
        SetColorArray();

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.bubbleSound[0];
        this.audio.loop = false;

        if(number!= 1)
            SetColor();
    }
    public void SetColorArray()
    {
        r = new float[12];
        g = new float[12];
        b = new float[12];
        r[0] = 255f / 255;  //2
        r[1] = 99f / 255;   //4
        r[2] = 205f / 255;  //8
        r[3] = 64f / 255;
        r[4] = 244f / 255;
        r[5] = 250f / 255;
        r[6] = 244f / 255;
        r[7] = 237f / 255;
        r[8] = 162f / 255;
        r[9] = 160f / 255;
        r[10] = 209f / 255;
        r[11] = 255f / 255;

        g[0] = 189f / 255;
        g[1] = 188f / 255;
        g[2] = 175f / 255;
        g[3] = 109f / 255;
        g[4] = 106f / 255;
        g[5] = 84f / 255;
        g[6] = 130f / 255;
        g[7] = 62f / 255;
        g[8] = 194f / 255;
        g[9] = 237f / 255;
        g[10] = 247f / 255;
        g[11] = 181f / 255;

        b[0] = 137f / 255;
        b[1] = 204f / 255;
        b[2] = 214f / 255;
        b[3] = 150f / 255;
        b[4] = 121f / 255;
        b[5] = 96f / 255;
        b[6] = 91f / 255;
        b[7] = 119f / 255;
        b[8] = 255f / 255;
        b[9] = 255f / 255;
        b[10] = 176f / 255;
        b[11] = 204f / 255;
    }

    public int GetNumber()
    {
        return number;
    }

    public void SetNumber(int number)
    {
        this.number = number;
    }

    public void SetColor()
    {
        numText.text = number.ToString();
        if (render != null)
        {
            int i = (int)(Mathf.Log(number) / Mathf.Log(2f)) - 1;
            render.color = new Color(r[i], g[i], b[i]);
        }
    }

    [System.Obsolete]
    public void SumNumber(int sum)
    {
        this.audio.clip = this.bubbleSound[Random.Range(0, 6)];
        this.audio.Play();
        delayTime(1f);
        number += sum;
        SetColor();
        anim.Play("merge");
        particle.startColor = render.color;
        particle.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            BallNumber ballnumber = collision.GetComponent<BallNumber>();
            if (ballnumber.GetNumber() == number)
            {
                anim.Play("destroy");
                Destroy(this.gameObject,0.5f);
                // 대상은 +
                ballnumber.SendMessage("SumNumber",number);
            }
        }
    }

    IEnumerator delayTime(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
