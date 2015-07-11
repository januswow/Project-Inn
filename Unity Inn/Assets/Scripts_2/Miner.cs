using UnityEngine;

public enum Locations { goldmine, bar, bank, home };

public class Miner : MonoBehaviour {
	
	private FiniteStateMachine FSM<Miner>;
	
	public Locations  Location = Locations.goldmine;
	public int           GoldCarried = 0;
	public int           MoneyInBank  = 0;
	public int           Thirst = 0;
	public int           Fatigue = 0;
	
	public void Awake() {
		Debug.Log("Miner awakes...");
		FSM = new FiniteStateMachine();
		FSM.Configure(this, EnterMineAndDigForNuggets.Instance);
	}
	
	public void ChangeState(FSMState e) {
		FSM.ChangeState(e);
	}
	
	public void Update() {
		Thirst++;
		FSM.Update();
	}
	
	public void ChangeLocation(Locations l) {
		Location = l;
	}
	
	public void AddToGoldCarried(int amount) {
		GoldCarried += amount;
	}
	
	public void AddToMoneyInBank(int amount ) {
		MoneyInBank += amount;
		GoldCarried = 0;
	}
	
	public bool RichEnough() {
		return false;
	}
	
	public bool PocketsFull() {
		bool full = GoldCarried ==  2 ? true : false;
		return full;
	}
	
	public bool Thirsty() {
		bool thirsty = Thirst == 10 ? true : false;
		return thirsty;
	}
	
	public void IncreaseFatigue() {
		Fatigue++;
	}
}