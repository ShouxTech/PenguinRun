using Godot;
using System;

public class GameOverScoreDisplay : Label {
    public override void _Ready() {
        Text = "YOUR SCORE: " + GameState.score;
    }
}