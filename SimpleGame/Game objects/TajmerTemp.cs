using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.SimpleGame
{
    class TajmerTemp
    {
        public float TimeToPass { get; set; }
        public float CurrentTime { get; set; }
        public bool IsTurnedOn { get; set; }
        public float Intervals { get; set; }

        public TajmerTemp(float TIME)
        {
            Intervals = 0.1f;
            TimeToPass = TIME;
        }

        public void ResetTimer()
        {
            CurrentTime = 0.0f ;
            IsTurnedOn = false;
        }

        public bool IsDone()
        {
            bool result = CurrentTime > TimeToPass || !IsTurnedOn;
            return result;
        }

        public void Start()
        {
            if(IsTurnedOn == false)
            {
                IsTurnedOn = true;
            }
        }

        public string GetCurrentState()
        {
            string result = String.Format(
                "Current time: {0,-10}; Is on: {1,-6}; It's DONE: {2,-6}",
                CurrentTime, IsTurnedOn, IsDone());
            return result;
        }

        public void Update(float MULTIPLIER = 1.0f)
        {
            if (IsTurnedOn)
            {
                if (IsDone()) 
                { 
                    ResetTimer(); 
                }
                else
                {
                    CurrentTime += Intervals * MULTIPLIER;
                }
            }

        }
    }
}
