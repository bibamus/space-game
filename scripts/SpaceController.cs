using System.Collections.Generic;
using System.Linq;
using Godot;

namespace SpaceGame;

public partial class SpaceController : Node
{
    private List<SpaceShip> _spaceShips;

    public override void _Ready()
    {
        _spaceShips = GetChildren()
            .Where(node => node is SpaceShip)
            .Cast<SpaceShip>()
            .ToList();
    }

    public override void _Process(double delta)
    {
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            foreach (var spaceShip in _spaceShips)
            {
                spaceShip.Target = mouseButton.Position;
            }
        }
    }
}