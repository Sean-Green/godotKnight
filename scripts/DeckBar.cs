using System;
using System.Collections.Generic;
using Godot;

namespace GodotKnight.scripts;

public partial class DeckBar : Node2D
{
	private static readonly PackedScene Card = GD.Load<PackedScene>("res://scenes/card.tscn");
	
	private int _maxHandSize = 5;
	private List<Card> _hand;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hand = new List<Card>();
		GD.Print("deck pos " + this.Position );
		for (int i = 0; i < _maxHandSize; i++)
		{
			Card card = Card.Instantiate<Card>();
			card.Position = this.Position + new Vector2(i%2==0?10:170, (float)Math.Floor((decimal)(i/2)) * 200);
			GD.Print("card pos " + card.Position );
			_hand.Add(card);
			AddChild(card);
		}
		GD.Print("hand " + _hand.Count);
		GD.Print("Children: " + GetChildren().Count);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
