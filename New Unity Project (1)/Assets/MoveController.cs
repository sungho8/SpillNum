using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    // Start is called before the first frame update
    private Joystick joyStick;
    float moveSpeed = 3f;
    private GameObject closestEnemy = null;
    private GameObject target;
    private float dist;

    void Start()
    {
        joyStick = FindObjectOfType<Joystick>();
        InvokeRepeating("FindEnemy", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        if (joyStick.Vertical != 0 || joyStick.Horizontal != 0)
        {
            this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(0f, 0f, -1 * Mathf.Atan2(joyStick.Horizontal, joyStick.Vertical) * Mathf.Rad2Deg);
        }
        else
        {
            
        }
    }

    void FindEnemy()
    {
        GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistSqr = Mathf.Infinity;//infinity 실제값?
        foreach (GameObject enemy in taggedEnemys)
        {
            Vector3 objectPos = enemy.transform.position;
            dist = (objectPos - transform.position).sqrMagnitude;
            
            closestDistSqr = dist;
            closestEnemy = enemy;
             
        }
        target = closestEnemy;

        Debug.Log(target.name);
    }
}
