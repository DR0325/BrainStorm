using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour {

	[HideInInspector] public GameObject player;
	public bool potion;
	public bool shieldPotion;
	public bool energyPotion;

	public Image content;
	public float speedLerp;
	public float initialValue;
	public bool shield;
	public bool health;
	public bool energy;

	private float currentValue;
	private float t = 0;
	private float k = 0;

	bool check;
	bool check2;

	void Start()
	{
		player = GameObject.FindWithTag ("Player");
	}

	void Update () 
	{
		if (health) {
			if (!potion) {

				check = false;

				currentValue = Map (player.GetComponent<Player> ().playerHealth, 0, 100, 0, 1);

				if (Math.Abs(currentValue - content.fillAmount) > 0.0000001f) {
					content.fillAmount = Mathf.Lerp (initialValue, currentValue, t);
					t += speedLerp * Time.deltaTime;
				} else {
					t = 0f;
					initialValue = currentValue;
				}
			} else {
				if (!check) {
					t = 0f;
					check = true;
				}

				currentValue = 100f;
				content.fillAmount = Mathf.Lerp (initialValue, 1f, t);
				t += 0.45f * Time.deltaTime;
				player.GetComponent<Player> ().playerHealth = 100f;
			}
			if (content.fillAmount == 1f) {
				player.GetComponent<Player> ().checkIfEpinepherineIsAddedHealth = false;
				potion = false;
			}
		}
		if (shield) {
			if (!shieldPotion) {
				if (check2) 
				{
					k = 0f;
					check2 = false;
					check = false;
				}
				if (player.GetComponent<Player> ().activateShield) {
					content.fillAmount = Mathf.Lerp (1f, 0, k);
					k += speedLerp * Time.deltaTime;

					initialValue = content.fillAmount;
				}
				if (content.fillAmount <= 0) {
					player.GetComponent<Player> ().emptyShieldBar = true;
					player.GetComponent<Player> ().activateShield = false;
				} else
					player.GetComponent<Player> ().emptyShieldBar = false;
			} else {
				if (!check) {
					k = 0f;
					check = true;
					check2 = true;
				}

				content.fillAmount = Mathf.Lerp (initialValue, 1f, k);
				k += 0.45f * Time.deltaTime;
			}
			if (content.fillAmount == 1f) {
				player.GetComponent<Player> ().checkIfPotionIsAddedShield = false;
				shieldPotion = false;
			}
		}
		if (energy) 
		{
			if (energyPotion) {
				if (!check2) {
					k = 0f;
					check2 = true;
				}
					
				currentValue = 1f;

				content.fillAmount = Mathf.Lerp (initialValue, 1f, k);
				k += speedLerp * Time.deltaTime;
			} 
			else {	
				if (!check) {
					currentValue = content.fillAmount - 0.34f;
					check = true;
				}
				if (player.GetComponent<Player> ().activateEnergy && content.fillAmount >= currentValue) {
					content.fillAmount = Mathf.Lerp (initialValue, currentValue, k);
					k += speedLerp * Time.deltaTime;
				}
				if (content.fillAmount <= currentValue) {
					initialValue = content.fillAmount;
					check = false;
					player.GetComponent<Player> ().activateEnergy = false;
					k = 0f;
				}

				if (content.fillAmount == 0)
					initialValue = 0;
			}

			if (content.fillAmount == 1f) {
				energyPotion = false;
				initialValue = 1f;
				check2 = false;

				player.GetComponent<Player> ().checkIfPotionIsAddedEnergy = false;
			}
		}
	}

	private float Map(float value, float inMin, float inMax,float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
