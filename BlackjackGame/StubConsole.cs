using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class StubConsole: IConsole
    {
        public List<string> TestingWriteLine;
        private int _testingReadLineCounter;
        private readonly List<string> _playOrder;
        public StubConsole(List<string> playOrder)
        {
            TestingWriteLine = new List<string>();
            _testingReadLineCounter = 0;
            _playOrder = playOrder;
        }
        public void WriteLine(string content)
        {
            TestingWriteLine.Add(content);
        }
        public string ReadLine()
        {
            var input = _playOrder[_testingReadLineCounter];
            _testingReadLineCounter += 1;
            return input;
        }
    }
}