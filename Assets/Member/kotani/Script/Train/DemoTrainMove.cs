using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTrainMove : MonoBehaviour
{
    [SerializeField]
    private TrainTimer trainTimer;
    // Update is called once per frame
    void Update()
    {
        if(trainTimer.CountDownTime != 0f){TrainMove();}
    }

    private void TrainMove()
    {
        transform.position += transform.right * 1f * Time.deltaTime;
    }
}
