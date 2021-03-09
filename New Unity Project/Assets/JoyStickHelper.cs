using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickHelper : MonoBehaviour
{
    // Start is called before the first frame update
    private Joystick joyStick;
    float moveSpeed = 30f;
    void Start()
    {
        joyStick = FindObjectOfType<Joystick>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(joyStick.Vertical != 0 || joyStick.Horizontal != 0)
        {
            this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(0f, 0f, -1 * Mathf.Atan2(joyStick.Horizontal, joyStick.Vertical) * Mathf.Rad2Deg);
        }   
    }
}
