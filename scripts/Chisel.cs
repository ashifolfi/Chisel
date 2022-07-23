/*
	Chisel namespace

	Contains Chisel global variables and functions

	(C) 2022 by K. "Ashifolfi" J.
*/
using Godot;
using System;

namespace Chisel
{
	// Global variables
	public class Globals
	{
		public static Boolean In3DView = true;
		public static Boolean Enable2DView = false;
		public static Boolean CameraOn = false;
		public static String ToolsMode = "Nothing";
	}

	public class Unit
	{
		// Conversion reference
		// 128x128x128 Source cube brush = 1x1x1 Godot cube mesh

		// Godot to Source map unit conversion
		public static Vector3 ToSourceUnit(Vector3 Vec3)
		{
			Vec3.x *= 128;
			Vec3.y *= 128;
			Vec3.z *= 128;
			return Vec3;
		}

		public static Vector3 ToGodotUnit(Vector3 Vec3)
		{
			Vec3.x /= 128;
			Vec3.y /= 128;
			Vec3.z /= 128;
			return Vec3;
		}
	}
	
	public class Utilities
	{
		// Because C# doesn't have one by default
		public static void Assert(bool cond, string msg)
		{
			if (cond) return;

			GD.PrintErr(msg);
			throw new ApplicationException($"[ASSERTFAIL] {msg}");
		}

		// Used to add C# scripts to nodes and also keep their reference
		public static Godot.Object SetScriptSafe(Godot.Object obj, String script)
		{
			ulong objId = obj.GetInstanceId();
			// Replaces old C# instance with a new one. Old C# instance is disposed.
			obj.SetScript(ResourceLoader.Load(script));
			// Get the new C# instance
			obj = GD.InstanceFromId(objId);
			return obj;
		}
	}

	public class Math
	{
		public static float Clamp(float val, float min, float max)
		{
			return min > val ? min : max < val ? max : val;
		}

		public static float Deg2Rad(float Angle)
		{
			return (3.141F / 180) * Angle;
		}
	}

}
