using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFollow : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public Transform player;
    private Vector3 offset;
    private Vector3 sphe;
    private Vector3 cam;
    public float yOffset = 0.1f;
    public float zOffset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        sphe = new Vector3(player.position.x, player.position.y, player.position.z);
        cam = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        offset = cam - sphe;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}
