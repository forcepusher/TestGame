using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.TouchInput
{
    public class SwipeListener : MonoBehaviour
    {
        private readonly float _swipePositionDeltaThreshold;
        private readonly float _swipeTimeThreshold;

        public SwipeListener(float swipePositionDeltaThreshold = 0.2f, float swipeTimeTreshold = 0.3f)
        {
            _swipePositionDeltaThreshold = swipePositionDeltaThreshold;
            _swipeTimeThreshold = swipeTimeTreshold;
        }

        private Queue<SwipeDirection> _swipes;
        private List<Finger> _fingers;

        public void AddFinger(Finger finger)
        {
            _fingers.Add(finger);
        }

        public void PollSwipes()
        {
            for (int fingerIterator = _fingers.Count - 1; fingerIterator >= 0; fingerIterator--)
            {
                Finger finger = _fingers[fingerIterator];

                if (finger.Phase == FingerPhase.Lifted)
                {
                    if (finger.ElapsedTime <= _swipeTimeThreshold)
                    {
                        Vector2 swipePositionDelta = finger.NormalizedPosition - finger.NormalizedStartPosition;
                        if (swipePositionDelta.magnitude >= _swipePositionDeltaThreshold)
                        {
                            Vector2.Angle(Vector2.up,)
                        }
                    }
                }
            }
        }
    }
}
