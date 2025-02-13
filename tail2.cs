using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail2 : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void follow(Vector2 newPosition)
    {
        transform.position = newPosition;

    }
    public Boolean moveToDir(Vector2 dir, tail1 tail1)
    {
        print("tail1 tail2 overlap");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, layerMask);
        if (hit.collider == null) //如果移动重叠小球时没有碰到其他物体
        {
            transform.Translate(dir);
            tail1.moveToDir(dir);
            return true;
        }
        else
        {
            print(hit.collider.name);
            if (hit.collider.gameObject.GetComponent<box>() != null) //如果碰到了box
            {
                if (hit.collider.gameObject.GetComponent<box>().moveToDir(dir))
                {
                    transform.Translate(dir);
                    tail1.moveToDir(dir);
                    return true;
                }
            }


        }

            return false;
    }

    public void moveToDir2(Vector2 dir)
    {

        transform.Translate(dir);

    }
}
