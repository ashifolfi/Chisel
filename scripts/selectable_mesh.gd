extends StaticBody
# GDScript because dynamically loaded CS apparently doesn't exactly work

var MeshManager_CS = load("res://scripts/MeshManager.cs")
var MeshManager = MeshManager_CS.new()

func _process(delta):
	if not(MeshManager.SelectedMesh == self):
		var mat = self.get_parent().get_surface_material(0)
		mat.set_next_pass(null)

func _OnSelected(camera, event, position, normal, shape_idx):
	if event is InputEventMouseButton and event.pressed and event.button_index == 1:
		MeshManager.SelectedMesh = self
		var mat = self.get_parent().get_surface_material(0)
		var shad_mat = ShaderMaterial.new()
		shad_mat.shader = load("res://assets/shaders/selected_mesh.shader")
		mat.set_next_pass(shad_mat)
