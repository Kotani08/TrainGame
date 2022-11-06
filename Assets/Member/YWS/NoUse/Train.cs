using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Rigidbody trainRB = null;
    [SerializeField, Header("移動速度")] private float moveSpeed = 0.1f;
    private enum moveDirection
    {
        forward,
        turnLeft,
        turnRight
    }
    private List<moveDirection> diagram = new List<moveDirection>();
    [SerializeField, Header("進路探査オブジェクト")] public RouteCheck checker = null;
    private bool HaveNextRail = false;

    // Start is called before the first frame update
    void Start()
    {
        diagram.Add(moveDirection.forward);
    }

    // Update is called once per frame
    void Update()
    {
        RouteCheck();
        Movement();
    }

    private void Movement()
    {
        trainRB.velocity = new Vector3(moveSpeed, trainRB.velocity.y, trainRB.velocity.z);
    }

    private void RouteCheck()
    {
        //HaveNextRail = checker.HaveNextRail;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            Debug.Log(other.gameObject.GetComponent<Debri>().atk);
        }
    }
}