extends Control

onready var container = get_node("TabContainer")
onready var current_tab = null

func _ready():
	var popup = get_node("MenuButton").get_popup()
	popup.connect("id_pressed", self, "_on_id_pressed")

func _on_id_pressed(ID):
	if ID == 0:
		var new_map = FileManager
	elif ID == 1:
		pass


func _on_TabContainer_tab_changed(tab):
	current_tab = tab
