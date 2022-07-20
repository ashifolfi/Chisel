extends StaticBody

func _process(delta):
	if not(self.get_parent().get_parent().selected_mesh == self):
		var mat = self.get_parent().get_surface_material(0)
		mat.set_next_pass(null)

func _on_selected(camera, event, position, normal, shape_idx):
	if event is InputEventMouseButton and event.pressed and event.button_index == 1:
		self.get_parent().get_parent().selected_mesh = self
		var mat = self.get_parent().get_surface_material(0)
		var shad_mat = ShaderMaterial.new()
		shad_mat.shader = load("res://assets/shaders/selected_mesh.shader")
		mat.set_next_pass(shad_mat)
