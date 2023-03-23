using System.Collections.Generic;
using System.Linq;

public class StateMachine
{

	public enum StateEnum
	{
		Idle,
		Move,
		Attack,
		Dead,
	}
	public enum Command
	{
		Move,
		Attack,
		Dead,
		Idle,
	}

	private StateEnum _currentState = StateEnum.Idle;
	private List<Transition> _transitions = new List<Transition>()
	{
		// Default Transitions
		new Transition(StateEnum.Idle,StateEnum.Dead,Command.Dead),
		new Transition(StateEnum.Move,StateEnum.Dead,Command.Dead),
		new Transition(StateEnum.Attack,StateEnum.Dead,Command.Dead),

		new Transition(StateEnum.Idle,StateEnum.Move,Command.Move),
		new Transition(StateEnum.Attack,StateEnum.Move,Command.Move),

		new Transition(StateEnum.Move,StateEnum.Idle,Command.Idle),
		new Transition(StateEnum.Attack,StateEnum.Idle,Command.Idle),

		new Transition(StateEnum.Move,StateEnum.Attack,Command.Attack),
		new Transition(StateEnum.Idle,StateEnum.Attack,Command.Attack),

	};
	private Dictionary<StateEnum, State> _states = new Dictionary<StateEnum, State>();

	public StateMachine(Dictionary<StateEnum, State> states)
	{
		_states = states;
	}
	public StateMachine(Dictionary<StateEnum, State> states, List<Transition> transitions)
	{
		_states = states;
		_transitions = transitions;
	}

	public StateEnum CurrentState { get => _currentState; }

	StateEnum GetNextState(Command command)
	{
		var v = _transitions.FirstOrDefault(x => x.command == command && x.currentState == _currentState);
		if (v == null)
		{
			return StateEnum.Idle;
		}
		return v.nextState;
	}
	protected virtual State GetState(StateEnum state)
	{
		return _states[state];
	}
	public State GetNextStateByCommand(Command command)
	{
		StateEnum stateEnum = GetNextState(command);
		State nextState = GetState(stateEnum);
		_currentState = stateEnum;
		return nextState;
	}
	public void SetStates(Dictionary<StateEnum, State> states)
	{
		this._states = states;
	}

}
public class Transition
{
	public StateMachine.StateEnum currentState;
	public StateMachine.StateEnum nextState;
	public StateMachine.Command command;

	public Transition(StateMachine.StateEnum currentState, StateMachine.StateEnum nextState, StateMachine.Command command)
	{
		this.currentState = currentState;
		this.nextState = nextState;
		this.command = command;
	}
}

