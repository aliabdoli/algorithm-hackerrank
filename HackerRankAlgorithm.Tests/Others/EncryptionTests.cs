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
        [Theory]
        [InlineData("if man was meant to stay on the ground god would have given us roots", "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn sseoau")]
        [InlineData("chillout", "clu hlt io")]
        [InlineData("roqfqeylxuyxjfyqterizzkhgvngapvudnztsxeprfp", "rlyzatp oxqkps quthvx fyegue qxrvdp ejinnr yfzgzf")]
        public void WhenThen(string input, string expected)
        {
            var algorithm = new Encryption();
            var result = algorithm.DoEncryption(input);
            result.Should().Be(expected);
            
        }
    }
}
