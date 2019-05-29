using System;

public class Move : MetaAction
{
    public Move(string param, string meth) : base(param, meth) { }

    public void setup(MovableUnit unit)
    {
        unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);        
    }
}