using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPanelRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //this.transform.rotation += Quaternion.Euler(0,0,1);
        this.transform.Rotate(0,0.1f,0);
    }
}
