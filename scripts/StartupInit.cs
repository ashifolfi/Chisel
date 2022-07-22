/*
	StartupInit
	
	Startup Initialization for Chisel is done within this script
	(C) 2022 by K. "Ashifolfi" J.
*/

using Godot;
using System;

public class StartupInit : Control
{
	// Defining the variables we use to grab our important nodes
	private Node AssetManager;
	private Node FileManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("[INF] Initialization Begin");
		
		GD.Print("[INF] Tying AssetManager+FileManager to Variables");
		AssetManager = GetNode<Node>("/root/UI/AssetManager");
		FileManager = GetNode<Node>("/root/UI/FileManager");
		GD.Print("[INF] Done!");
		
		GD.Print("[INF] INitialization Complete");
	}
}
