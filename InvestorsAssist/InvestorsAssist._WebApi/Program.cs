﻿using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorsAssist._WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            string baseAddress = @"http://localhost:8887/InvestorsAssist/";
#else
                    string baseAddress = @"http://localhost:8888/InvestorsAssist/";
#endif
            try
            {
        
                if (string.IsNullOrEmpty(baseAddress))
                    throw new Exception("Missing Configuration: BaseAddress");
                Console.WriteLine("Starting service...");
                using (WebApp.Start<Startup>(baseAddress))
                {
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
