using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmHackerrank.Tests
{
    [TestFixture]
    public class EncryptionTests
    {
        [Test]
        public void WhenThen()
        {
            var input = "if man was meant to stay on the ground god would have given us roots";
            var algorithm = new Encryption();
            var result = algorithm.DoEncryption(input);
            Assert.AreEqual("imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau", result);
            
        }
    }
}
