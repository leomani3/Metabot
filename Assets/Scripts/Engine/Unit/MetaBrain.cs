using System.Collections;

public class MetaBrain
{
	private ArrayList instructions;
	
	private delegate void ActionToReturn();

    public MetaBrain(ArrayList instr)
    {
		instructions = instr;
    }
	
	public void decide(Unit unit){
		//ORDONNER LES INSTRUCTIONS PAR PRIORITES
		foreach(MetaInstruction i in instructions){
			if(i.satisfied(unit)){
				i.Action.setup(unit);
			}
		}
	}

    override
    public string ToString()
    {
        string s = "";
        foreach(MetaInstruction instr in instructions) {
            s += instr.ToString() + "\n";
        }
        return s;
    }
}