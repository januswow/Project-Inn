using UnityEngine;

public sealed class TravelerState_Eat : FSMState<Traveler>
{	
	static readonly TravelerState_Eat instance = new TravelerState_Eat();
	public static TravelerState_Eat Instance { get { return instance; } }
	
	static TravelerState_Eat() {}
	private TravelerState_Eat() {}
	
	public override void Enter (Traveler t)
	{
		Debug.Log("Travele is seeking for food.");
	}
	
	public override void Execute (Traveler t)
	{
		Debug.Log("Traveler get into the restaurant.");

		t.DecreaseHungry(1);

		if (t.Hungry < 20)
		{
			// go back to room
			t.ChangeState(TravelerState_Rest);
			Debug.Log("Traveler want back to room.");
		}
	}
	
	public override void Exit (Traveler t)
	{
		Debug.Log("Traveler is leaving restaurant.");
	}
}