using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RestaurantManager : MonoBehaviour {

	public static List<Food> Stock = new List<Food>();
	public static List<Food> CookingSlots = new List<Food>();
	public static int MaxCookingSlots { get; private set; }

	//UI Components
	public Text CookingNameText;
	public Text CookingTimeLeftText;
	public Text CookingWaitingText;
	public Text StockInfoText;

	void Awake()
	{
		MaxCookingSlots = 3;
	}

	void Update()
	{
		if (CookingSlots.Count > 0)
		{
			//烹飪佇列中有項目存在
			if (CookingSlots[0] != null)
			{
				//有東西要烹飪, 就更新他的update做計時
				CookingSlots[0].Update(Time.deltaTime);
				RefreshInfoText(CookingSlots[0]);
				
				if (CookingSlots[0].IsReady)
				{
					Debug.Log("Cooking slots [0] is ready");
					// 烹飪佇列的第一項已烹飪完成, 送至庫存中並從烹飪佇列中移除
					Stock.Add(CookingSlots[0]);
					CookingSlots.RemoveAt(0);
					RefreshInfoText();
				}
			}
		}
	}

	public void RefreshInfoText (Food cookingOne = null)
	{
		if (cookingOne != null)
		{
			CookingNameText.text = cookingOne.Name;
			CookingTimeLeftText.text = cookingOne.TimeLeft.ToString();
			CookingWaitingText.text = (CookingSlots.Count - 1).ToString();
		} else {
			CookingNameText.text = "";
			CookingTimeLeftText.text = "";
			CookingWaitingText.text = "";
		}
		StockInfoText.text = Stock.Count.ToString();
	}

	public void Cook ()
	{
		//烹飪一道食物
		Food newFood = new Food();
		if (CookingSlots.Count < MaxCookingSlots)
		{
			// 還有烹飪的空位
			Debug.Log ("Start new cook");
			CookingSlots.Add(newFood);
			newFood.StartTimer();
			RefreshInfoText();
		}
	}
	
}
