using System.Collections.Generic;
using System.Linq;
using Godot;

namespace ProjectJotun.dungeon;

public partial class Branch : Node
{
	Branch leftChild;
	Branch rightChild;
	public Vector2I position;
	public Vector2I size;

	public Branch() : base() { }

	public Branch(Vector2I position, Vector2I size) : base()
	{
		this.position = position;
		this.size = size;
	}

	public void Split(int remaining, List<PathSegment> paths)
	{
		RandomNumberGenerator rng = new RandomNumberGenerator();
		float splitPercent = rng.RandfRange(0.3f,0.7f);
		bool splitHorizontal = size.Y >= size.X;
 
		if (splitHorizontal)
		{
			int leftHeight = (int)(size.Y * splitPercent);
			leftChild = new Branch(position, new Vector2I(size.X, leftHeight));
			rightChild = new Branch(
				new Vector2I(position.X, position.Y + leftHeight), 
				new Vector2I(size.X, size.Y - leftHeight));
		}
		else
		{
			int leftWidth = (int)(size.X * splitPercent);
			leftChild = new Branch(position, new Vector2I(leftWidth, size.Y));
			rightChild = new Branch(
				new Vector2I(position.X + leftWidth, position.Y), 
				new Vector2I(size.X - leftWidth, size.Y));
		}
 
		paths.Add(new PathSegment(leftChild.GetCenter(), rightChild.GetCenter()));
 
		if(remaining > 0)
		{
			leftChild.Split(remaining - 1, paths);
			rightChild.Split(remaining - 1, paths);
		}
	}

	public Vector2I GetCenter()
	{
		return new Vector2I(position.X + size.X / 2, position.Y + size.Y / 2);
	}

	public List<Branch> getLeaves()
	{
		if (leftChild == null || rightChild == null)
		{
			return new List<Branch> { this };  // no children = this IS a leaf
		}
		else
		{
			var childLeaves = leftChild.getLeaves();
			childLeaves.AddRange(rightChild.getLeaves());
			return childLeaves;
		}
	}
	

}
