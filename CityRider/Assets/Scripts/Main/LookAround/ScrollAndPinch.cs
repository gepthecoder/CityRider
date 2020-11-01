using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScrollAndPinch : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0f, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }
    //private Touch touch;
    //private float speed_modifier;

    //private float deltaX, deltaY;

    //public Rigidbody target;

    //void Start()
    //{
    //    speed_modifier = 0.01f;
    //}


    //// Update is called once per frame
    //void Update()
    //{
    //    if(Input.touchCount > 0)
    //    {

    //        touch = Input.GetTouch(0);

    //        if(touch.phase == TouchPhase.Moved)
    //        {
    //            transform.position = new Vector3(
    //                transform.position.x + touch.deltaPosition.x * speed_modifier,
    //                transform.position.y,
    //                transform.position.z + touch.deltaPosition.y * speed_modifier
    //                );
    //        }

    //        //Touch touch = Input.GetTouch(0);
    //        //Vector2 touch_pos = Camera.main.ScreenToWorldPoint(touch.position);
    //        //switch (touch.phase)
    //        //{
    //        //    case TouchPhase.Began:
    //        //        deltaX = touch_pos.x - transform.position.x;
    //        //        deltaY = touch_pos.y - transform.position.y;
    //        //        Debug.Log("Begin!!!");
    //        //        break;
    //        //    case TouchPhase.Moved:
    //        //        target.MovePosition(new Vector3((touch_pos.x - deltaX), 0f, (touch_pos.y - deltaY)));
    //        //        Debug.Log("Moveeeed!!!");
    //        //        break;
    //        //    case TouchPhase.Ended:
    //        //        target.velocity = Vector3.zero;
    //        //        Debug.Log("End!!!");
    //        //        break;
    //        //}
    //    }


    //}


}
