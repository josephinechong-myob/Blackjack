using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class StubConsole: IConsole
    {
        public List<string> TestingWriteLine;
        public int TestingReadLine;

        public StubConsole()
        {
            TestingWriteLine = new List<string>();
            TestingReadLine = 0;
        }
        public void WriteLine(string content)
        {
            TestingWriteLine.Add(content);
        }
        public string ReadLine()
        {
            return "0";
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