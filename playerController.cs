using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Vector2 moveDir;
    public LayerMask layerMask;
    public tail1 tail1;
    public tail2 tail2;
    Boolean tailCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        tail1 = FindObjectOfType<tail1>(); //第一个小球
        tail2 = FindObjectOfType<tail2>(); //第二个小球
        print(tail1);
        print(tail2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDir = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDir = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDir = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDir = Vector2.right;
        }

        if (moveDir != Vector2.zero && canMove(moveDir))
        {
            move(moveDir);
            moveDir = Vector2.zero;
        }
    }

    public bool canMove(Vector2 dir)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, layerMask);


        tailCollide = false;
        if (hit.collider == null)
        {
            return true;
        }
        else
        {
            if (hit.collider.gameObject.GetComponent<box>() != null) //碰到了box
            {
                return hit.collider.gameObject.GetComponent<box>().moveToDir(dir);
            }
            print(hit.collider.gameObject.GetComponent<tail2>()); //tail2的碰撞体积大于tail1，所以重叠会先检测到tail2
            if (hit.collider.gameObject.GetComponent<tail2>() != null) //碰到了第二个小球
            {
                if (!AreTailsOverlapping(tail1, tail2)) //如果两个小球重叠
                {
                    print("tail2 and tail1 dected");
                   
                    tailCollide = true;
                    return tail2.moveToDir(dir, tail1);
                }

                return true;

            }
            else if (hit.collider.gameObject.GetComponent<tail1>() != null) //只碰到了第一个小球 考虑是否将两个小球位置重叠
            {
                Vector2 previousPosition = transform.position;
                print("only tail1 dected");
                tailCollide = true;
                tail1.checkTail2(dir, previousPosition);


                return true;
            }
            return false;
        }
    }

    public void move(Vector2 dir)
    {
        print("Moving");
        Vector2 previousPosition = transform.position; // Store current position
        transform.Translate(dir); // Move player
        if (tail1 != null && !tailCollide)
        {
            tail1.follow(previousPosition, tail2);
        }


    }

    public bool AreTailsOverlapping(tail1 t1, tail2 t2) //判断是否重叠 值给反了
    {
        
        Vector2 tail1Position = tail1.transform.position; // Get the position of tail1
        Vector2 tail2Position = tail2.transform.position; // Get the position of tail2
        print(tail1Position + " " + tail2Position);

        float distance = Vector2.Distance(tail1Position, tail2Position);
        print(distance);
        if (distance > 0.3)
        {
            // Check if the colliders are touching each other
            return true;
        }
        else
        {
            return false;
        }
    }
}
