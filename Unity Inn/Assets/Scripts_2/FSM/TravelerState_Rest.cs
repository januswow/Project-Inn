using UnityEngine;

public sealed class TravelerState_Rest : FSMState<Traveler>
{	
	static readonly TravelerState_Rest instance = new TravelerState_Rest();
	public static TravelerState_Rest Instance { get { return instance; } }
	
	static TravelerState_Rest() {}
	private TravelerState_Rest() {}
	
	public override void Enter (Traveler t)
	{
		Debug.Log("Traveler found a room for rest.");
	}
	
	public override void Execute (Traveler t)
	{
		Debug.Log("Traveler is resting in room");
		t.DecreaseFatigue(1);
		if (t.Fatigue < 40 && t.Hungry > 40)
		{
			// seek for food
			t.ChangeState(TravelerState_Eat);
			Debug.Log("Traveler want to eat.");
		}
		if (t.Fatigue == 0)
		{
			Debug.Log("Traveler feels awesome!");
		}
	}
	
	public override void Exit (Traveler t)
	{
		Debug.Log("Traveler is leaving room");
	}
}