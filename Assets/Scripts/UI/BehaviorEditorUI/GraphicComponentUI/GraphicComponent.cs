using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicComponent : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, ISelectHandler, IPointerClickHandler, IDeselectHandler
{
    private int id;
    protected Transform transform;
    private bool dragging = false;
    private float distance;
    private BoxCollider2D collider;
    protected Vector2 size;
    protected BlockInstruction blockinstruction;
    protected Color baseColour;
    protected Color selectColour;

    public static HashSet<GraphicComponent> allMySelectables = new HashSet<GraphicComponent>();
    public static HashSet<GraphicComponent> currentlySelected = new HashSet<GraphicComponent>();


    // Start is called before the first frame update
    public void Start()
    {
        this.transform = this.gameObject.transform;
        collider = GetComponent<BoxCollider2D>();
        size = collider.size;
        allMySelectables.Add(this);
        baseColour = GetComponent<Image>().color;
        selectColour = baseColour * 0.8f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 posChange = new Vector2(  - this.transform.position.x + eventData.position.x, - this.transform.position.y + eventData.position.y);
        foreach (GraphicComponent g in currentlySelected)
        {
            g.transform.position = new Vector2( g.transform.position.x + posChange.x, g.transform.position.y + posChange.y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left || currentlySelected.Contains(this)) OnSelect(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        magnet();
        AddToBlockInstruction(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void magnet()
    {
        float dx, dy;

        float modx = (this.transform.localPosition.x) % (this.GetComponent<BoxCollider2D>().size.x);
        modx = this.GetComponent<BoxCollider2D>().size.x + modx;

        if (modx >= size.x / 2.0)
        {
            dx = this.GetComponent<BoxCollider2D>().size.x - modx;
        }
        else
        {
            dx = -modx;
        }

        float mody = (this.transform.localPosition.y) % (this.GetComponent<BoxCollider2D>().size.y);
        mody = this.GetComponent<BoxCollider2D>().size.y + mody;
        if (mody >= this.GetComponent<BoxCollider2D>().size.y / 2.0)
        {
            dy = this.GetComponent<BoxCollider2D>().size.y - mody;
        }
        else
        {
            dy = -mody;
        }
        
        foreach (GraphicComponent g in currentlySelected)
        {
            float x, y;
            x = (g.transform.localPosition.x + dx);
            y = (g.transform.localPosition.y + dy);
            g.transform.localPosition = new Vector2(x, y);
        }
    }

    // To be overridden in sub classses
    protected virtual void AddToBlockInstruction()
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        if(!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            Debug.Log("Selected");
            DeselectAll(eventData);
        }

        Select(this);
    }

    public void Select(GraphicComponent g)
    {
        GetComponent<Image>().color = selectColour;
        currentlySelected.Add(g);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        GetComponent<Image>().color = baseColour;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) OnSelect(eventData);
        if (eventData.button == PointerEventData.InputButton.Right) CopyPaste(eventData);
    }

    public static void DeselectAll(BaseEventData eventData)
    {
        foreach (GraphicComponent s in currentlySelected)
            s.OnDeselect(eventData);

        currentlySelected.Clear();
    }

    protected void CopyPaste(PointerEventData eventData)
    {
        List<GraphicComponent> toAdd = new List<GraphicComponent>();

        foreach (GraphicComponent g in currentlySelected)
        {
            Vector3 offset = new Vector3(g.transform.parent.position.x+30, g.transform.parent.position.y + 30, g.transform.parent.position.z);

            GraphicComponent gClone = Instantiate(g, g.transform.parent) as GraphicComponent;
            gClone.GetComponent<Image>().color = g.baseColour;

            float x, y;
            x = (g.transform.localPosition.x + 30.0f);
            y = (g.transform.localPosition.y - 60.0f);
            g.transform.localPosition = new Vector2(x, y);

            toAdd.Add(gClone);
        }

        Debug.Log("Deselecting");

        DeselectAll(eventData);

        foreach (GraphicComponent g in toAdd) Select(g);
    }
}
