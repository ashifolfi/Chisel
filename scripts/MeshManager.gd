extends Spatial
class_name MeshManager

onready var selected_mesh = null
onready var mesh_list = {}

func delete_mesh(body):
	# Check to make sure we aren't about to destroy something we shouldn't
	assert(body.get_class() == "StaticBody", "[FATAL] delete_mesh called on non StaticBody object!")
	
	if is_instance_valid(body.get_parent()):
		body.get_parent().queue_free()
		self.selected_mesh = null
	else:
		print("[WARN] Attempted to delete_mesh non-valid parent! File may be corrupt!")

# Godot to Source map unit conversion
# 1x1x1 Godot cube = 128MUx128MUx128MU Source cube
func _3dvec_tosource(vector3):
	vector3.x = vector3.x * 128
	vector3.y = vector3.y * 128
	vector3.z = vector3.z * 128
	return vector3

# Source to Godot map unit conversion
# see _3dvec_tosource for reference
func _3dvec_togodot(vector3):
	vector3.x = vector3.x / 128
	vector3.y = vector3.y / 128
	vector3.z = vector3.z / 128
	return vector3
