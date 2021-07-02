using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	private float shake;
	Vector3 originalPos;

	void Awake()
	{
		this.enabled = false;
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		shake = shakeDuration;
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shake > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			camTransform.localPosition = originalPos;
			this.enabled = false;
		}
	}
}