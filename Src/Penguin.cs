using Godot;
using System;

public class Penguin : KinematicBody2D {
    private float gravity = 230;
    private float speed = 120;
    private float jumpForce = 7100;

    private float timeSinceLastScoreUpdate = 0;

    private Vector2 upDirection = new Vector2(0, -1);

    private Vector2 velocity;

    private AnimatedSprite sprite;
    private CollisionShape2D collisionShape;
    private CapsuleShape2D capsuleShape;

    public override void _Ready() {
        GameState.Reset();
        sprite = GetNode<AnimatedSprite>("Sprite");
        collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        capsuleShape = (CapsuleShape2D)collisionShape.Shape;
    }

    private void MoveOnSlope() {
        int slides = GetSlideCount();
        for (int i = 0; i < slides; i++) {
            KinematicCollision2D touched = GetSlideCollision(i);
            if (IsOnFloor() && touched.Normal.y < 1 && (velocity.x != 0.0 || velocity.y != 0.0)) {
                velocity.y = touched.Normal.y;
            }
        }
    }

    private void Move(float delta) {
        velocity.y += delta * gravity;

        sprite.FlipH = false;
        sprite.Play("Walking");
        velocity.x = speed;

        if (Input.IsActionPressed("slide")) {
            sprite.Play("Sliding");
            capsuleShape.Height = 0;
            collisionShape.Position = new Vector2(0, 3);
        } else {
            capsuleShape.Height = 8;
            collisionShape.Position = new Vector2(0, -1);
        }

        if (Input.IsActionPressed("jump") && IsOnFloor()) {
            velocity.y -= delta * jumpForce;
        }

        if (!IsOnFloor()) {
            sprite.Play("Jumping");
        }

        MoveAndSlide(velocity, upDirection, true, 4, Mathf.Deg2Rad(60));
    }

    private void CheckForSpike() {
        int slides = GetSlideCount();
        for (int i = 0; i < slides; i++) {
            KinematicCollision2D touched = GetSlideCollision(i);
            object name = touched.Collider.Get("name");
            if ((string)name == "Spikes") {
                GetTree().ChangeScene("res://Scenes/GameOver.tscn");
            }
        }
    }

    private void CheckOffScreen() {
        if (Position.y > 160) {
            GetTree().ChangeScene("res://Scenes/GameOver.tscn");
        }
    }

    public override void _Process(float delta) {
        timeSinceLastScoreUpdate += delta;
        if (timeSinceLastScoreUpdate > 1) {
            timeSinceLastScoreUpdate = 0;
            GameState.score++;
        }
    }

    public override void _PhysicsProcess(float delta) {
        Move(delta);
        MoveOnSlope();
        CheckForSpike();
        CheckOffScreen();
    }
}