using UnityEngine;
using System.Collections;

public class Food
{
	public string Name { get; private set; }
	public float TimeCost { get; private set; }
	public float TimeCooked { get; private set; }
	public float TimeLeft { get { return Mathf.RoundToInt(TimeCost - TimeCooked); } }
	public bool IsReady { get { return TimeCooked >= TimeCost; } }

	private bool m_isTimerOn;
	private bool m_callbackFired;

	// Consructor
	public Food ()
	{
		Name = "Cooked Beef";
		TimeCost = 5;
		TimeCooked = 0;

		m_isTimerOn = false;
		m_callbackFired = false;
	}

	public void Update (float deltaTime)
	{
		if (m_isTimerOn) TimeCooked += deltaTime;

		if (TimeCooked >= TimeCost  && !m_callbackFired)
		{
			// 已經烹飪完成
			m_callbackFired = true;
			Debug.Log("Cook is done.");
		}
	}

	public void StartTimer () {
		m_isTimerOn = true;
	}

}
