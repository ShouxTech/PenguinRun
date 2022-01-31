using Godot;
using System;

public class PlayLevel : Button {
    [Export] public string levelName;

    public override void _Ready() {
        
    }

    public override void _Pressed() {
        GameState.level = levelName;
        GetTree().ChangeScene("res://Scenes/Main.tscn");
    }
}