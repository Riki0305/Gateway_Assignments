using StringManipulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringManipulationsTest
{
    public class StringManipulationsTest
    {
        [Fact]
        public void ChangeCaseOfStringTest()
        {
            var str = "gateway";
            var result = str.ChangeCase();

            Assert.Equal("GATEWAY", result);
        }
        [Fact]
        public void ChangeCaseOfStringTest_Negative()
        {
            var str = "gateway";
            var result = str.ChangeCase();

            Assert.Equal("gateway", result);
        }


       
        [Fact]
        public void ChangeCaseOfEveryCharacterTest()
        {
            var str = "gAtEwAy";
            var result = str.ChangeCaseOfCharacter();

            Assert.Equal("GaTeWaY", result);
        }
        [Fact]
        public void ChangeCaseOfEveryCharacterTest_Negative()
        {
            var str = "gAtEwAy";
            var result = str.ChangeCaseOfCharacter();

            Assert.Equal("gAtEwAy", result);
        }


        [Fact]
        public void ChangeToTitleCaseTest()
        {
            var str = "here is my application";
            var result = str.ChangeToTitleCase();

            Assert.Equal("Here Is My Application", result);
        }
        [Fact]
        public void ChangeToTitleCaseTest_Negative()
        {
            var str = "here is my application";
            var result = str.ChangeToTitleCase();

            Assert.Equal("here is my application", result);
        }


       
        [Fact]
        public void CheckIsLowerTest()
        {
            var str = "gateway";
            var result = str.CheckIsLower();

            Assert.True(result);
        }
        [Fact]
        public void CheckIsLowerTest_Negative()
        {
            var str = "gateway";
            var result = str.CheckIsLower();

            Assert.False(result);
        }


        
        [Fact]
        public void CheckIsUpperTest()
        {
            var str = "GATEWAY";
            var result = str.CheckIsUpper();

            Assert.True(result);
        }
        [Fact]
        public void CheckIsUpperTest_Negative()
        {
            var str = "gateway";
            var result = str.CheckIsUpper();

            Assert.True(result);
        }

      
        [Fact]
        public void CapitalizeStringTest()
        {
            var str = "gateway";
            var result = str.CapitalizeString();

            Assert.Equal("Gateway", result);
        }
        [Fact]
        public void CapitalizeStringTest_Negative()
        {
            var str = "gateway";
            var result = str.CapitalizeString();

            Assert.Equal("gateway", result);
        }


       
        [Fact]
        public void CheckIfNumericalStringTest()
        {
            var str = "123";
            var result = str.CheckIfNumericalString();

            Assert.True(result);
        }
        [Fact]
        public void CheckIfNumericalStringTest_Negative()
        {
            var str = "gateway";
            var result = str.CheckIfNumericalString();

            Assert.True(result);
        }


       
        [Fact]
        public void RemoveLastCharacterTest()
        {
            var str = "gateways";
            var result = str.RemoveLastCharacter();

            Assert.Equal("gateway", result);
        }
        [Fact]
        public void RemoveLastCharacterTest_Negative()
        {
            var str = "gateways";
            var result = str.RemoveLastCharacter();

            Assert.Equal("gateways", result);
        }


        
        [Fact]
        public void GetWordCountTest()
        {
            var str = "Here I come";
            var result = str.GetWordCount();

            Assert.Equal(3, result);
        }
        [Fact]
        public void GetWordCountTest_Negative()
        {
            var str = "Here I come";
            var result = str.GetWordCount();

            Assert.Equal(4, result);
        }

       
        [Fact]
        public void ConvertToIntTest()
        {
            var str = "123";
            var result = str.ConvertToIntFromString();

            Assert.Equal(123, result);
        }
        [Fact]
        public void ConvertToIntTest_Negative()
        {
            var str = "xyz";
            var result = str.ConvertToIntFromString();

            Assert.Equal(123, result);
        }
    }
}
