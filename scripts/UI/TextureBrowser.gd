extends WindowDialog
class_name TextureBrowser

# TextureBrowser class:
# Used to browse available textures to use on brushes/overlays/decals
#
# (C) 2022 K. "Ashifolfi" J.

onready var TextureGrid = $HSplitContainer/GridContainer

# Texture List used in the grid
onready var TextureList = {}

func _ready():
	self.set_custom_minimum_size(Vector2(730, 500))
	# Don't close on focus loss please
	self.popup_exclusive = true
	print(OS.get_executable_path())
	
	# Load up the texture list with the engine textures by default
	# TODO: Move asset mangement (texture list, entites, etc.) to it's own node class (AssetManager)
	

# Adds a texture item to the TextureGrid
func add_entry(tex_name):
	# Perform a file system check for data in the exe path
	pass

# Change the column count with the scale slider
func _on_HSlider_value_changed(value):
	TextureGrid.columns = value
