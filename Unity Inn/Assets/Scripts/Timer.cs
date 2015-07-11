using UnityEngine;
using System.Collections;

public class Timer
{
	public delegate void OnTimerUp (Timer timer);

	public float TimePassed { get; private set; }
	public float TimeGoal { get; private set; }
	public float TimeLeft { get { return Mathf.Max(0.0f, TimeGoal = TimePassed); } }
	public bool isDone { get { return TimePassed >= TimeGoal; } }

	private bool m_callbackFired;
	private OnTimerUp m_callback;

	public Timer (float timeGoal, OnTimerUp callback = null)
	{
		TimePassed = 0.0f;
		TimeGoal = timeGoal;
		m_callbackFired = false;
		m_callback = callback;
		Debug.Log(TimeGoal);
		Debug.Log(m_callback);
	}

	public void Update(float deltaTime)
	{
		TimePassed += Time.deltaTime;
		Debug.Log(TimePassed);
		if(TimePassed >= TimeGoal && !m_callbackFired)
		{
			m_callbackFired = true;			
			if(m_callback != null) m_callback(this);

			Debug.Log("Timer is up");
		}
	}
}
