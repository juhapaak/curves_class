using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public static class MathHelp
{
	public static Vector3 GetCurvePoint(Vector3[] points, float t)
	{
		// If there are less than 2 points, return zero vector.
		if (points.Length < 2)
		{
			return Vector3.zero;
		}
		// While there are more than one point, interpolate between them.
		while (points.Length > 1)
		{
			Vector3[] nextPoints = new Vector3[points.Length - 1];
			for (int i = 0; i < nextPoints.Length; i++)
			{
				// Lerp between the current point and the next point based on t.
				nextPoints[i] = Vector3.Lerp(points[i], points[i + 1], t);
			}
			// Update the points to the new interpolated points.
			points = nextPoints;
		}
		// Return the final point, which is the result of the interpolation.
		return points[0];
	}
}
