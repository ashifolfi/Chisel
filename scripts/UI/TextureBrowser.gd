extends WindowDialog
class_name TextureBrowser

# TextureBrowser class:
# Used to browse available textures to use on brushes/overlays/decals
#
# (C) 2022 K. "Ashifolfi" J.

onready var TextureGrid = $HSplitContainer/ScrollContainer/GridContainer

# Texture List used in the grid
onready var TextureList = {}

# Setup the control
func _ready():
	self.set_custom_minimum_size(Vector2(730, 500))
	# Don't close on focus loss please
	self.popup_exclusive = true
	print(OS.get_executable_path())
	
	# Load up the texture list with the engine textures by default
	# TODO: Move asset mangement (texture list, entites, etc.) to it's own node class (AssetManager)
	add_entry("floor")
	add_entry("hint")
	add_entry("nodraw")
	add_entry("skip")
	add_entry("trigger")
	add_entry("wall")

# Adds a texture item to the TextureGrid
# TODO: Move texture loading to entirely external using source engine structure
# TODO: Support vtf files
func add_entry(tex_name):
	# grab the current count
	var current_count = TextureList.size()
	
	# make sure the texture actually exists
	if not(load("res://assets/textures/" + tex_name + ".png")):
		print("[ERR] Texture does not exist!")
	else: # it does. add it to the list
		TextureList[current_count+1] = {
			"texture": load("res://assets/textures/" + tex_name + ".png"),
			"name": "textures/" + tex_name
		}
	self.update_tex_grid()

# Update contents of the texture grid
func update_tex_grid():
	# Clear out all existing children
	for n in TextureGrid.get_children():
		TextureGrid.remove_child(n)
		n.queue_free()
	
	# Go through the entire TextureList and add every texture as an entry
	for n in TextureList.keys():
		# create the vertical split container for the texture and label
		var tex_item = VSplitContainer.new()
		tex_item.set_custom_minimum_size(Vector2(128, 154))
		tex_item.set_collapsed(true)
		# create the texturerect
		var tex_rec = TextureRect.new()
		tex_rec.expand = true
		tex_rec.set_texture(TextureList[n]["texture"])
		tex_item.add_child(tex_rec)
		# create the label for the name
		var tex_name = Label.new()
		tex_name.clip_text = true
		tex_name.text = TextureList[n]["name"]
		tex_item.add_child(tex_name)
		# add the texture item to the main grid
		TextureGrid.add_child(tex_item)

# Change the column count with the scale slider
func _on_HSlider_value_changed(value):
	TextureGrid.columns = value

# Change the active material
func _on_Accept_pressed():
	pass # Replace with function body.
