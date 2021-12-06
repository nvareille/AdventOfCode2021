using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Containers
{
    public class StateElement<T>
    {
        public T State;
        public T Actual;

        public StateElement(T b)
        {
            State = b;
            Actual = b;
        }

        public StateElement(T b, T reset)
        {
            State = reset;
            Actual = b;
        }

        public void Tick(Action<StateElement<T>> action)
        {
            action(this);
        }

        public void Reset()
        {
            Actual = State;
        }
    }
}
