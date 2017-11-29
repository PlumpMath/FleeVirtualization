using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControl : MonoBehaviour
{
	private SliderJoint2D slider;
	private JointMotor2D upMotor;
	private JointMotor2D downMotor;
	[SerializeField] private float liftSpeed = 2;

	private void Start()
	{
		slider = GetComponent<SliderJoint2D>();
		upMotor = new JointMotor2D()
		{
			maxMotorTorque = 10000,
			motorSpeed = liftSpeed
		};
		downMotor = new JointMotor2D()
		{
			maxMotorTorque = 10000,
			motorSpeed = -liftSpeed
		};
	}

	private void Update()
	{
		//print(slider.limitState);
		if (slider.limitState == JointLimitState2D.UpperLimit)
		{
			slider.motor = downMotor;
		}
		if (slider.limitState == JointLimitState2D.LowerLimit)
		{
			slider.motor = upMotor;
		}
	}
}
