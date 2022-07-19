extends WindowDialog

# This little variable is pretty important. We call the mesh buidler using this variable
# the actual path to the node is very long so having this makes it much faster
onready var MeshBuilder = get_node("/root/UI/3dEnv/MeshBuilder")

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Actually create the cube with the settings the user has chosen
func _on_Create_pressed():
	# First we need to grab the values from the input fields
	# and this is why we have the script on the main window instead of the button
	var x = $Pos/X/LineEdit.get_text()
	var y = $Pos/Y/LineEdit.get_text()
	var z = $Pos/Z/LineEdit.get_text()
	
	# And now we define the vertices for the cube
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

	# Setup the UV array using
	var uvarray = PoolVector2Array()
	for i in 6:
		uvarray.append(Vector2(0, 0))
		uvarray.append(Vector2(0, 1))
		uvarray.append(Vector2(1, 1))
		uvarray.append(Vector2(1, 0))
	
	# and of course our index array
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
	
	# Call the MeshBuilder to create a cube with the provided information
	MeshBuilder.createcube(varray, uvarray, iarray, x, y, z)
