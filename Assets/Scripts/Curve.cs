using UnityEngine;

public class Curve : MonoBehaviour
{
	public Vector3[] points;

	public void Reset()
	{
		// Reset the points to a default state if none are provided
		int pointCount = points.Length > 0 ? points.Length : 2;
		// Ensure at least two points are present
		points = new Vector3[pointCount];
		// Initialize the points in a straight line for simplicity
		for (int i = 0; i < pointCount; i++)
		{
			// Set points in a straight line along the x-axis
			points[i] = new Vector3(i + 1f, 0f, 0f);
		}
	}
	
	// Method to get a point on the curve at parameter t (0 <= t <= 1)
	public Vector3 GetPoint(float t)
	{
		// If t is out of bounds, clamp it to the range [0, 1]
		if (points.Length < 2)
		{
			return Vector3.zero;
		}
		// Return the transformed point on the curve
		return transform.TransformPoint(MathHelp.GetCurvePoint(points, t));
	}
}
