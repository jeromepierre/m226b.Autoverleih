using m226b.Autoverleih.Programm.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace m226b.Autoverleih.Test
{
    public class DataUtilTest
    {
        [Test]
        public void DataInit()
        {
            DataUtil.GenerateMockData();
            Assert.IsTrue(File.Exists(@"C:\VS-Workspace\M226\Data\repository.txt"));
        }

        [Test]
        public void RepositoryFill()
        {
            Repository repo = DataUtil.GenerateMockData();
            Assert.IsTrue(repo != null);
        }
    }
}
