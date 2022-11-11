using Godot;
using System;

public partial class GameScene : Node3D
{
    public Player Player;
    public Camera3D Camera;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Player = GetNode<Player>("Player");
        Camera = GetNode<Camera3D>("Camera");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Camera.Position = new Vector3(-30, Player.Position.y, Player.Position.z);
    }
}
