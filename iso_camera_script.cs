using Godot;
using System;
public partial class iso_camera_script : Camera3D
{
	private Node3D player;

	int speed_factor = 10, camera_distance = 10;
	Vector3 relative_pos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Node3D>("../player");
		// Calculates where the camera should be relative to the player, which is behind and above the player
		// Change Camera Distance to change Camera Distance and change what the vectors are multiplied by to change angles
		Vector3 lookAtPos =(Vector3.Forward  + Vector3.Up * (float)Math.Sqrt(2)).Normalized() * camera_distance;
		LookAtFromPosition(lookAtPos,player.Position, Vector3.Up);
		relative_pos = Position - player.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame..
	public override void _Process(double delta)
	{
		// Smoothing of camera movement, change speed factor for how quickly the camera moves to player
		Position =  Position.Lerp(player.Position + relative_pos,(float)delta * speed_factor);
		// For Stiff Camera Movement
		// Position = player.Position + relative_pos

	}
}
