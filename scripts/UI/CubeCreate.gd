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
	
	# Grab the size variables
	var hfinal = float($Size/H/LineEdit.get_text())
	var lfinal = float($Size/L/LineEdit.get_text())
	var wfinal = float($Size/W/LineEdit.get_text())
	
	# Call the MeshBuilder to create a cube with the provided information
	MeshBuilder.createcube(Vector3(wfinal, hfinal, lfinal), Vector3(x, y, z))
	
	# finally. dismiss the popup
	self.visible = false
