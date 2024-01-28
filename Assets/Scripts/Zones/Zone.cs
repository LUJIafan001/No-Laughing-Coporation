using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public List<GameObject> InZone;
    public Material UnhappyMaterial;
    public Material OriginMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Colleague")
        {
            other.GetComponent<Colleague>().isUnhappy = true;
            other.GetComponent<Colleague>().isLaughing = false;
            other.GetComponent<MeshRenderer>().material = UnhappyMaterial;
            InZone.Add(other.gameObject);
            other.GetComponentInChildren<Animator>().SetBool("isHappy", false);
            Colleagues.instance.CheckLaughingCount();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Colleague")
        {
            other.GetComponent<Colleague>().isUnhappy = false;
            other.gameObject.GetComponent<MeshRenderer>().material = OriginMaterial;
            InZone.Remove(other.gameObject);
        }
    }

}
