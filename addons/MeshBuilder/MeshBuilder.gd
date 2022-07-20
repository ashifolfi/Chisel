extends Spatial
class_name MeshBuilder

onready var MeshManager = get_node("../MeshManager")

# The new cube creation function.
# To show you the power of actually reading documentation I've cut the line count in half!
func createcube(size, position):
	var mesh = MeshInstance.new()
	MeshManager.add_child(mesh)
	var primitive = CubeMesh.new()
	
	# Scale primitive to specified values
	primitive.set_size(size)
	
	# Setup collision shape used to select and delete
	var select_body = StaticBody.new()
	select_body.set_script(load("res://scripts/selectable_mesh.gd"))
	select_body.connect("input_event", select_body, "_on_selected")
	var col_shape = CollisionShape.new()
	col_shape.shape = BoxShape.new()
	col_shape.shape.set_extents(size/2)
	select_body.add_child(col_shape)
	select_body.set_ray_pickable(true)
	mesh.add_child(select_body)

	var material = SpatialMaterial.new()
	material.set_texture(0, load("res://assets/textures/dev256.png"))

	mesh.set_mesh(primitive)
	mesh.set_surface_material(0,material) #sets the material
	
	# Now we need to reposition the mesh in the environment
	mesh.translate(position)
