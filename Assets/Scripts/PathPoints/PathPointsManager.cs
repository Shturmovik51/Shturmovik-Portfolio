using MoveSystem;
using PathPoints;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathPointsManager
{
    private List<Transform> _pathPoints;

    public PathPointsManager(GameConfig config)
    {
        _pathPoints = config.PathPointsHolder.GetComponentsInChildren<Transform>().ToList();
        _pathPoints.Remove(config.PathPointsHolder.transform);
    }

    public List<Transform> GetMovePath(Transform playerPosition, Transform targetPoint, MoveDirectonTypes direction)
    {
        var points = new List<Transform>();

        switch (direction)
        {
            case MoveDirectonTypes.None: 
                throw new System.Exception("None direction type in GetMovePath");
                
            case MoveDirectonTypes.Left:

                for (int i = _pathPoints.Count - 1; i >= 0; i--)
                {
                    var pointPosition = _pathPoints[i].transform.position;

                    if (pointPosition.x < playerPosition.position.x)
                    {
                        points.Add(_pathPoints[i]);

                        if (_pathPoints[i] == targetPoint)
                        {
                            break;
                        }
                    }
                }

                break;

            case MoveDirectonTypes.Right:

                for (int i = 0; i < _pathPoints.Count; i++)
                {
                    var pointPosition = _pathPoints[i].transform.position;

                    if (pointPosition.x > playerPosition.position.x)
                    {
                        points.Add(_pathPoints[i]);

                        if (_pathPoints[i] == targetPoint)
                        {
                            break;
                        }
                    }
                }

                break;

            default:
                break;
        }

        return points;
    }
}
