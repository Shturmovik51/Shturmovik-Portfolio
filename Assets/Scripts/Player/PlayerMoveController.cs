using Core.Interfaces;
using PathPoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInputSystem;

namespace MoveSystem
{
    public class PlayerMoveController : IUpdatable, ICleanable, IController
    {
        private PlayerView _view;
        private RayCastController _rayCastController;
        private PathPointsManager _pathPointsManager;

        private List<Transform> _pathPoints;
        private int _currentWaypointIndex;
        private bool _isMoving;

        public PlayerMoveController(RayCastController rayCastController, PathPointsManager pathPointsManager, GameConfig gameConfig)
        {
            _rayCastController = rayCastController;
            _pathPointsManager = pathPointsManager;
            _view = gameConfig.PlayerView;

            _pathPoints = new List<Transform>();

            _rayCastController.OnMoveAction += StartMove;
        }

        public void LocalUpdate(float deltaTime)
        {
            if (!_isMoving) return;

            Move();
        }

        private void StartMove(PathPointView pathPointView)
        {
            _pathPoints.Clear();
            _currentWaypointIndex = 0;

            var direction = (pathPointView.transform.position.x > _view.transform.position.x) ? MoveDirectonTypes.Right : MoveDirectonTypes.Left;
            var newPoints = _pathPointsManager.GetMovePath(_view.transform, pathPointView.transform, direction);

            _pathPoints.AddRange(newPoints);
            _view.NavMeshAgent.SetDestination(_pathPoints[_currentWaypointIndex].transform.position);
            _isMoving = true;
        }

        private void Move()
        {
            if (PathNearComplete())
            {
                _currentWaypointIndex++;

                if (_currentWaypointIndex < _pathPoints.Count)
                {
                    _view.NavMeshAgent.SetDestination(_pathPoints[_currentWaypointIndex].transform.position); 
                }
            }

            //if (PathComplete())
            //{
            //    _isMoving = false;
            //}
        }

        protected bool PathComplete()
        {
            var navMeshAgent = _view.NavMeshAgent;

            if (Vector3.Distance(navMeshAgent.destination, navMeshAgent.transform.position) <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool PathNearComplete()
        {
            var navMeshAgent = _view.NavMeshAgent;

            if (Vector3.Distance(navMeshAgent.destination, navMeshAgent.transform.position) <= navMeshAgent.stoppingDistance + 1.2f)
            {
                return true;
            }

            return false;
        }        

        public void CleanUp()
        {
            _rayCastController.OnMoveAction -= StartMove;
        }
    }
}



