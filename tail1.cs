using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tail1 : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    void Start()
    {
    }
    public void follow(Vector2 newPosition, tail2 tail2) //两个小球跟随玩家正常移动
    {
        Vector2 previousPosition = transform.position;
        transform.position = newPosition;
        if (tail2 != null)
        {
            tail2.follow(previousPosition);
        }
    }

    public Boolean checkTail2(Vector2 dir, Vector2 newPosition) //是否需要重叠小球
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, layerMask);
        
        
        if (hit.collider != null && hit.collider.gameObject.GetComponent<tail2>() != null) //如果移动第一个小球时碰到第二个小球，重叠
        {
            Vector2 offset = new Vector2(0.01f, 0.01f);


            transform.Translate(dir);
            return true;
        }
        else //如果没有碰到第二个小球，交换位置
        {
            print("exchange");
            transform.position = newPosition;

        }
        
        return false;
    }

    public void moveToDir(Vector2 dir)
    {
        
            transform.Translate(dir);
        
    }
}
