using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
class DragAndDrop : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    private BoxCollider2D collider;
    private Vector2 size;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        size = collider.size;
    }

    void OnMouseEnter()
    {
       // renderer.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
      //  renderer.material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x - size.x/2, rayPoint.y + size.y/2, rayPoint.z);
        }
    }
}