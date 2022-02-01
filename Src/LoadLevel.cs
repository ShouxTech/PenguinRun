using Godot;
using System;

public class LoadLevel : Node2D {
    Node levels;
    TextureRect backgroundTexture;

    public override void _Ready() {
        levels = GetNode<Node>("Levels");
        backgroundTexture = GetNode<TextureRect>("ParallaxBackground/ParallaxLayer/Background");

        foreach (Node level in levels.GetChildren()) {
            if (level.Name != GameState.level) {
                levels.RemoveChild(level);
            } else {
                backgroundTexture.Texture = ((LevelSettings)level).background;
                foreach (Node2D node in level.GetChildren()) {
                    node.Visible = true;
                }
            }
        }
    }
}