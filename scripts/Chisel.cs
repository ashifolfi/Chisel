/*
	Chisel namespace

	Contains Chisel global variables and functions

	(C) 2022 by K. "Ashifolfi" J.
*/
using Godot;
using System;
using Chisel.UI;
using System.Text.Json;
using VTFLibWrapper;

namespace Chisel
{
	// Global variables
	public static class Globals
	{
		public static Boolean In3DView = true;
		public static Boolean Enable2DView = false;
		public static Boolean CameraOn = false;
		public static String ToolsMode = "Nothing";
		public static EditorMain RootPanel;
		public static String RootPath;
		public static String ExeDir;
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

	public static class Config
	{
		public static void LoadConfig()
		{
			
		}
	}

	public static class FS
	{
		
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

	public class Converts
	{
		public static Image.Format FromVTFFormat(VTFImageFormat Format)
		{
			switch (Format)
			{
				case VTFImageFormat.IMAGE_FORMAT_DXT1:
					return Image.Format.Dxt1;
				case VTFImageFormat.IMAGE_FORMAT_DXT3:
					return Image.Format.Dxt3;
				case VTFImageFormat.IMAGE_FORMAT_DXT5:
					return Image.Format.Dxt5;
				case VTFImageFormat.IMAGE_FORMAT_RGBA32323232F:
					return Image.Format.Rgbaf;
			}
			// If all else assume Rgb8 (Horrible idea but what else are we going to do?)
			return Image.Format.Rgb8;
		}
	}
}
