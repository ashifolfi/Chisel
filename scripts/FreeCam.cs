/*
	3D Camera System

	A GDScript free fly camera addon rewritten in C#

	C# code (C) 2022 by K. "Ashifolfi" J.
	Original Addon created by aloivmada
*/

using Godot;
using Chisel;
using static Chisel.Math;
using System;

public class FreeCam : Camera
{
	[Export(PropertyHint.Range, "0.0,0,1")]
	float Sensitivity = 1.00F;

	// Mouse state
	private Vector2 _MousePosition = new Vector2(0.0F, 0.0F);
	private float _TotalPitch = 0.0F;

	// Movement state
	Vector3 _Direction = new Vector3(0.0F, 0.0F, 0.0F);
	Vector3 _Velocity = new Vector3(0.0F, 0.0F, 0.0F);
	int _Acceleration = 140;
	int  _Deceleration = -10;
	float _VelMultiplier = 4;

	// Keyboard state
	private Boolean _W = false;
	private Boolean _S = false;
	private Boolean _A = false;
	private Boolean _D = false;
	private Boolean _Q = false;
	private Boolean _E = false;

	public override void _Input(InputEvent @event)
	{
		// Check to see if we're in 3DView first
		if (Globals.In3DView == true)
		{
			// Reveives mouse motion
			if (@event is InputEventMouseMotion)
			{
				_MousePosition = (Vector2) @event.Get("relative");
			}

			// Receives mouse button input
			if (@event is InputEventMouseButton)
			{
				switch ((ButtonList)@event.Get("button_index"))
				{
					case ButtonList.Right: // Only Allows rotation if right click held
						Boolean PressedState = (Boolean) @event.Get("pressed");
						if (PressedState)
						{
							Input.SetMouseMode(Input.MouseMode.Captured);
							Globals.CameraOn = true;
						}
						else
						{
							Input.SetMouseMode(Input.MouseMode.Visible);
							Globals.CameraOn = false;
						}
						break;
					case ButtonList.WheelUp: // Increases Max Velocity (TODO)
						_VelMultiplier = Clamp(_VelMultiplier * 1.1F, 0.2F, 20F);
						break;
					case ButtonList.WheelDown: // Decreases Max Velocity (TODO)
						_VelMultiplier = Clamp(_VelMultiplier / 1.1F, 0.2F, 20F);
						break;
				}
			}

			// Receives key input
			if (@event is InputEventKey)
			{
				Boolean PressedState = (Boolean) @event.Get("pressed");
				switch((KeyList)@event.Get("scancode"))
				{
					case KeyList.W:
						_W = PressedState;
						break;
					case KeyList.S:
						_S = PressedState;
						break;
					case KeyList.A:
						_A = PressedState;
						break;
					case KeyList.D:
						_D = PressedState;
						break;
					case KeyList.Q:
						_Q = PressedState;
						break;
					case KeyList.E:
						_E = PressedState;
						break;
				}
			}
		}
	}

	public override void _Process(float delta)
	{
		base._Process(delta);
		_UpdateMouselook();
		_UpdateMovement(delta);
	}

	public void _UpdateMovement(float delta)
	{
		if (Globals.CameraOn == true)
		{
			// Computes desired direction from key states
			Vector3 _Direction = new Vector3((float)Convert.ToInt32(_D) - (float)Convert.ToInt32(_A),
											(float)Convert.ToInt32(_E) - (float)Convert.ToInt32(_Q),
											(float)Convert.ToInt32(_S) - (float)Convert.ToInt32(_W));
			/* Computes the change in velocity due to desired direction and "drag"
			 The "drag" is a constant acceleration on the camera to bring it's velocity to 0 */
			Vector3 Offset = _Direction.Normalized() * _Acceleration * _VelMultiplier * delta
							+ _Velocity.Normalized() * _Deceleration * _VelMultiplier * delta;
			
			// Checks if we should bother translating the camera
			if ((_Direction == Vector3.Zero) 
			&& (Offset.LengthSquared() > _Velocity.LengthSquared()))
			{
				// Sets the velocity to 0 to prevent jittering due to imperfect deceleration
				_Velocity = Vector3.Zero;
			}
			else
			{
				// Clamps the speed to stay within maximum value (_vel_multiplier)
				_Velocity.x = Clamp(_Velocity.x + Offset.x, -_VelMultiplier, _VelMultiplier);
				_Velocity.y = Clamp(_Velocity.y + Offset.y, -_VelMultiplier, _VelMultiplier);
				_Velocity.z = Clamp(_Velocity.z + Offset.z, -_VelMultiplier, _VelMultiplier);

				Translate(_Velocity * delta);
			}
		}
	}

	public void _UpdateMouselook()
	{
		// Only rotates mouse if the mouse is captured
		if (Input.GetMouseMode() == Input.MouseMode.Captured)
		{
			_MousePosition *= Sensitivity;
			float Yaw = _MousePosition.x;
			float Pitch = _MousePosition.y;
			_MousePosition = new Vector2(0,0);

			// Prevents looking up/down too far
			Pitch = Clamp(Pitch, -90 - _TotalPitch, 90 - _TotalPitch);
			_TotalPitch += Pitch;

			RotateY(Deg2Rad(-Yaw));
			RotateObjectLocal(new Vector3(1,0,0), Deg2Rad(-Pitch));
		}
	}
}
