extends WindowDialog

func _on_Close_pressed():
	self.visible = false

func _on_SourceCode_pressed():
	OS.shell_open("https://github.com/ashifolfi/Chisel")
