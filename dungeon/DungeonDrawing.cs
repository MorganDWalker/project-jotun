using System.Collections.Generic;
using Godot;
using ProjectJotun.dungeon;

public partial class DungeonDrawing : Node2D
{

	 private Branch _rootNode;
	private const int TileSize = 16;
	private readonly Vector2I _worldSize = new Vector2I(60, 30);
 
	private TileMapLayer _tilemap;
	private readonly List<PathSegment> _paths = new();
 
	public override void _Ready()
	{
		_tilemap = GetNode<TileMapLayer>("TileMapLayer");
		_rootNode = new Branch(Vector2I.Zero, _worldSize);
		_rootNode.Split(2, _paths);
		QueueRedraw();
	}
 
	public override void _Draw()
	{
		var rng = new RandomNumberGenerator();
 
		foreach (Branch leaf in _rootNode.getLeaves())
		{
			var padding = new Vector4I(
				rng.RandiRange(2, 3),
				rng.RandiRange(2, 3),
				rng.RandiRange(2, 3),
				rng.RandiRange(2, 3)
			);
 
			for (int x = 0; x < leaf.size.X; x++)
			{
				for (int y = 0; y < leaf.size.Y; y++)
				{
					if (!IsInsidePadding(x, y, leaf, padding))
					{
						_tilemap.SetCell(new Vector2I(x + leaf.position.X, y + leaf.position.Y), 0, new Vector2I(2, 2));
					}
				}
			}
		}
 
		foreach (var path in _paths)
		{
			if (path.Left.Y == path.Right.Y)
			{
				for (int i = 0; i < path.Right.X - path.Left.X; i++)
				{
					_tilemap.SetCell(new Vector2I(path.Left.X + i, path.Left.Y), 0, new Vector2I(2, 2));
				}
			}
			else
			{
				for (int i = 0; i < path.Right.Y - path.Left.Y; i++)
				{
					_tilemap.SetCell(new Vector2I(path.Left.X, path.Left.Y + i), 0, new Vector2I(2, 2));
				}
			}
		}
	}
 
	private bool IsInsidePadding(int x, int y, Branch leaf, Vector4I padding)
	{
		return x <= padding.X || y <= padding.Y || x >= leaf.size.X - padding.Z || y >= leaf.size.Y - padding.W;
	}

}
