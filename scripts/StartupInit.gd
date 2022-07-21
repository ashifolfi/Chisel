extends Control

onready var AssetManager = get_node("/root/UI/AssetManager")
onready var FileManager = get_node("/root/UI/FileManager")

# Called when the node enters the scene tree for the first time.
func _ready():
	print("[INF] Initialization Started")
	# Do initialization routine
	print("[INF] Initialization Completed")
