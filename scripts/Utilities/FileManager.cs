/*
	FileManager Class

	Used to handle opening VMF files, Saving VMF files
	and anything else related to Filesystem actions

	(C) 2022 by K. "Ashifolfi" J.
*/
using Godot;
using System;
using System.Collections.Generic;
using Chisel;

public class FileManager : Node
{
	FileDialog FileDialog = new FileDialog();
	private AssetManager AssetManager;

	public override void _Ready()
	{
		AssetManager = GetNode<AssetManager>(Globals.RootPath + "/Editor/AssetManager");
		
		AddChild(FileDialog);
		FileDialog.PopupExclusive = true;
		FileDialog.RectSize = new Vector2(839, 487);
		FileDialog.Resizable = true;
		FileDialog.Access = FileDialog.AccessEnum.Filesystem;
	}

	public void SetupMapNode()
	{
		ViewportContainer Root = new ViewportContainer();
		// Add the rest of the viewport requirements
		Root.AddChild(new Viewport());

		// Setup camera
	}

	public List<String> DirContents(String Path, Boolean Folders = false)
	{
		List<String> FileList = new List<string>();
		List<String> FolderList = new List<string>();
		
		Directory Dir = new Directory();
		if (Dir.Open(Path) == Error.Ok)
		{
			Dir.ListDirBegin();
			String FileName = Dir.GetNext();
			while (FileName != "")
			{
				if (Dir.CurrentIsDir())
				{
					if (FileName != "." && FileName != "..")
					{
						GD.Print("[FS] Found Directory: " + FileName);
						FolderList.Add(FileName);
					}
				}
				else
				{
					FileList.Add(FileName);
				}

				FileName = Dir.GetNext();
			}
		}
		else
		{
			GD.Print("[FS][ERR] Failed to access path");
		}

		if (Folders == true)
			return FolderList;
		return FileList;
	}
	
	// Routine for texture loading
	public void LoadGameTextures(String GameDir)
	{
		String FullPath = Globals.ExeDir + "/" + GameDir;

		// Search the materials subdirectory for anything containing .vtf at the root
		List<String> FileList = DirContents(FullPath + "/materials/");
		foreach (String File in FileList.ToArray())
		{
			AssetManager.LoadTexture(File, GameDir);
		}
		// Go through every subdirectory
		List<String> FolderList = DirContents(FullPath + "/materials/", true);
		foreach (String Folder in FolderList.ToArray())
		{
			FileList = DirContents(FullPath + "/materials/" + Folder + "/");
			foreach (String File in FileList.ToArray())
			{
				AssetManager.LoadTexture(Folder + "/" + File, GameDir);
			}
		}
	}

	// VMF Opening
	public void OpenMap()
	{
		// Ready dialog for opening
		FileDialog.WindowTitle = "Open Map";
		String[] Filter = {"*.vmf ; Valve Map File"};
		FileDialog.Filters = Filter;
		FileDialog.Mode = FileDialog.ModeEnum.OpenFile;

		// Connect to our method
		FileDialog.Connect("file_selected", GetNode("."), "ParseMapVmf");
		FileDialog.Popup_();
	}

	public void ParseMapVmf(String Path)
	{
		FileDialog.Disconnect("file_selected", GetNode("."), "ParseMapVmf");
		GD.Print(Path);
	}

	// VMF Saving
	public void SaveMap()
	{
		// Ready dialog for saving
		FileDialog.WindowTitle = "Save Map";
		String[] Filter = {"*.vmf ; Valve Map File"};
		FileDialog.Filters = Filter;
		FileDialog.Mode = FileDialog.ModeEnum.SaveFile;

		// Connect to our method
		FileDialog.Connect("file_selected", GetNode("."), "SaveMapVmf");
		FileDialog.Popup_();
	}

	public void SaveMapVmf(String Path)
	{
		FileDialog.Disconnect("file_selected", GetNode("."), "SaveMapVmf");
		GD.Print(Path);
	}
}
