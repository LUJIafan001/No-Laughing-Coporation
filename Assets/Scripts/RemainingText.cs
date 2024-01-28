using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingText : MonoBehaviour
{
    private void Update()
    {
        if(PassZone.instance!= null)
        {
            this.GetComponent<TextMeshProUGUI>().text = Colleagues.instance.isLaughingCount + "/" + PassZone.instance.neededPassCount;
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = Colleagues.instance.isLaughingCount+ "";
        }

        this.GetComponent<TextMeshProUGUI>().color = Color.yellow;
    }
}
