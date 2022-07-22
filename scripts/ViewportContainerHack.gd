# fucking bullshit missing variables, what the hell Godot devs.
extends ViewportContainer

#var Globals_CS = load("res://scripts/Chisel.cs")
#var Chisel = Globals_CS.new()

func _input( event ):
	#if Chisel.Globals.In3DView == true:
		if event is InputEventMouse:
			var mouseEvent = event.duplicate()
			mouseEvent.position = get_global_transform().xform_inv(event.global_position)
			$Viewport.unhandled_input(mouseEvent)
		else:
			$Viewport.unhandled_input(event)	
