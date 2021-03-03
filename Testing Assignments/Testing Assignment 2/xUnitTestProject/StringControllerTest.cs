using String_Operations_App.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace xUnitTestProject
{
    public class StringControllerTest
    {
        private StringController _stringController;

        public StringControllerTest()
        {
            _stringController = new StringController();
        }


        //change the case of string
        [Fact]
        public void ChangeCaseOfStringTest()
        {
            var str = "gateway";
            var result = _stringController.ChangeCaseOfString(str);

            Assert.Equal("GATEWAY", result);
        }
        [Fact]
        public void ChangeCaseOfStringTest_Negative()
        {
            var str = "gateway";
            var result = _stringController.ChangeCaseOfString(str);

            Assert.Equal("gateway", result);
        }


        //change every case of a string
        [Fact]
        public void ChangeCaseOfEveryCharacterTest()
        {
            var str = "gAtEwAy";
            var result = _stringController.ChangeCaseOfEveryCharacter(str);

            Assert.Equal("GaTeWaY", result);
        }
        [Fact]
        public void ChangeCaseOfEveryCharacterTest_Negative()
        {
            var str = "gAtEwAy";
            var result = _stringController.ChangeCaseOfEveryCharacter(str);

            Assert.Equal("gAtEwAy", result);
        }


        //change to title case
        [Fact]
        public void ChangeToTitleCaseTest()
        {
            var str = "here is my application";
            var result = _stringController.ChangeToTitleCase(str);

            Assert.Equal("Here Is My Application", result);
        }
        [Fact]
        public void ChangeToTitleCaseTest_Negative()
        {
            var str = "here is my application";
            var result = _stringController.ChangeToTitleCase(str);

            Assert.Equal("here is my application", result);
        }


        //check if the string is in lower case
        [Fact]
        public void CheckIsLowerTest()
        {
            var str = "gateway";
            var result = _stringController.CheckIsLower(str);

            Assert.True(result);
        }
        [Fact]
        public void CheckIsLowerTest_Negative()
        {
            var str = "gateway";
            var result = _stringController.CheckIsLower(str);

            Assert.False(result);
        }


        //check if the string is in upper case
        [Fact]
        public void CheckIsUpperTest()
        {
            var str = "GATEWAY";
            var result = _stringController.CheckIsUpper(str);

            Assert.True(result);
        }
        [Fact]
        public void CheckIsUpperTest_Negative()
        {
            var str = "gateway";
            var result = _stringController.CheckIsUpper(str);

            Assert.True(result);
        }

        //capitalize the string
        [Fact]
        public void CapitalizeStringTest()
        {
            var str = "gateway";
            var result = _stringController.CapitalizeString(str);

            Assert.Equal("Gateway",result);
        }
        [Fact]
        public void CapitalizeStringTest_Negative()
        {
            var str = "gateway";
            var result = _stringController.CapitalizeString(str);

            Assert.Equal("gateway", result);
        }


        //check whether the string can be converted to a numerical string
        [Fact]
        public void CheckIfNumericalStringTest()
        {
            var str = "123";
            var result = _stringController.CheckIfNumericalString(str);

            Assert.True(result);
        }
        [Fact]
        public void CheckIfNumericalStringTest_Negative()
        {
            var str = "gateway";
            var result = _stringController.CheckIfNumericalString(str);

            Assert.True(result);
        }


        //Removes the last characters from the string
        [Fact]
        public void RemoveLastCharacterTest()
        {
            var str = "gateways";
            var result = _stringController.RemoveLastCharacter(str);

            Assert.Equal("gateway",result);
        }
        [Fact]
        public void RemoveLastCharacterTest_Negative()
        {
            var str = "gateways";
            var result = _stringController.RemoveLastCharacter(str);

            Assert.Equal("gateways", result);
        }


        //count the words in a string
        [Fact]
        public void GetWordCountTest()
        {
            var str = "Here I come";
            var result = _stringController.GetWordCount(str);

            Assert.Equal(3, result);
        }
        [Fact]
        public void GetWordCountTest_Negative()
        {
            var str = "Here I come";
            var result = _stringController.GetWordCount(str);

            Assert.Equal(4, result);
        }

        //Convert string to integer
        [Fact]
        public void ConvertToIntTest()
        {
            var str = "123";
            var result = _stringController.ConvertToInt(str);

            Assert.Equal(123, result);
        }
        [Fact]
        public void ConvertToIntTest_Negative()
        {
            var str = "xyz";
            var result = _stringController.ConvertToInt(str);

            Assert.Equal(123, result);
        }
    }
}
