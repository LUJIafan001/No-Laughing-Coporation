using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponentInParent<Guard>().isActived = true;
            this.gameObject.SetActive(false);   
        }
    }

}
