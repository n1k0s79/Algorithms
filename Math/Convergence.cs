using System.Collections.Generic;

namespace Math
{
    public class Convergence
    {
        /// <summary> Finds and approximation of the input n that can run for maximum time targer </summary>
        /// <remarks>Strategy:
        /// Start moving up at an initial speed
        /// If you go past the mark then go down at half the speed
        /// If you go past the mark then go up again at half the previous speed
        /// Repeat
        /// </remarks>
        public static long Converge(double target, long initialSpeed)
        {
            var direction = Directions.Up;
            var a = Approximate(2, target, initialSpeed, direction);
            var l = new List<Approximation>() { a };
            while (true)
            {
                if (direction == Directions.Up) direction = Directions.Down; else direction = Directions.Up;
                long newSpeed = a.Speed / 2;
                if (newSpeed == 0) break;
                a = Approximate(a.Input, target, newSpeed, direction); // slow down
                l.Add(a);
            }
            return l[l.Count - 1].Input;
        }

        private static Approximation Approximate(long location, double target, long speed, Directions direction)
        {
            long iterations = 0;

            double output = 0;
            while (true)
            {
                iterations++;
                output = location * System.Math.Log(location, 2);
                if (direction == Directions.Up && output > target) break;
                if (direction == Directions.Down && output < target) break;
                if (direction == Directions.Up) location += speed; else location -= speed;
            }

            return new Approximation(direction, speed, location, output, target, iterations);
        }

        enum Directions
        {
            Up,
            Down
        }

        class Approximation
        {
            public readonly Directions Direction;
            public readonly long Speed;
            public readonly long Input;
            public readonly double Output;
            public readonly double Target;
            public readonly long Iterations;

            public Approximation(Directions direction, long speed, long input, double output, double target, long iterations)
            {
                this.Direction = direction;
                this.Speed = speed;
                this.Input = input;
                this.Output = output;
                this.Target = target;
                this.Iterations = iterations;
            }
        }

    }
}