extends Spatial

onready var posmark1 = $cube1
onready var posmark2 = $cube2
onready var cube1_posed = false

func _on_StaticBody_input_event(camera, event, position, normal, shape_idx):
	if event is InputEventMouseButton and event.pressed and event.button_index == 1 and cube1_posed != true:
		posmark1.set_translation(Vector3(stepify(position.x, 0.1), stepify(position.y, 0.1), stepify(position.z, 0.1)))
		cube1_posed = true
	elif event is InputEventMouseButton and event.pressed and event.button_index == 1 and cube1_posed == true:
		cube1_posed = false
		create_mesh_here()
	if event is InputEventMouseMotion and cube1_posed == true:
			posmark2.set_translation(Vector3(stepify(position.x, 0.1), stepify(position.y, 0.1), stepify(position.z, 0.1)))

func create_mesh_here():
	var mesh = MeshInstance.new()
	var cube = CubeMesh.new()
	var x_final
	var y_final
	var z_final
	var trans_final = Vector3()
	
	if posmark1.get_translation().x > posmark2.get_translation().x:
		x_final = posmark1.get_translation().x - posmark2.get_translation().x
		trans_final.x = posmark2.get_translation().x
	else:
		x_final = posmark2.get_translation().x - posmark1.get_translation().x
		trans_final.x = posmark1.get_translation().x
	
	if posmark1.get_translation().y > posmark2.get_translation().y:
		y_final = posmark1.get_translation().y - posmark2.get_translation().y
		trans_final.y = posmark2.get_translation().y
	else:
		y_final = posmark2.get_translation().y - posmark1.get_translation().y
		trans_final.y = posmark1.get_translation().y
	
	if posmark1.get_translation().z > posmark2.get_translation().z:
		z_final = posmark1.get_translation().z - posmark2.get_translation().z
		trans_final.z = posmark2.get_translation().z
	else:
		z_final = posmark2.get_translation().z - posmark1.get_translation().z
		trans_final.z = posmark1.get_translation().z
	
	
	
	cube.set_size(Vector3(x_final, 2, z_final))
	mesh.translate(trans_final + (Vector3(x_final, y_final, z_final) / 2))
	
	mesh.set_mesh(cube)
	add_child(mesh)
