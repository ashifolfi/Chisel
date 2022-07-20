extends Container

onready var MeshManager = get_node("/root/UI/3dEnv/MeshManager")

func _on_CreateCube_pressed():
	get_node("/root/UI/CubeCreate").popup()

func _on_Select_pressed():
	MeshManager.selected_mesh = null


func _on_Delete_pressed():
	if not(MeshManager.selected_mesh == null):
		MeshManager.delete_mesh(MeshManager.selected_mesh)
