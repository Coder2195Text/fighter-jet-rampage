using Godot;
using System;

public partial class PlayerMissile : CharacterBody3D
{
    // Called when the node enters the scene tree for the first time.
    private static PackedScene s_scene = ResourceLoader.Load<PackedScene>("res://Sprites/GameScene/PlayerMissile.tscn");
    private Vector2 _initialPosition;
    private float _initialAngle;
    public override void _Ready()
    {
        base._Ready();
        Position = new Vector3(0, _initialPosition.y, _initialPosition.x);
        RotateX(_initialAngle);

    }

    public static PlayerMissile FireMissile(Vector2 initPos, float initAngle)
    {
        PlayerMissile missile = s_scene.Instantiate<PlayerMissile>();
        missile._initialPosition = initPos;
        missile._initialAngle = initAngle;
        return missile;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (!IsInstanceValid(this)) return;
        float angle = Rotation.x;
        Velocity = new Vector3(0, -Mathf.Sin(angle), Mathf.Cos(angle)) * 40;
        MoveAndSlide();
    }

    public void DestroyMissile()
    {
        //explosion todo
        QueueFree();
    }
}
