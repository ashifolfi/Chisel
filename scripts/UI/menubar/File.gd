extends MenuButton

onready var FileManager = get_node("/root/UI/FileManager")

func _ready():
	var popup = self.get_popup()
	popup.connect("id_pressed", self, "_on_id_pressed")

func _on_id_pressed(ID):
	# New Map
	if ID == 0:
		get_node("/root/UI/Main/ToolsView/3DView").visible = true
	# New map from template
	elif ID == 1:
		pass
	# Open Map
	elif ID == 2:
		FileManager.open_map()
	# Save Map
	elif ID == 4:
		FileManager.save_map()
