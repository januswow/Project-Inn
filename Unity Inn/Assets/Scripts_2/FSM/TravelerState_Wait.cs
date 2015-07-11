using UnityEngine;

public sealed class TravelerState_Wait : FSMState<Traveler>
{
	static readonly TravelerState_Wait instance = new TravelerState_Wait();
	public static TravelerState_Wait Instance { get { return instance; } }

	static TravelerState_Wait() {}
	private TravelerState_Wait() {}

	public override void Enter (Traveler t)
	{
		Debug.Log("Traveler is waiting your acception.");
	}

	public override void Execute (Traveler t)
	{
		// waiting for acception...
		if (t.IsAccepted)
		{
			t.ChangeState(TravelerState_Rest.Instance);
		}
	}

	public override void Exit (Traveler t)
	{
		Debug.Log("Traveler is leaving from waiting line, finding a room for rest.");
	}
}