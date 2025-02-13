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
    public void follow(Vector2 newPosition, tail2 tail2) //����С�������������ƶ�
    {
        Vector2 previousPosition = transform.position;
        transform.position = newPosition;
        if (tail2 != null)
        {
            tail2.follow(previousPosition);
        }
    }

    public Boolean checkTail2(Vector2 dir, Vector2 newPosition) //�Ƿ���Ҫ�ص�С��
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, layerMask);
        
        
        if (hit.collider != null && hit.collider.gameObject.GetComponent<tail2>() != null) //����ƶ���һ��С��ʱ�����ڶ���С���ص�
        {
            Vector2 offset = new Vector2(0.01f, 0.01f);


            transform.Translate(dir);
            return true;
        }
        else //���û�������ڶ���С�򣬽���λ��
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
