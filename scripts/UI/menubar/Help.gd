extends MenuButton

func _ready():
	var popup = self.get_popup()
	popup.connect("id_pressed", self, "_on_id_pressed")

func _on_id_pressed(ID):
	if ID == 0:
		get_node("/root/UI/About").popup()
