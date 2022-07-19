extends Panel

# Used to enable 3dview controls when you're actually over the 3dview
func _on_ViewportContainer_mouse_entered():
	globals.in_3dview = true

func _on_ViewportContainer_mouse_exited():
	globals.in_3dview = false
