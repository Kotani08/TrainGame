using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DemoPalyerController : MonoBehaviour
{
    private float x;
    private float z;
    public float Speed = 1.0f;
    float smooth = 10f;
    [SerializeField]
    private Rigidbody rb;
    private Animator animator;
    [SerializeField]
    private GameObject _colList = null;
    private GameObject TakeObj = null;
    private string TagName;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();   //アニメーションを取得する
    }

    void Update()
    {
        KeyBoardCon();
        if (Gamepad.current != null){PadCon();}
    }

    #region キーボード操作
    private void KeyBoardCon()
    {
        float current_speed = playerAnimator.GetFloat("Blend");

	    // モーション切り替えを10秒で完結させる
	    //Animator.SetFloat("Speed", current_speed + Time.deltaTime * 0.1f);
        //x, z 平面での移動
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 target_dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = new Vector3(x, 0, z).normalized * Speed;         //歩く速度
        //animator.SetFloat("Walk", rb.velocity.magnitude);   //歩くアニメーションに切り替える
        playerAnimator.SetFloat("Blend", rb.velocity.magnitude);//歩くアニメーションに切り替える
        if (target_dir.magnitude > 0.1)
        {
            //キーを押し方向転換
            Quaternion rotation = Quaternion.LookRotation(target_dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smooth);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetRailObject();
            //animator.SetTrigger("Attack");    //マウスクリックで攻撃モーション
        }
    }
    #endregion

    #region コントローラー操作
    private void PadCon()
    {
       if (Gamepad.current.buttonSouth.wasReleasedThisFrame)
       {
           GetRailObject();
       }
    }
    #endregion

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RailObj") && _colList == null || other.gameObject.CompareTag("MetalObj") && _colList == null)
        {
            _colList = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RailObj") && _colList != null || other.gameObject.CompareTag("MetalObj") && _colList == null)
        {
            _colList = null;
        }
    }

    private void GetRailObject()
    {
        //ボタンが押されたときにisTrigger内にRailがあればそれを子オブジェクトにする
        if(_colList != null && TakeObj == null)
        {
            //_colListの物の当たり判定を消す
            //_colList.GetComponent<BoxCollider>().enabled = false;
            playerAnimator.SetBool("NowCarry",true);
            _colList.transform.SetParent(this.transform);
            _colList.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //要相談、決まり次第マジックナンバーを消す
            _colList.transform.localPosition = new Vector3(0.5f,1,1.7f);
            _colList.GetComponent<Rigidbody>().isKinematic = true;
            TagName = _colList.tag;
            _colList.tag = "TransportObj";
            TakeObj = _colList;
            _colList = null;
        }
        else if(TakeObj != null)
        {
            //座標をプレイヤーの前してから（めり込み対策）
            //TakeObj.transform.localPosition = new Vector3(0.5f,1,1.3f);
            //_colListの物の当たり判定を出す
            //TakeObj.GetComponent<BoxCollider>().enabled = true;
            playerAnimator.SetBool("NowCarry",false);
            TakeObj.tag = TagName;
            TakeObj.transform.parent = GameObject.Find ("StageObject").transform;
            TakeObj.GetComponent<Rigidbody>().isKinematic = false;
            TakeObj = null;
            _colList = null;
        }
    }
    private void SetRailObject()
    {
        //ボタンが押されたときに子オブジェクトにしているRailがあればそれを落とす
        //transform.parent = GameObject.Find ("Parent").transform;
    }
}
