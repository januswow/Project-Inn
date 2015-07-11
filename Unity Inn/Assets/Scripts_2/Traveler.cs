using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Traveler : MonoBehaviour {

	private FiniteStateMachine FSM<Traveler>;

	public int Hungry = 0;
	public int Fatigue = 0;

	public bool IsAccepted;

	public void Awake()
	{
		Debug.Log("Traveler arrived...");
		FSM = new FiniteStateMachine();
		FSM.Configure(this, TravelerState_Wait.Instance);

		IsAccepted = false;

		// initialize traveler status
		Fatigue = Random.Range(30, 100);
		Hungry = Random.Range(50,70);
	}

	public void Update () {
		Hungry++;
		FSM.Update();

		// test
		if (Hungry > 90) IsAccepted = true;
	}

	public void ChangeState (FSMState state)
	{
		FSM.ChangeState(state);
	}

	public void IncreaseFatigue (int amount = 1)
	{
		if ((Fatigue + amount) <= 100)
			Fatigue += amount;
	}

	public void DecreaseFatigue (int amount = 1)
    {
		if ((Fatigue - amount) >= 0)
		    Fatigue -= amount;
    }

	public void IncreaseHungry (int amount = 1)
	{
		if ((Hungry + amount) <= 100)
			Hungry += amount;
	}
	
	public void DecreaseHungry (int amount = 1)
	{
		if ((Hungry - amount) >= 0)
			Hungry -= amount;
	}
}
