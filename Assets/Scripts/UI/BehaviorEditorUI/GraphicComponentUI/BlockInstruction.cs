using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockInstruction : GraphicComponent
{
    private int idCond, idAction;
    private int priorityNb;
    int ify;
    private List<ConditionG> conditionGs;
    private List<MessageG> messageGs;
    private List<ActionNTG> actionNTGs;
    private ActionTG action;

    public void Start()
    {
        base.Start();
        this.conditionGs = new List<ConditionG>();
        this.messageGs = new List<MessageG>();
        this.actionNTGs = new List<ActionNTG>();
        this.action = new ActionTG();
    }

    public List<ConditionG> GetConditionGs()
    {
        return this.conditionGs;
    }

    public List<MessageG> GetMessageGs()
    {
        return this.messageGs;
    }

    public List<ActionNTG> GetActionNTGs()
    {
        return this.actionNTGs;
    }

    public ActionTG GetActionTG()
    {
        return this.action;
    }

    public int GetIdAction()
    {
        return this.idAction;
    }

    public int GetIdCond()
    {
        return this.idCond;
    }

    public void AddConditionG(ConditionG c)
    {
        this.conditionGs.Add(c);
    }

    public void AddMessagesG(MessageG c)
    {
        this.messageGs.Add(c);
    }

    public void AddActionNTG(ActionNTG c)
    {
        this.actionNTGs.Add(c);
    }

    public void SetActionTG(ActionTG c)
    {
        this.action = c; 
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    protected override void AddToBlockInstruction()
    {
        Debug.Log("Conditions " + this.conditionGs.Count);
        Debug.Log("ActionsNT " + this.actionNTGs.Count);
        Debug.Log("Messages " + this.messageGs.Count);
    }

}
