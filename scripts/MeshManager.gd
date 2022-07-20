extends Spatial
class_name MeshManager

onready var selected_mesh = null
onready var mesh_list = {}

func delete_mesh(body):
	# Check to make sure we aren't about to destroy something we shouldn't
	assert(body.get_class() == "StaticBody", "[FATAL] delete_mesh called on non StaticBody object!")
	
	if is_instance_valid(body.get_parent()):
		body.get_parent().queue_free()
	else:
		print("[WARN] Attempted to delete_mesh non-valid parent! File may be corrupt!")
