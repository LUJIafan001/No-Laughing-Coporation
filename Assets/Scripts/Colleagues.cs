using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colleagues : MonoBehaviour
{
    public static Colleagues instance;

    private void Awake()
    {
        instance = this;
    }
    public float isLaughingCount;
    public void CheckLaughingCount()
    {
        isLaughingCount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.GetComponent<Colleague>())
            {
                if (child.GetComponent<Colleague>().isLaughing)
                {
                    isLaughingCount++;
                }
            }
        }
    }
}
