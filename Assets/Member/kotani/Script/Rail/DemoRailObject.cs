using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoRailObject : MonoBehaviour
{
    [SerializeField]
    private GameObject apexRail;
    [SerializeField]
    private GameObject RailPrefab;
    [SerializeField]
    private Transform ParentTransform;
    [SerializeField]
    private TrainTimer trainTimer;

    private float RailOutTime =5f;

    //レールの管理
    //付近にレールがあれば置いたときに座標を固定する
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RailObj"))
        {
            //otherのタグのobjectを消す
            //other.gameObject.SetActive (false);
            Destroy(other.gameObject);
            //RailPrefabを前に出す
            var obj = Instantiate(RailPrefab);  
            obj.transform.SetParent(ParentTransform);
            transform.SetAsLastSibling();  //一番下(uGUIなら前面)
            obj.transform.localPosition = apexRail.transform.localPosition + new Vector3(6,0,0);
            apexRail.GetComponent<BoxCollider>().enabled = false;
            apexRail.transform.Find("Cube").gameObject.SetActive(false);
            apexRail = obj;
            trainTimer.CountDownTime += RailOutTime;
        }
        if(other.gameObject.CompareTag("OutZoneRail"))
        {
            trainTimer.CountDownTime =0;
        }
    }
}
