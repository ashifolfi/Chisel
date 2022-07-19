tool
extends Node

func createcubetest(v3a, v2a, ia):
	var mesh = MeshInstance.new()
	add_child(mesh)
	var arr_mesh = ArrayMesh.new()
	var arr = []
	arr.resize(Mesh.ARRAY_MAX)

	var material = SpatialMaterial.new()
	material.flags_unshaded = true
	material.set_texture(0, load("res://icon.png"))

	var vert_data = v3a
	var uv_data = v2a
	var index_data = ia

	arr[Mesh.ARRAY_VERTEX]=vert_data
	if not(uv_data == null):
		arr[Mesh.ARRAY_TEX_UV]=uv_data
	if not(index_data == null):
		arr[Mesh.ARRAY_INDEX]=index_data

	arr_mesh.add_surface_from_arrays(Mesh.PRIMITIVE_TRIANGLES,arr) #this adds a surface to the array mesh based off of array data

	mesh.set_mesh(arr_mesh)
	
	if not(uv_data == null):
		mesh.set_surface_material(0,material) #sets the material for the 1st surface

