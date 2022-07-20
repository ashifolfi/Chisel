shader_type spatial;
render_mode blend_add, specular_schlick_ggx;

void fragment() {
// Color:2
	vec3 n_out2p0 = vec3(0.988235, 0.341176, 0.341176);
	float n_out2p1 = 0.772549;

// Output:0
	ALBEDO = n_out2p0;
	ALPHA = n_out2p1;
}