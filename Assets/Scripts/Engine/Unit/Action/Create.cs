using System;

public class Create : MetaAction
{	
	public Create(string param, string meth): base(param, meth){}
	
	public void setup(Unit unit){
		unit.NextAction = (Unit.Action)Delegate.CreateDelegate(typeof(Unit.Action), unit, methode);
        switch (unit.GetType().ToString())
        {
            case "WarEngineer":
                ((WarEngineer)unit).CreatorFeature.Type = Type.GetType(parametre);
                break;
            case "WarBase":
                ((WarBase)unit).CreatorFeature.Type = Type.GetType(parametre);
                break;
        }
        /* 
         * IL FAUT CHANGER CA, SELON LE MODE LA CLASSE WarEngineer/WarBase N'EXISTE PAS FORCEMENT 
         * Par consequent, a la creation du mod MetaBot, remplir cette classe par les classes
         * qui possedent la Feature Creator.
         * --> Les Features sont-elles dans le mod ou dans le noyau.
         */
    }
}