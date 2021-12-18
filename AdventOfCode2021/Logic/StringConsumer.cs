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

        public void Skip(int length)
        {
            Index += length;
        }

        public bool IsFinished()
        {
            return (Index >= Buffer.Length);
        }

        public char Peek()
        {
            return (Buffer[Index]);
        }

        public string Last()
        {
            return (Buffer.Substring(Index, Buffer.Length - Index));
        }
    }
}