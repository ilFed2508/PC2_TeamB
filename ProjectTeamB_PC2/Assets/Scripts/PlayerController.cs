using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public PlayerShooting playerShooting;
	public PlayerMovement playerMovement;
	public PlayerLifeSystem playerLife;

	//temporary variable
	public Transform WeaponSlot;
	public Text UIPickup;
	public GameObject Melee;
	public GameObject Player;

    //image "E" pick up - joe
    public GameObject PickUp;

	public Transform WeaponSlotAkimbo;

	void Start()
	{
		Time.timeScale = 1f;

		playerShooting = GetComponent<PlayerShooting>();
		playerMovement = GetComponent<PlayerMovement>();
		playerLife = GetComponent<PlayerLifeSystem>();
	}

	void Update()
	{
		playerLife.LifeTimer();
	}
}
