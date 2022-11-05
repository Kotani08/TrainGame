using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrainLight : MonoBehaviour
{
    [SerializeField]
    private GameObject trainLightObject;
    [SerializeField]
    private GameObject drivingSeatLightObject;
    [SerializeField]
	private GameObject TheSun;
    [SerializeField]
    private bool AMFlag;
    [SerializeField]
    private float AaaaaaaFlag;

    private float lightStrength;
    // Start is called before the first frame update
    void Start()
    {
        lightStrength = trainLightObject.GetComponent<Light>().intensity;
        //AaaaaaaFlag = TheSun.transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        AaaaaaaFlag = TheSun.transform.localEulerAngles.x;
        if(TheSun.transform.localEulerAngles.x <=360f &&TheSun.transform.localEulerAngles.x >=340f&&  lightStrength <=6)
        {
        trainLightObject.GetComponent<Light>().intensity = lightStrength;
        drivingSeatLightObject.GetComponent<Light>().intensity = lightStrength;
        lightStrength=lightStrength+0.01f;
        }
        else if(TheSun.transform.localEulerAngles.x >=0f && TheSun.transform.localEulerAngles.x <=120f && lightStrength >=0)//&& TheSun.transform.localEulerAngles.x >=160f)
        {
        trainLightObject.GetComponent<Light>().intensity = lightStrength;
        drivingSeatLightObject.GetComponent<Light>().intensity = lightStrength;
        lightStrength=lightStrength-0.01f;
        }
        //TrainLightControl();
    }

    private void TrainLightControl()
    {
        if(AMFlag == true&& lightStrength <=6){
        trainLightObject.GetComponent<Light>().intensity = lightStrength;
        drivingSeatLightObject.GetComponent<Light>().intensity = lightStrength;
        lightStrength=lightStrength+0.01f;
        }
        else if(AMFlag == false&& lightStrength >=0)
        {
        trainLightObject.GetComponent<Light>().intensity = lightStrength;
        drivingSeatLightObject.GetComponent<Light>().intensity = lightStrength;
        lightStrength=lightStrength-0.01f;
        }
    }
}
