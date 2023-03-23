public abstract class State
{
	protected Unit unit;
	public abstract void StartState();
	public abstract void UpdateState();
	public abstract void EndState();
	public State(Unit unit)
	{
		this.unit = unit;
	}
}