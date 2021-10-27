using Fundamentals.Mocking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoService = new VideoService();
            var title = videoService.ReadVideoTitle(new FileReader());

           


        }
    }
}
