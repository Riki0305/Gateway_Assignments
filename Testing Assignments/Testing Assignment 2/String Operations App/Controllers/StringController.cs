using String_Operations_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace String_Operations_App.Controllers
{
    public class StringController : ApiController
    {
        [HttpGet]
        [Route("api/ChangeCaseOfString/{str}")]
        public string ChangeCaseOfString(string str)
        {
            return str.ChangeCase();
        }

        [HttpGet]
        [Route("api/ChangeCaseOfEveryCharacter/{str}")]
        public string ChangeCaseOfEveryCharacter(string str)
        {
            return str.ChangeCaseOfCharacter();
        }

        [HttpGet]
        [Route("api/ChangeToTitleCase/{str}")]
        public string ChangeToTitleCase(string str)
        {
            return str.ChangeToTitleCase();
        }

        [HttpGet]
        [Route("api/CheckIsLower/{str}")]
        public bool CheckIsLower(string str)
        {
            return str.CheckIsLower();
        }

        [HttpGet]
        [Route("api/CheckIsUpper/{str}")]
        public bool CheckIsUpper(string str)
        {
            return str.CheckIsUpper();
        }


        [HttpGet]
        [Route("api/CapitalizeString/{str}")]
        public string CapitalizeString(string str)
        {
            return str.CapitalizeString();
        }

        [HttpGet]
        [Route("api/CheckIfNumericalString/{str}")]
        public bool CheckIfNumericalString(string str)
        {
            return str.CheckIfNumericalString();
        }

        [HttpGet]
        [Route("api/RemoveLastCharacter/{str}")]
        public string RemoveLastCharacter(string str)
        {
            return str.RemoveLastCharacter();
        }

        [HttpGet]
        [Route("api/GetWordCount/{str}")]
        public int GetWordCount(string str)
        {
            return str.GetWordCount();
        }

        [HttpGet]
        [Route("api/ConvertToInt/{str}")]
        public int ConvertToInt(string str)
        {
            return str.ConvertToIntFromString();
        }
    }
}
