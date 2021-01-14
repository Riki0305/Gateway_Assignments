using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Web_Api_Final_Assignment.Controllers;
using WebApiAssignment.BAL;
using WebApiAssignment.BAL.Interface;

namespace Web_Api_Final_Assignment
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {
       
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            

            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString( Convert.FromBase64String(authenticationToken));
                string[] userpassArray = decodedAuthenticationToken.Split(':');
                string username = userpassArray[0];
                string password = userpassArray[1];

                HotelSecurity security = new HotelSecurity();
                if (security.Login(username,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}