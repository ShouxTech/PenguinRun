using Godot;
using System;

public class RestartBtn : Button {
    public override void _Ready() {

    }

    private void Restart() {
        GetTree().ChangeScene("res://Scenes/Main.tscn");
        GameState.paused = false;
    }

    public override void _Pressed() {
        Restart();
    }

    public override void _UnhandledKeyInput(InputEventKey eventKey) {
        if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.R) {
            Restart();
        }
    }
}