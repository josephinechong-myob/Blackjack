using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class StubConsole: IConsole
    {
        public List<string> TestingWriteLine;
        public int TestingReadLineCounter;
        private List<string> PlayOrder;
        // var playORder = new List<string>() { "1", "0" };
        // var stubConsole = new StubConsole(playORder);
        public StubConsole(List<string> playOrder)
        {
            TestingWriteLine = new List<string>();
            TestingReadLineCounter = 0;
            PlayOrder = playOrder;
        }
        public void WriteLine(string content)
        {
            TestingWriteLine.Add(content);
        }
        public string ReadLine()
        {
            var input = PlayOrder[TestingReadLineCounter];
            TestingReadLineCounter += 1;
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