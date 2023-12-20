using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HackerRankAlgorithm.Others;
using Xunit;

namespace HackerRankAlgorithm.Tests
{
    public class EncryptionTests
    {
        [Fact]
        public void WhenThen()
        {
            var input = "if man was meant to stay on the ground god would have given us roots";
            var algorithm = new Encryption();
            var result = algorithm.DoEncryption(input);
            "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau".Should().Be(result);
            
        }
    }
}
