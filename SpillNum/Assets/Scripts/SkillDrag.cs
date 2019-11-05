using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDrag : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 objPosition;
    Vector3 originPosition;
    public Vector3 initMousePos;
    int slot;
    void Update()
    {

    }

    public void SetSlot(int slot)
    {
        this.slot = slot;
    }

    void OnMouseDown()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        originPosition = transform.position;

        initMousePos = Input.mousePosition;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
    }

    void OnMouseDrag()
    {
        Vector3 worldPoint = Input.mousePosition;
        worldPoint.z = -10;
        worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);
        Vector3 diffPos = worldPoint - initMousePos;
        diffPos.z = 0;
        initMousePos = Input.mousePosition;
        initMousePos.z = -10;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + diffPos.x, -4.5f, 4.5f),
                        transform.position.y + diffPos.y,
                        transform.position.z);
    }

    public void OnMouseUp()
    {
        float flagY = GameObject.Find("Flag").transform.position.y;

        // 영역 내부
        if(transform.position.y > flagY)
        {
            this.gameObject.GetComponent<AddBall>().Ball();
            GameObject.Find("Generator").GetComponent<SkillGenerator>().MakeSkill(slot);
        }
        // 영역밖
        else            
        {
            transform.position = originPosition;
        }
    }
}
