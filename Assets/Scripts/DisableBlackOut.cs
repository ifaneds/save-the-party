using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableBlackOut : MonoBehaviour
{
    Color thisColor;
    // Start is called before the first frame update
    void Start()
    {
        thisColor = this.GetComponent<Image>().color;
        thisColor = new Color(thisColor.r, thisColor.g, thisColor.b, 0);
        this.GetComponent<Image>().color = thisColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
