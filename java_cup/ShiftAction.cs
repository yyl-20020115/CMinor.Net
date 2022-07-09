namespace JavaCUP;

public class ShiftAction : ParseAction
{
	protected internal LalrState shiftTo;

    public virtual LalrState ShiftTo => shiftTo;

    public ShiftAction(LalrState shiftTo)
	{
		if (shiftTo == null)
		{
			
			throw new InternalError("Attempt to create a shift_action to a null state");
		}
		this.shiftTo = shiftTo;
	}



    public virtual bool Equals(ShiftAction other) => (other != null && other.ShiftTo== ShiftTo) ? true : false;

    public override int Kind => 1;

    public override bool Equals(object other) => other is ShiftAction ? Equals((ShiftAction)other) : false;

    public override int GetHashCode() => ShiftTo.GetHashCode();

    public override string ToString() => ("SHIFT(to state ") + (ShiftTo.Index()) + (")");
}
