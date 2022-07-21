extends WindowDialog
class_name TextureBrowser

# TextureBrowser class:
# Used to browse available textures to use on brushes/overlays/decals
#
# (C) 2022 K. "Ashifolfi" J.

onready var TextureGrid = $HSplitContainer/ScrollContainer/GridContainer
onready var AssetManager = get_node("/root/UI/AssetManager")
onready var TexButton = ButtonGroup.new()

# Setup the control
func _ready():
	self.set_custom_minimum_size(Vector2(730, 500))
	# Don't close on focus loss please
	self.popup_exclusive = true

# Update contents of the texture grid
# TODO: Create other sizes for larger columns
# TODO: There's probably a better way to do this
func update_tex_grid():
	# Clear out all existing children
	for n in TextureGrid.get_children():
		TextureGrid.remove_child(n)
		n.queue_free()
	
	# Go through the entire TextureList and add every texture as an entry
	for n in AssetManager.TextureList.keys():
		# create the vertical split container for the texture and label
		var tex_item = VSplitContainer.new()
		tex_item.set_custom_minimum_size(Vector2(128, 154))
		tex_item.set_collapsed(true)
		tex_item.mouse_filter = Control.MOUSE_FILTER_PASS
		# create the texturerect
		var tex_rec = TextureRect.new()
		tex_rec.expand = true
		tex_rec.set_texture(AssetManager.TextureList[n]["texture"])
		tex_rec.set_custom_minimum_size(Vector2(128, 128))
		tex_item.add_child(tex_rec)
		# create the label for the name
		var tex_name = Label.new()
		tex_name.clip_text = true
		tex_name.text = AssetManager.TextureList[n]["name"]
		tex_item.add_child(tex_name)
		# Now. Define the check button used for selection
		var tex_button = TextureRadio.new()
		tex_button.set_custom_minimum_size(Vector2(128,154))
		tex_button.set_button_group(TexButton)
		# add the tex_item to the button
		tex_button.add_child(tex_item)
		# Add the texture info to the button just for ease
		tex_button.has_texture = AssetManager.TextureList.get(n)
		# Finally, add the button to the main grid
		TextureGrid.add_child(tex_button)

# Change the column count with the scale slider
func _on_HSlider_value_changed(value):
	TextureGrid.columns = value
	update_tex_grid()

# Change the active material
func _on_Accept_pressed():
	print("[DEBUG] Selected: " + TexButton.get_pressed_button().has_texture.get("name"))
	AssetManager.ActiveTexture = TexButton.get_pressed_button().has_texture
	self.visible = false


func _on_Reload_pressed():
	# Load up the texture list with the engine textures by default
	update_tex_grid()
