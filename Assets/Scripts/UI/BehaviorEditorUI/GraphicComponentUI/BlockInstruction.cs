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

    public void Awake()
    {
        base.Start();
        this.conditionGs = new List<ConditionG>();
        this.messageGs = new List<MessageG>();
        this.actionNTGs = new List<ActionNTG>();
        this.action = new ActionTG();
    }

    /*public void init()
    {
        Debug.Log("Starting");
        base.Start();
        this.conditionGs = new List<ConditionG>();
        this.messageGs = new List<MessageG>();
        this.actionNTGs = new List<ActionNTG>();
        this.action = new ActionTG();
    }*/

    public void SetAllConditionGs(List<ConditionG> g)
    {
        this.conditionGs = new List<ConditionG>(g);
    }

    public void SetAllMessagesGs(List<MessageG> g)
    {
        this.messageGs = new List<MessageG>(g);
    }

    public void SetAllActionNTGs(List<ActionNTG> g)
    {
        this.actionNTGs = new List<ActionNTG>(g);
    }

    public void SetAllActionTG(ActionTG a)
    {
        this.action = Instantiate(a);
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

    public void RemoveConditionG(ConditionG c)
    {
        this.conditionGs.Remove(c);
    }

    public void RemoveMessagesG(MessageG c)
    {
        this.messageGs.Remove(c);
    }

    public void RemoveActionNTG(ActionNTG c)
    {
        this.actionNTGs.Remove(c);
    }

    public void RemoveActionTG(ActionTG c)
    {
        this.action = null;
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public override void AddToBlockInstruction()
    {
        Debug.Log("Conditions " + this.conditionGs.Count);
        Debug.Log("ActionsNT " + this.actionNTGs.Count);
        Debug.Log("Messages " + this.messageGs.Count);
        if(this.action!=null) Debug.Log("Action found");
        else Debug.Log("Action not found");
    }

    public override void DeleteFromList()
    {
        base.DeleteFromList();

        foreach (ConditionG g in this.conditionGs)
        {
            Destroy(g.gameObject);
        }

        this.conditionGs.Clear();

        foreach (MessageG g in this.messageGs)
        {
            Destroy(g.gameObject);
        }

        this.messageGs.Clear();

        foreach (ActionNTG g in this.actionNTGs)
        {
            Destroy(g.gameObject);
        }

        this.actionNTGs.Clear();

        if (this.action != null) Destroy(this.action.gameObject);

    }

}
