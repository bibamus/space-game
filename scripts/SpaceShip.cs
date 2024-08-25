using Godot;

namespace SpaceGame;

public partial class SpaceShip : Node2D
{
    private float _velocity = 1;
    public Vector2? Target { get; set; } = null;

    private Manager _manager;

    public override void _Ready()
    {
        _manager = GetNode<Manager>("/root/Manager");
    }

    public override void _Process(double delta)
    {
        if (Target is not null)
        {
            MoveTo(Target.Value);
        }
    }

    private void MoveTo(Vector2 target)
    {
        Vector2 direction = (target - Position).Normalized();

        if (Position.DistanceTo(target) > 1f)
        {
            // check if the ship is looking in the right direction
            if (direction.Angle() != Rotation)
            {
                Rotation = direction.Angle();
            }
            else
            {
                Position += direction * _velocity;
            }

            
        }
        else
        {
            _manager.AddIron(1);
            Target = null;
        }
    }
}