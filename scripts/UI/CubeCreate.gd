extends WindowDialog

# Primitive creation dialog
## (C) 2022 K. "Ashifolfi" J.

# This little variable is pretty important. We call the mesh buidler using this variable
# the actual path to the node is very long so having this makes it much faster
onready var MeshBuilder = get_node("/root/UI/3dEnv/MeshBuilder")
onready var AssetManager = get_node("/root/UI/AssetManager")
onready var TextureBrowser = get_node("/root/UI/TextureBrowser")

# Called when the node enters the scene tree for the first time.
func _ready():
	pass

func _process(delta):
	var teximg = $Texture/TextureRect
	var texname = $Texture/Label
	if AssetManager.ActiveTexture.size() > 0:
		if AssetManager.ActiveTexture.get("name"):
			texname.text = AssetManager.ActiveTexture.get("name")
			teximg.set_texture(AssetManager.ActiveTexture.get("texture"))
		else:
			print("[ERR] ActiveTexture doesn't contain texture info! Wiping variable")
			AssetManager.ActiveTexture = {}
	pass

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
	
	var texture = $Texture/TextureRect.texture
	
	# Call the MeshBuilder to create a cube with the provided information
	MeshBuilder.createcube(Vector3(wfinal, hfinal, lfinal), Vector3(x, y, z), texture)
	
	# finally. dismiss the popup
	self.visible = false

# Open the texture browser and refresh the texture data
func _on_Browse_pressed():
	TextureBrowser.popup()
	TextureBrowser.update_tex_grid()
