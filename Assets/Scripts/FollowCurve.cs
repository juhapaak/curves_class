using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    [SerializeField] private Curve _curve;
    [SerializeField] private float _speed = 1f;
    // _tParam is a parameter that varies from 0 to 1, representing the position on the curve.
    private float _tParam = 0f;
    // _forward is a boolean that determines the direction of movement along the curve.
    private bool _forward = true;

    void Update()
    {
        // Move along the curve based on the speed and direction.
        // _tParam is updated based on the speed and direction (_forward).
        _tParam += _forward ? _speed * Time.deltaTime : -_speed * Time.deltaTime;
        // Clamp _tParam to ensure it stays within the range [0, 1].
        // If _tParam exceeds 1 or goes below 0, reverse the direction and clamp it.
        if (_tParam > 1f || _tParam < 0f)
        {
            _forward = !_forward;
            _tParam = Mathf.Clamp01(_tParam);
        }
        // Calculate the new position on the curve using the current _tParam value.
        transform.position = _curve.GetPoint(_tParam);        
    }
}
