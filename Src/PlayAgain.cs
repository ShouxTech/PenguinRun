using Godot;
using System;

public class PlayAgain : Button {
    public override void _Ready() {
        
    }

    public override void _Pressed() {
        GetTree().ChangeScene("res://Scenes/Main.tscn");
    }
}