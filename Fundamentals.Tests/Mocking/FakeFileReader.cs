using Fundamentals.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundaementals.UnitTests.Mocking
{
    class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
