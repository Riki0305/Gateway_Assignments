using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment_1.ViewModel
{
    public class userProfileViewModel
    {
        public userProfileViewModel()
        {
            
        }
        public userProfileViewModel(string name)
        {
            this.UserName = name;
        }
        public string UserName { get; set; }
    }
}