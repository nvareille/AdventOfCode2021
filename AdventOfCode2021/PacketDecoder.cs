using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Extensions;
using AdventOfCode2021.Logic;

namespace AdventOfCode2021
{
    public abstract class Packet
    {
        public int Version;
        public int Type;

        public abstract int GetSubVersions();
        public abstract long GetValue();
    }

    public class OperatorPacket : Packet
    {
        public List<Packet> Packets = new List<Packet>();

        private Dictionary<int, Func<long, long, long>> Operators = new Dictionary<int, Func<long, long, long>>
        {
            { 0, (a, b) => a + b },
            { 1, (a, b) => a * b },
            { 2, (a, b) => a < b ? a : b },
            { 3, (a, b) => a > b ? a : b },
            { 5, (a, b) => a > b ? 1 : 0 },
            { 6, (a, b) => a < b ? 1 : 0 },
            { 7, (a, b) => a == b ? 1 : 0 },
        };


        public override int GetSubVersions()
        {
            return (Packets.Sum(i => i.GetSubVersions()) + Version);
        }

        public override long GetValue()
        {
            return (Packets.Select(i => i.GetValue())
                .Aggregate(Operators[Type]));
        }
    }

    public class LitteralPacket : Packet
    {
        public long Value;

        public LitteralPacket(long value)
        {
            Value = value;
        }

        public override int GetSubVersions()
        {
            return (Version);
        }

        public override long GetValue()
        {
            return (Value);
        }
    }

    public class PacketDecoder
    {
        private static string HexaMapping = "0123456789ABCDEF";
        private static string[] Bits = new string[]
        {
            "0000",
            "0001",
            "0010",
            "0011",
            "0100",
            "0101",
            "0110",
            "0111",
            "1000",
            "1001",
            "1010",
            "1011",
            "1100",
            "1101",
            "1110",
            "1111",
        };

        public Packet Root;

        public PacketDecoder(string str)
        {
            string buffer = str.Select(GetPacketChunk).Aggregate((a, b) => a + b);
            StringConsumer consumer = new StringConsumer(buffer);

            Root = GenPacket(consumer);
        }

        private Packet GenPacket(StringConsumer consumer)
        {
            List<Packet> packets = new List<Packet>();
            int version = Convert.ToInt32(consumer.GetNext(3), 2);
            int type = Convert.ToInt32(consumer.GetNext(3), 2);

            if (type != 4)
                return (GenOperatorPacket(consumer, version, type));
            return (GenValuePacket(consumer, version));
        }

        private LitteralPacket GenValuePacket(StringConsumer consumer, int version)
        {
            string value = "";
            string current;
            int read = 0;

            do
            {
                current = consumer.GetNext(5);
                value += current.Substring(1, 4);
                read += 5;
            } while (current[0] == '1');

            long nbr = value.FromBinaryLong();

            return (new LitteralPacket(nbr)
            {
                Type = 4,
                Version = version
            });
        }

        private OperatorPacket GenOperatorPacket(StringConsumer consumer, int v, int t)
        {
            OperatorPacket packet = new OperatorPacket
            {
                Version =  v,
                Type = t
            };
            string type = consumer.GetNext(1);
            
            if (type == "0")
            {
                long value = consumer.GetNext(15).FromBinaryLong();
                string buffer = consumer.GetNext((int)value);
                StringConsumer c = new StringConsumer(buffer);

                while (!c.IsFinished())
                {
                    packet.Packets.Add(GenPacket(c));
                }
            }
            else
            {
                long packets = consumer.GetNext(11).FromBinaryLong();

                while (packets > 0)
                {
                    packet.Packets.Add(GenPacket(consumer));
                    --packets;
                }
            }

            return (packet);
        }

        private string GetPacketChunk(char c)
        {
            return (Bits[HexaMapping.IndexOf(c)]);
        }

        public long Compute()
        {
            return (Root.GetValue());
        }
    }
}
