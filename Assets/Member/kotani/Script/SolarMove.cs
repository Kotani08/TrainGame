using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SolarMove : MonoBehaviour {

	[SerializeField]
	private GameObject TheSun;
	//　1秒間の回転角度
	[SerializeField]
	private float rotateSpeed = 0.1f;
	//　0時の角度
	[SerializeField]
	private Vector3 rot = new Vector3 (270f, 330f, 0f);

	void Start() {
		TheSun.transform.localRotation = Quaternion.Euler (rot);
		//　現在のパソコンの時刻で太陽を傾ける
		var rotX = TheSun.transform.localEulerAngles.x - 15f * DateTime.Now.Hour;
		//　マイナスの値だったら360を足して0～360の間に補正
		if(rotX < 0) {
			rotX += 360f;
		}
		//　パソコンの時刻に合わせて太陽の角度を設定
		TheSun.transform.localEulerAngles = new Vector3(rotX, TheSun.transform.localEulerAngles.y, TheSun.transform.localEulerAngles.z);
	}

	// Update is called once per frame
	void Update () {
		//　徐々に回転させる、X軸を反対方向に回転
		TheSun.transform.Rotate (-Vector3.right * rotateSpeed * Time.deltaTime);
	}
}
