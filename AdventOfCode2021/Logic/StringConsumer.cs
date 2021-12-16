namespace AdventOfCode2021.Logic
{
    public class StringConsumer
    {
        private string Buffer;
        private int Index = 0;

        public StringConsumer(string buffer)
        {
            Buffer = buffer;
        }

        public string GetNext(int length)
        {
            string str = Buffer.Substring(Index, length);

            Index += length;
            return (str);
        }

        public bool IsFinished()
        {
            return (Index == Buffer.Length);
        }
    }
}