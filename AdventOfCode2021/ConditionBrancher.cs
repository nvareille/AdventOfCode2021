using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class ConditionBrancher<T>
    {
        private readonly List<(Func<T, bool>, Action)> Conditions = new ();

        public ConditionBrancher<T> Append(Func<T, bool> fct, Action act)
        {
            Conditions.Add((fct, act));
            return (this);
        }

        public bool Evaluate(T data, bool ret = true)
        {
            foreach ((Func<T, bool>, Action) condition in Conditions)
            {
                if (condition.Item1(data))
                {
                    condition.Item2();

                    if (ret)
                        return (true);
                }
            }

            return (false);
        }
    }
}
