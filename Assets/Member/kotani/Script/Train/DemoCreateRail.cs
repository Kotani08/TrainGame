using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCreateRail : MonoBehaviour
{
    [SerializeField]
    private GameObject RailPrefab;
    [SerializeField]
    private Transform ParentTransform;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MetalObj"))
        {
            Destroy(collision.gameObject);
            var obj = Instantiate(RailPrefab);  
            obj.transform.SetParent(ParentTransform);
            obj.transform.localPosition = ParentTransform.localPosition;
        }
    }
}
