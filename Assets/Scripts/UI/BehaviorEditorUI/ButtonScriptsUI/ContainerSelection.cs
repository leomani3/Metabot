using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSelection : MonoBehaviour
{
    // To attach to Viewport
    // Add only if there's the tag puzzle piece
    // Destroy after use

    public GameObject Container;
    private List<int> puzzlePieceColliderIDs;

    void Start()
    {
        puzzlePieceColliderIDs = new List<int>();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo, 1))
            {
                if (!puzzlePieceColliderIDs.Contains(hitInfo.collider.GetInstanceID()))
                {
                    puzzlePieceColliderIDs.Add(hitInfo.collider.GetInstanceID());
                    GameObject selected = hitInfo.collider.gameObject;
                    selected.transform.parent = Container.transform;
                }
            }
        }
    }
}
