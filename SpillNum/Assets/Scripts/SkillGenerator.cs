using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGenerator : MonoBehaviour
{
    public GameObject[] commonSkills = new GameObject[4];
    public GameObject[] slots = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            MakeSkill(i);
        }
    }

    public void MakeSkill(int i)
    {
        int r = Random.Range(0,3);
        GameObject skill = Instantiate(commonSkills[r]);
        skill.name = CutClone(skill.name);
        skill.transform.SetParent(GameObject.Find("Canvas").transform);
        skill.transform.localScale = new Vector2(41, 41);
        skill.transform.position = slots[i].transform.position;
        skill.GetComponent<SkillDrag>().SetSlot(i);
    }

    string CutClone(string name)
    {
        string result;
        int cut = name.Length - 7;
        result = name.Substring(0,cut);
        return result;
    }
}
