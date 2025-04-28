using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public Rigidbody MyRig;
    public int direction;
    public bool up;
    public int speed;
    public int timer;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        MyRig = GetComponent<Rigidbody>();
        StartCoroutine(Cycle());
    }

    public IEnumerator Cycle()
    {
        yield return new WaitForSeconds(timer);
        if (up)
        {
            up = false;
        }
        else
        {
            up = true;
        }
        StartCoroutine(Cycle());
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            //vertical
            if (up)
            {
                // MyRig.velocity = new Vector3(0, speed, 0);
                movement = Vector3.up;
            }
            else
            {
                // MyRig.velocity = new Vector3(0, -speed, 0);
                movement = Vector3.down;
            }
        }
        else if (direction == 2)
        {
            //horizontal
            if (up)
            {
                // MyRig.velocity = new Vector3(speed, 0, 0);
                movement = Vector3.right;
            }
            else
            {
                // MyRig.velocity = new Vector3(-speed, 0, 0);
                movement = Vector3.left;
            }
        }
        MyRig.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
