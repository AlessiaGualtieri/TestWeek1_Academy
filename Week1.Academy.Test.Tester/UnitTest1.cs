using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Week1.Academy.Test.Tester
{
    public class UnitTest1
    {
        [Fact]
        public void TestFile()
        {
            //ARRANGE
            List<string> lines = new List<string>();

            //using (StreamWriter writer = File.CreateText(@"C:\Users\alessia.gualtieri\Desktop\Alessia\Avanade\Corso\Week1_Academy\speseTest.txt"))
            //{
            //    writer.WriteLine("2021/07/15;Viaggio;Viaggettino carino per relax;500");
            //    writer.WriteLine("2021/07/16;Viaggio;Incontro aziendale a Dublino;3100");
            //    writer.WriteLine("2021/05/23;Vitto;Pranzo aziendale;1400");
            //    writer.WriteLine("2021/04/03;Altro;Festa di compleanno;50");
            //    writer.WriteLine("2021/05/12;Alloggio;Hotel Dubai;350");
            //}


            //ACT

            using (StreamReader reader = File.OpenText(@"C:\Users\alessia.gualtieri\Desktop\Alessia\Avanade\Corso\Week1_Academy\spese_elaborate.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            //ASSERT
            Assert.Equal(5, lines.Count);
            Assert.Equal("7/15/2021;Viaggio;Viaggettino carino per relax;APPROVATA;OPS;550", lines[0]);
            Assert.Equal("7/16/2021;Viaggio;Incontro aziendale a Dublino;RESPINTA;-;-", lines[1]);
            Assert.Equal("5/23/2021;Vitto;Pranzo aziendale;APPROVATA;CEO;980", lines[2]);
            Assert.Equal("4/3/2021;Altro;Festa di compleanno;APPROVATA;MGR;5", lines[3]);
            Assert.Equal("5/12/2021;Alloggio;Hotel Dubai;APPROVATA;MGR;350", lines[4]);
        }
    }
}
