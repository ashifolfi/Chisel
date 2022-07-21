extends Node
class_name AssetManager

# AssetManager
#
# Class used to handle the storage of every model, texture, sprite, material that gets loaded
# when editing a map

onready var TextureList = {}
onready var ActiveTexture = {}

# Called when the node enters the scene tree for the first time.
func _ready():
	load_texture("floor", "")
	load_texture("hint", "")
	load_texture("nodraw", "")
	load_texture("skip", "")
	load_texture("trigger", "")
	load_texture("wall", "")
	ActiveTexture = TextureList.get("floor")

# Add item to the texture list
# TODO: Move texture loading to entirely external using source engine structure
# TODO: Support vtf files
func load_texture(tex_name, game_dir):
	# grab the current count
	var current_count = TextureList.size()
	
	# make sure the texture actually exists
	if not("res://assets/textures/" + tex_name + ".png".get_file()):
		print("[ERR] Texture does not exist!")
	elif TextureList.get(tex_name): # It does. Check the list for it first.
		print("[INF] " + tex_name + " is already loaded - skipping")
	else: # It's not in the list. Let's add it!
		TextureList[tex_name] = {
			"texture": load("res://assets/textures/" + tex_name + ".png"),
			"name": "textures/" + tex_name
		}
