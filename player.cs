using Godot;
using System;

public partial class player : CharacterBody3D
{
	//private PackedScene cameraScene = GD.Load<PackedScene>("res://iso_camera.tscn");
	[Export]
	private int speed = 10;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		// Y is forward/back, X is left and right
		Vector2 movementDir = new Vector2(0,0);
		if(Input.IsActionPressed("Move_Forward"))
		{
			movementDir.Y += 1;
		}	

		if(Input.IsActionPressed("Move_Back"))
		{
			movementDir.Y -= 1;
		}	

		if(Input.IsActionPressed("Move_Left"))
		{
			movementDir.X += 1;
		}	

		if(Input.IsActionPressed("Move_Right"))
		{
			movementDir.X -= 1;
		}	

		Velocity = new Vector3(movementDir.X,0,movementDir.Y) * speed;
		MoveAndSlide();
	}
}
