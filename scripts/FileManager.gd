extends Node
class_name FileManager

var file_dialog

func _ready():
	# Setup file dialog
	file_dialog = FileDialog.new()
	self.add_child(file_dialog)
	file_dialog.popup_exclusive = true
	file_dialog.set_size(Vector2(839, 487))
	file_dialog.resizable = true
	file_dialog.access = FileDialog.ACCESS_FILESYSTEM

func setup_map_node():
	var root = ViewportContainer.new()
	# add the rest of the viewport requirements
	root.add_child(Viewport.new())
	
	# Setup camera
	pass

func dir_contents(path):
	var dir = Directory.new()
	if dir.open(path) == OK:
		dir.list_dir_begin()
		var file_name = dir.get_next()
		while file_name != "":
			if dir.current_is_dir():
				print("Found directory: " + file_name)
			else:
				print("Found file: " + file_name)
			file_name = dir.get_next()
	else:
		print("An error occurred when trying to access the path.")


# VMF Opening functions
func open_map():
	# ready dialog for map opening
	file_dialog.window_title = "Open Map"
	file_dialog.set_filters(PoolStringArray(["*.vmf ; Valve Map File"]))
	file_dialog.mode = FileDialog.MODE_OPEN_FILE
	
	# Connect to our function
	file_dialog.connect("file_selected", self, "parse_map_vmf")
	file_dialog.popup()

func parse_map_vmf(path):
	# We've got the file. We don't need the connection anymore for now.
	file_dialog.disconnect("file_selected", self, "parse_map_vmf")
	print(path)


# VMF Saving Functions
func save_map():
	# ready dialog for map opening
	file_dialog.window_title = "Save Map"
	file_dialog.set_filters(PoolStringArray(["*.vmf ; Valve Map File"]))
	file_dialog.mode = FileDialog.MODE_SAVE_FILE
	
	# Connect to our function
	file_dialog.connect("file_selected", self, "save_map_vmf")
	file_dialog.popup()

func save_map_vmf(path):
	# We've got the file. We don't need the connection anymore for now.
	file_dialog.disconnect("file_selected", self, "save_map_vmf")
	print(path)
