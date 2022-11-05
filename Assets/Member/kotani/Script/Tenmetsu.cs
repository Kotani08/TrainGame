using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Tenmetsu : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer mesh;
    float alpha_Sin;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0,0,0,0);
        StartCoroutine("Transparent");
    }

    void Update()
    {
        alpha_Sin = Mathf.Sin(Time.time) / 2 + 0.5f;
    }
 
    IEnumerator Transparent()
    {
        while (true){
        yield return new WaitForEndOfFrame();

        Color _color = mesh.material.color;

        _color.a = alpha_Sin/2;

        mesh.material.color= _color;
        }
    }
}