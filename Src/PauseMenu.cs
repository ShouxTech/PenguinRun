using Godot;
using System;

public class PauseMenu : Control {
    public override void _Ready() {
        
    }

    public override void _UnhandledKeyInput(InputEventKey eventKey) {
        if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape) {
            if (GameState.paused) {
                Visible = false;
                GameState.paused = false;
            } else {
                GameState.paused = true;
                Visible = true;
            }
        }
    }
}