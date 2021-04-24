using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarker : MonoBehaviour
{
	public float Tempo;


	void Update()
	{
		StartCoroutine(LateCall());
	}

	IEnumerator LateCall()
	{
		yield return new WaitForSeconds(Tempo);
		gameObject.SetActive(false);
	}
}
