using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static System.ReadLine;

namespace ReadLine.Tests
{
    public class ReadLineTests : IDisposable
    {
        public ReadLineTests()
        {
            string[] history = new string[] { "ls -a", "dotnet run", "git init" };
            AddHistory(history);
        }

        [Fact]
        public void TestNoInitialHistory() 
        {
            Assert.Equal(3, GetHistory().Count);
        }

        [Fact]
        public void TestUpdatesHistory() 
        {
            AddHistory("mkdir");
            Assert.Equal(4, GetHistory().Count);
            Assert.Equal("mkdir", GetHistory().Last());
        }

        [Fact]
        public void TestGetCorrectHistory() 
        {
            Assert.Equal("ls -a", GetHistory()[0]);
            Assert.Equal("dotnet run", GetHistory()[1]);
            Assert.Equal("git init", GetHistory()[2]);
        }

        [Fact]
        public void TestSetHistoryReplacesHistory()
        {
            SetHistory(new List<string>{"new", "history"});
            Assert.Equal(2, GetHistory().Count);
            Assert.Equal("new", GetHistory()[0]);
            Assert.Equal("history", GetHistory()[1]);
        }

        public void Dispose()
        {
            // If all above tests pass
            // clear history works
            ClearHistory();
        }
    }
}
