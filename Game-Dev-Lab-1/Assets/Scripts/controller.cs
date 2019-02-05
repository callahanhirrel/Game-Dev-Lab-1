using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

    public float speed;
    public Transform relativeTransform;
    public float time;
    public int coinsLeft;
    public TextMesh timeText;
    public TextMesh coinText;
    private bool clockRun;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        time = 0f;
        coinsLeft = 10;
        timeText.text = "Time: 0";
        coinText.text = "Coins Left: 10";
        clockRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (clockRun)
        {
            time += Time.deltaTime;
            timeText.text = $"Time: {time}";
        }

        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow)) moveDirection += relativeTransform.forward;
        if (Input.GetKey(KeyCode.DownArrow)) moveDirection += -relativeTransform.forward;
        if (Input.GetKey(KeyCode.RightArrow)) moveDirection += relativeTransform.right;
        if (Input.GetKey(KeyCode.LeftArrow)) moveDirection += -relativeTransform.right;

        moveDirection.y = 0f;

        transform.position += moveDirection.normalized * speed * Time.deltaTime;
        //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f,
        //                    Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinsLeft -= 1;
            coinText.text = $"Coins Left: {coinsLeft}";
            if (coinsLeft == 0)
            {
                clockRun = false;
            }
        }
    }
}
