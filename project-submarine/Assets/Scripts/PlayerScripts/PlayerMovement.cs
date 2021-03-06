﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	private float speedF = 0f; //speed forward.
	private float speedB = 0f; //speed Back.
	private float speedU = 0f; //speed Up.
	private float speedD = 0f; //speed Down.
	private float rotationR = 0f; //speed rotatie Rechts.
	private float rotationL = 0f; //speed rotatie Links.
	private float max = 20f; //max speed forward.
	private float maxB = 10f; //max speed back.
	private float maxR = 40f; //max speed rotatie.

	private float accel = .2f; //acceleratie Algemeen.
	private float accelR = .5f; //acceleratie rotatie.
	private float accelB = .2f; //acceleratie back.

	private int RotateF;
	private int RotateB;
	private Quaternion original;
	private Rigidbody rigidbody;

	[SerializeField]
	private Canvas EToShop;

	[SerializeField]
	private GameObject particlesEngine1;
	private ParticleSystem particleEmissionEngine1;

	[SerializeField]
	private GameObject particlesEngine2;
	private ParticleSystem particleEmissionEngine2;
	[SerializeField]
	private GameObject particlesEngine3;
	private ParticleSystem particleEmissionEngine3;

	[SerializeField]
	private GameObject particlesEngine4;
	private ParticleSystem particleEmissionEngine4;
	[SerializeField]
	private GameObject particlesEngine5;
	private ParticleSystem particleEmissionEngine5;

	[SerializeField]
	private GameObject particlesEngine6;
	private ParticleSystem particleEmissionEngine6;

	[SerializeField]
	private GameObject particlesEngine7;
	private ParticleSystem particleEmissionEngine7;

	void Start()
	{
		EToShop = EToShop.GetComponent<Canvas>();
		EToShop.enabled = false;
		rigidbody = GetComponent<Rigidbody> ();
		particleEmissionEngine1 = particlesEngine1.GetComponent<ParticleSystem> ();
		particleEmissionEngine2 = particlesEngine2.GetComponent<ParticleSystem> ();
		particleEmissionEngine3 = particlesEngine3.GetComponent<ParticleSystem> ();
		particleEmissionEngine4 = particlesEngine4.GetComponent<ParticleSystem> ();
		particleEmissionEngine5 = particlesEngine5.GetComponent<ParticleSystem> ();
		particleEmissionEngine6 = particlesEngine6.GetComponent<ParticleSystem> ();
		particleEmissionEngine7 = particlesEngine7.GetComponent<ParticleSystem> ();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			//Debug.Log (maxR);
			if(particlesEngine1.activeInHierarchy)
			{
				particleEmissionEngine7.Play ();
				particleEmissionEngine1.Play();
			}
			if(particlesEngine2.activeInHierarchy)
			{
				particleEmissionEngine2.Play();
				particleEmissionEngine3.Play();
			}
			if(particlesEngine4.activeInHierarchy)
			{
				particleEmissionEngine4.Play();
				particleEmissionEngine5.Play();
			}

			if(particlesEngine6.activeInHierarchy)
			{
				particleEmissionEngine6.Play();
			}
		}
		else
		{
			particleEmissionEngine1.Stop();
			particleEmissionEngine2.Stop();
			particleEmissionEngine3.Stop();
			particleEmissionEngine4.Stop();
			particleEmissionEngine5.Stop();
			particleEmissionEngine6.Stop();
			particleEmissionEngine7.Stop();
		}

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			speedF += accel;

			if (speedF > max)
			{
				speedF = max;
			}
		}
		else
		{
			speedF -= accel;

			if (speedF < 0)
			{
				speedF = 0;
			}
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			rotationL += accelR;

			if (rotationL > maxR)
			{
				rotationL = maxR;
			}
		}

		else
		{
			rotationL -= accelR;

			if (rotationL < 0)
			{
				rotationL = 0;
			}
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			rotationR += accelR;

			if (rotationR > maxR)
			{
				rotationR = maxR;
			}
		}
		else
		{
			rotationR -= accelR;

			if (rotationR < 0)
			{
				rotationR = 0;
			}
		}


		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))// achteruit
		{
			speedB += accelB;

			if (speedB > maxB)
			{
				speedB = maxB;
			}
		}
		else
		{
			speedB -= accelB;

			if (speedB < 0)
			{
				speedB = 0;
			}
		}

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			speedD += accel;

			if (speedD > maxB)
			{
				speedD = maxB;

			}
		}
		else
		{
			speedD -= accel;

			if (speedD < 0)
			{
				speedD = 0;
			}
		}

		if (Input.GetKey(KeyCode.Space))
		{
			speedU += accel;

			if (speedU > maxB)
			{
				speedU = maxB;
			}
		}
		else
		{
			speedU -= accel;

			if (speedU < 0)
			{
				speedU = 0;
			}
		}
	}

	void FixedUpdate()
	{
		rigidbody.MovePosition (rigidbody.position + (transform.TransformDirection( Vector3.forward) * speedF * Time.fixedDeltaTime));
		rigidbody.MovePosition (rigidbody.position + (transform.TransformDirection( Vector3.back) * speedB * Time.fixedDeltaTime));
		rigidbody.MovePosition (rigidbody.position + (transform.TransformDirection( Vector3.down) * speedD * Time.fixedDeltaTime));
		rigidbody.MovePosition (rigidbody.position + (transform.TransformDirection( Vector3.up) * speedU * Time.fixedDeltaTime));

		rigidbody.MoveRotation (rigidbody.rotation * Quaternion.Euler (Vector3.down * rotationL * Time.fixedDeltaTime));
		rigidbody.MoveRotation (rigidbody.rotation * Quaternion.Euler (Vector3.up * rotationR * Time.fixedDeltaTime));
	}
	public void UpgradeEngine ()
	{
		if(particlesEngine2.activeInHierarchy)
		{
			maxR = 55f;
			accelR = .8f;
			maxB = 20f;
			max = 25;
		}
		if(particlesEngine4.activeInHierarchy)
		{
			max = 40f;
			accel = .3f;
		}

		if(particlesEngine6.activeInHierarchy)
		{
			maxR = 65f;
			accelR = 1f;
			maxB = 20f;
			max = 50f;
			accel = .5f;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Shop"))
		{
			EToShop.enabled = true;
			UpgradeShop.CanShop = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Shop"))
		{
			EToShop.enabled = false;
			UpgradeShop.CanShop = false;
		}
	}
}