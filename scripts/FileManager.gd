extends Node

func setup_map_node():
	var root = ViewportContainer.new()
	# add the rest of the viewport requirements
	root.add_child(Viewport.new())
	
	# Setup camera
	
