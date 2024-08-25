using Godot;
using System;

public partial class Manager : Node
{
    private int _iron = 0;

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }

    public void AddIron(int amount)
    {
        _iron += amount;
        GD.Print("Iron: " + _iron);
    }
}