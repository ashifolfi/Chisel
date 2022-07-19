extends Container

onready var MeshBuilder = get_node("/root/UI/Main/ToolsView/3DView/ViewportContainer/Viewport/Spatial/MeshBuilder")

func _process(delta):
	pass


func _on_CreateCube_pressed():
	var varray = PoolVector3Array()
	varray.append(Vector3(-1, -1, 1))
	varray.append(Vector3(-1, 1, 1))
	varray.append(Vector3(1, 1, 1))
	varray.append(Vector3(1, -1, 1))
	# Side 2
	varray.append(Vector3(1, 1, -1))
	varray.append(Vector3(1, -1, -1))
	varray.append(Vector3(1, -1, 1))
	varray.append(Vector3(1, 1, 1))
	# Side 3
	varray.append(Vector3(1, -1, -1))
	varray.append(Vector3(1, 1, -1))
	varray.append(Vector3(-1, 1, -1))
	varray.append(Vector3(-1, -1, -1))
	# Side 4
	varray.append(Vector3(-1, -1, -1))
	varray.append(Vector3(-1, 1, -1))
	varray.append(Vector3(-1, 1, 1))
	varray.append(Vector3(-1, -1, 1))
	# Lid 1
	varray.append(Vector3(1, 1, 1))
	varray.append(Vector3(-1, 1, 1))
	varray.append(Vector3(-1, 1, -1))
	varray.append(Vector3(1, 1, -1))
	# Lid 2
	varray.append(Vector3(1, -1, -1))
	varray.append(Vector3(-1, -1, -1))
	varray.append(Vector3(-1, -1, 1))
	varray.append(Vector3(1, -1, 1))

	var uvarray = PoolVector2Array()
	for i in 6:
		uvarray.append(Vector2(0, 0))
		uvarray.append(Vector2(0, 1))
		uvarray.append(Vector2(1, 1))
		uvarray.append(Vector2(1, 0))
	
	var iarray = PoolIntArray()
	var offset = 0
	for i in 6:
		iarray.append(offset)
		iarray.append(offset+1)
		iarray.append(offset+2)
		iarray.append(offset+2)
		iarray.append(offset+3)
		iarray.append(offset)
		offset = offset + 4
	
	MeshBuilder.createcubetest(varray, uvarray, iarray)
