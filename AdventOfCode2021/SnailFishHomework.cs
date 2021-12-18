using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;
using AdventOfCode2021.Logic;

namespace AdventOfCode2021
{
    public class CompositeSnailFishNumber : SnailFishNumber
    {
        public List<SnailFishNumber> Numbers = new();

        public CompositeSnailFishNumber() { }

        public CompositeSnailFishNumber(int v1, int v2)
        {
            LitteralSnailFishNumber a = new LitteralSnailFishNumber(v1);
            LitteralSnailFishNumber b = new LitteralSnailFishNumber(v2);

            a.Prev = this;
            b.Prev = this;

            Numbers.Add(b);
            Numbers.Add(a);
        }

        public void Append(IEnumerable<SnailFishNumber> numbers)
        {
            SnailFishNumber[] nbrs = numbers.ToArray();
            foreach (SnailFishNumber number in nbrs)
            {
                number.Prev = this;
            }

            Numbers.AddRange(nbrs);
        }

        public CompositeSnailFishNumber ReverseAdd(CompositeSnailFishNumber nbr)
        {
            CompositeSnailFishNumber n = new CompositeSnailFishNumber();

            n.Numbers.Add(this);
            Prev = n;

            nbr = nbr.Clone();
            nbr.Prev = n;
            n.Numbers.Add(nbr);

            return (n);
        }

        public override string ToString()
        {
            IEnumerable<string> elements = Numbers.Select(i => i.ToString());

            return ($"[{string.Join(',', elements)}]");
        }

        public bool MustExplode()
        {
            return (FindExplode(this) != null);
        }
        
        public override LitteralSnailFishNumber MustSplit()
        {
            return (Numbers
                .Select(i => i.MustSplit())
                .FirstOrDefault(i => i != null));
        }

        public override long GetMagnitude()
        {
            SnailFishNumber a = Numbers.First();
            SnailFishNumber b = Numbers.Last();

            return (3 * a.GetMagnitude() + 2 * b.GetMagnitude());
        }
        
        public override CompositeSnailFishNumber Clone()
        {
            CompositeSnailFishNumber nbr = new CompositeSnailFishNumber();

            nbr.Numbers.AddRange(Numbers.Select(i => i.Clone()));
            nbr.Numbers.ForEach(i => i.Prev = nbr);

            return (nbr);
        }

        public bool ContainsDirectValues()
        {
            return (Numbers.Count == 2
                    && Numbers
                        .OfType<LitteralSnailFishNumber>()
                        .Count() == 2);
        }

        public (int, int) GetChildValues()
        {
            return
            (
                ((LitteralSnailFishNumber)Numbers[0]).Value,
                ((LitteralSnailFishNumber)Numbers[1]).Value
            );
        }
        
        public SnailFishNumber FindExplode(SnailFishNumber container, int depth = 0)
        {
            if (depth >= 4 && container is CompositeSnailFishNumber c
                           && c.ContainsDirectValues())
                return (container);

            if (container is CompositeSnailFishNumber nbr)
                return (nbr.Numbers
                    .Select(i => 
                        FindExplode(i, depth + 1))
                    .FirstOrDefault(i => i != null));

            return (null);
        }

        public void Explode()
        {
            SnailFishNumber toExplode = FindExplode(this);

            if (toExplode != null)
            {
                CompositeSnailFishNumber e = toExplode as CompositeSnailFishNumber;
                CompositeSnailFishNumber container = e.Prev;

                int idx = container.Numbers.IndexOf(e);
                (int, int) values = e.GetChildValues();
                LitteralSnailFishNumber a = FindClosestMember(-1, container, idx - 1);
                LitteralSnailFishNumber b = FindClosestMember(1, container, idx + 1);

                if (a != null)
                    a.Value += values.Item1;
                
                if (b != null)
                    b.Value += values.Item2;

                container.Numbers[idx] = new LitteralSnailFishNumber(0);
                container.Numbers[idx].Prev = container;
            }
        }

        public LitteralSnailFishNumber FindClosestMember(int direction, CompositeSnailFishNumber start, int idx)
        {
            LitteralSnailFishNumber result;

            if (direction == -1)
            {
                while (idx >= 0 && idx < start.Numbers.Count)
                {
                    if (start.Numbers[idx] is LitteralSnailFishNumber)
                        return (start.Numbers[idx] as LitteralSnailFishNumber);
                    
                    CompositeSnailFishNumber current = start.Numbers[idx] as CompositeSnailFishNumber;
                    result = FindClosestMember(-1, current, current.Numbers.Count - 1);

                    if (result != null)
                        return (result);
                    
                    --idx;
                }

                if (start.Prev != null)
                    return (FindClosestMember(-1, start.Prev, start.Prev.Numbers.IndexOf(start) - 1));
            }
            else
            {
                while (idx < start.Numbers.Count)
                {
                    if (start.Numbers[idx] is LitteralSnailFishNumber)
                        return (start.Numbers[idx] as LitteralSnailFishNumber);
                    
                    CompositeSnailFishNumber current = start.Numbers[idx] as CompositeSnailFishNumber;
                    result = FindClosestMember(1, current, 0);

                    if (result != null)
                        return (result);
                
                    ++idx;
                }

                if (start.Prev != null)
                    return (FindClosestMember(1, start.Prev, start.Prev.Numbers.IndexOf(start) + 1));
            }

            return (null);
        }

        public void Split()
        {
            LitteralSnailFishNumber toSplit = MustSplit();

            if (toSplit != null)
            {
                int idx = toSplit.Prev.Numbers.IndexOf(toSplit);
                CompositeSnailFishNumber n = new CompositeSnailFishNumber((toSplit.Value + 1) / 2, toSplit.Value / 2);

                n.Prev = toSplit.Prev;
                toSplit.Prev.Numbers[idx] = n;
            }
            
        }
    }
    
    public class LitteralSnailFishNumber : SnailFishNumber
    {
        public int Value;

        public LitteralSnailFishNumber(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return (Value.ToString());
        }
        
        public override SnailFishNumber Clone()
        {
            return (new LitteralSnailFishNumber(Value));
        }

        public override LitteralSnailFishNumber MustSplit()
        {
            return (Value > 9 ? this : null);
        }

        public override long GetMagnitude()
        {
            return (Value);
        }
    }

    public abstract class SnailFishNumber
    {
        public CompositeSnailFishNumber Prev;

        public abstract override string ToString();
        public abstract SnailFishNumber Clone();
        public abstract LitteralSnailFishNumber MustSplit();
        public abstract long GetMagnitude();
    }

    public class SnailFishHomework
    {
        public static CompositeSnailFishNumber FromString(string str)
        {
            CompositeSnailFishNumber nbr = new CompositeSnailFishNumber();
            StringConsumer consumer = new StringConsumer(str);
            
            nbr.Append(FromString(consumer));
            return (nbr);
        }

        public static IEnumerable<SnailFishNumber> FromString(StringConsumer consumer)
        {
            do
            {
                consumer.Skip(1);

                char peek = consumer.Peek();

                if (peek == '[')
                {
                    CompositeSnailFishNumber nbr = new CompositeSnailFishNumber();
                    
                    nbr.Append(FromString(consumer));

                    yield return (nbr);
                    consumer.Skip(1);
                }
                else if (peek is >= '0' and <= '9')
                {
                    yield return (new LitteralSnailFishNumber(consumer.GetNext(1).ToInt()));
                }
                else if (consumer.Peek() == ',')
                {
                    consumer.Skip(1);
                }
            } while (consumer.IsFinished()
                     || consumer.Peek() != ']');
        }
    }
}
