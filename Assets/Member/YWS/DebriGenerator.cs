using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DebriGenerator : MonoBehaviour
{
    [SerializeField, Header("生成するデブリの種類")] private GameObject[] debriArray = null;
    private Dictionary<int, int> debriAtk = new Dictionary<int, int>() //デブリの攻撃力
    {
        {0,1},
        {1,3},
        {2,5},
        {3,10}
    };
    [SerializeField, Header("フィールドの縦の長さ")] private int length = 20;
    [SerializeField, Header("フィールドの横の長さ")] private int width = 40;
    [SerializeField, Header("ゲーム開始時に生成する数")] private int defaultGenNum = 80;
    [SerializeField, Header("新しいデブリが生成されるまでの時間")] private float GenTime = 5f;
    [SerializeField, Header("生成したデブリを収納する親オブジェクト")] private Transform root = null;
    private float elapsedTime = 0f; //経過時間

    void Start()
    {
        //ゲーム開始時にデブリを配置する
        for (int i = 0; i < defaultGenNum; i++)
        {
            DebiriGenerate();
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        //一定時間で新しいデブリを生成する
        if (elapsedTime >= GenTime)
        {
            DebiriGenerate();
            elapsedTime = 0f;
        }
    }

    private void DebiriGenerate()
    {
        int GenType = Random.Range(0, debriArray.Length);
        int GenPosX = Random.Range(0, width);
        int GenPosZ = Random.Range(0, length);
        Vector3 GenPos = new Vector3(GenPosX, 0, GenPosZ);
        GameObject genDebri = Instantiate(debriArray[GenType], GenPos, Quaternion.identity);
        genDebri.transform.SetParent(root);
        //生成したデブリに攻撃力を与える
        if (debriAtk.TryGetValue(GenType, out int attack))
        {
            genDebri.GetComponent<Debri>().atk = attack;
        }
    }
}