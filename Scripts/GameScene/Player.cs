using Godot;
using System;
using System.Threading;
using Thread = System.Threading.Thread;

public partial class Player : CharacterBody3D
{
    public override void _Ready()
    {
        base._Ready();
    }
    public override void _PhysicsProcess(double delta)
    {
        Node3D parent = GetParent<Node3D>();
        Vector2 screenSize = GetViewport().GetVisibleRect().Size;
        Vector2 mousePos = GetViewport().GetMousePosition() - (screenSize / 2);
        float rotation = mousePos.Angle();
        Rotation = new Vector3(rotation, 0, Math.Abs(rotation));

        Vector2 movementVector = new Vector2(20, 0).Rotated(rotation);
        Velocity = new Vector3(0, -movementVector.y, movementVector.x);
        MoveAndSlide();
        if (Input.IsActionJustPressed("fire"))
        {
            new Thread(new ThreadStart(() =>
            {
                parent.CallDeferred("add_child", PlayerMissile.FireMissile(new Vector2(Position.z, Position.y), rotation));
                GD.Print("fire");
            })).Start();
        }
    }

}
