using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DrawLine drawControll;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        drawControll.StartLine(transform.position);
    }

    private void OnMouseDrag()
    {
        
    }
    
    private void OnMouseUp()
    {

    }
}
