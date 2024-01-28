using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Colleague")
        {
            if(collision.gameObject.GetComponent<Colleague>().isUnhappy != true)
            {
                collision.gameObject.GetComponent<Colleague>().isLaughing = true;
                collision.gameObject.GetComponentInChildren<Animator>().SetBool("isHappy", true);
            }
            Colleagues.instance.CheckLaughingCount();
        }
    }
}
