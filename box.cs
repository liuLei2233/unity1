using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{

    public LayerMask layerMask;
    // Start is called before the first frame update
   

    public bool moveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, layerMask);
        if (hit.collider == null)
        {
            transform.Translate(dir);
            return true;
        }
        else
        {
            return false;
        }
    }
}
