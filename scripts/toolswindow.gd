extends Container

onready var MeshBuilder = get_node("/root/UI/3dEnv/MeshBuilder")

func _process(delta):
	pass


func _on_CreateCube_pressed():
	get_node("/root/UI/CubeCreate").popup()
