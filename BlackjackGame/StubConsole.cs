using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class StubConsole: IConsole
    {
        private List<string> TestingWriteLine;
        private int _testingReadLineCounter;
        private readonly List<string> _playOrder;
        // var playORder = new List<string>() { "1", "0" };
        // var stubConsole = new StubConsole(playORder);
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
            
            //have an array passed 
        }
        //stubconsolestay and stubconsolehit 
        
        //We can track the number of times this method was called and also track the value of write line - using fields inside the StubConsole class
        //write a test to track how many times the method is called and the value is what we expect
           
        //track write line gets called and what the values are (list to track it)
        //update the test for it
        //track how many times Readline was called
        //change the value of what it returns based on how many it was called
    }
}