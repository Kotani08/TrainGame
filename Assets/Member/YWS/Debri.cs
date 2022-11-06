using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Debri : MonoBehaviour
{
    public int atk = 0; //攻撃力

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    private void Init()
    {
        //それっぽくするために乱数で回転を与える
        float RotateX = Random.Range(0, 360);
        float RotateY = Random.Range(0, 360);
        float RotateZ = Random.Range(0, 360);
        this.transform.rotation = Quaternion.Euler(RotateX, RotateY, RotateZ);
    }

    private void OnCollisionEnter(Collision other)
    {
        //列車にぶつかったら自身を破壊する
        if (other.gameObject.tag == "Train")
        {
            Destroy(this.gameObject);
        }
    }
}