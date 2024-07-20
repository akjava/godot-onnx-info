extends Node2D

var info_script = load("res://csharp/GodotOnnxInfo.cs")
var onnx_info = null
# Called when the node enters the scene tree for the first time.
func _ready():
	var model_path = find_child("ModelPathLineEdit").text
	#var model_path = "sigmoid.onnx"
	onnx_info = info_script.new(model_path)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _on_info_button_pressed():
	pass # Replace with function body.
