extends MenuButton

func _ready():
	var popup = self.get_popup()
	popup.connect("id_pressed", self, "_on_id_pressed")

func _on_id_pressed(ID):
	if ID == 0:
		var threeDview = get_node("/root/UI/Main/ToolsView/3DView")
		var twoDtop = get_node("/root/UI/Main/ToolsView/2DTop")
		var twoDside = get_node("/root/UI/Main/ToolsView/2DSide")
		var twoDfront = get_node("/root/UI/Main/ToolsView/2DFront")
		if globals.enable_2dview == false:
			twoDtop.visible = true
			twoDside.visible = true
			twoDfront.visible = true
			threeDview.rect_size = Vector2(624, 359)
			globals.enable_2dview = true
		else:
			twoDtop.visible = false
			twoDside.visible = false
			twoDfront.visible = false
			threeDview.rect_size = Vector2(1249, 709)
			globals.enable_2dview = false
