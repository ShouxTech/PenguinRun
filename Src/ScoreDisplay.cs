using Godot;
using System;

public class ScoreDisplay : Label {
    public override void _Ready() {
        
    }

    public override void _Process(float delta)
    {
        Text = GameState.score.ToString();
    }
}