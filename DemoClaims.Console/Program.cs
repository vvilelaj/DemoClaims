using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoClaims.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup1();
            CheckCompatibility();

            System.Console.WriteLine();

            Setup2();
            CheckCompatibility();

            System.Console.Read();
        }

        private static void Setup1()
        {
            #region 1. Creating Claims

            // Custom Claim
            var nameClaim = new Claim("Name", "Victor Vilela");

            //Typed Claim
            var countryClaim = new Claim(ClaimTypes.Country, "Peru");

            // Custom Claim with namespace
            var floorClaim = new Claim("http://www.vvilelaj.com/building/floor", "Two");

            #endregion

            #region 2. Creating a Claims Collection

            var claimsCollection = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Victor") ,
                new Claim(ClaimTypes.Surname,"Vilela") ,
                new Claim(ClaimTypes.Email,"vilela_victor@hotmail.com"),
                new Claim(ClaimTypes.Role,"IT"),
                new Claim(ClaimTypes.Country,"Peru"),
                new Claim(ClaimTypes.Gender,"M"),
            };

            #endregion

            #region 3. Creating a IIdentity

            var claimsIdentity = new ClaimsIdentity(claimsCollection);
            System.Console.WriteLine($"IIdentity with claims collection is authenticated : {claimsIdentity.IsAuthenticated}");

            #endregion

            #region 4. Creating an authenticated IIdentity

            var claimsIdentityAuth = new ClaimsIdentity(claimsCollection, "My asp.net website");
            System.Console.WriteLine($"IIdentity with claims collection and authentication type is authenticated : {claimsIdentityAuth.IsAuthenticated}");

            #endregion

            #region 5. Creating and IPrincipal with Claims

            var principal = new ClaimsPrincipal(claimsIdentityAuth);
            System.Console.WriteLine($"IPrincipal from IIdentity is authenticated : {principal.Identity.IsAuthenticated}");

            #endregion

            #region 6. Setting the principal of current thread

            var principalAnterior = Thread.CurrentPrincipal;
            Thread.CurrentPrincipal = principal;

            #endregion
        }

        private static void Setup2()
        {
            #region 1. Creating Claims

            // Custom Claim
            var nameClaim = new Claim("Name", "Victor Vilela");

            //Typed Claim
            var countryClaim = new Claim(ClaimTypes.Country, "Peru");

            // Custom Claim with namespace
            var floorClaim = new Claim("http://www.vvilelaj.com/building/floor", "Two");

            #endregion

            #region 2. Creating a Claims Collection

            var claimsCollection = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"Victor") ,
                new Claim(ClaimTypes.Surname,"Vilela") ,
                new Claim(ClaimTypes.Email,"vilela_victor@hotmail.com"),
                new Claim(ClaimTypes.Role,"IT"),
                new Claim(ClaimTypes.Country,"Peru"),
                new Claim(ClaimTypes.Gender,"M"),
            };

            #endregion

            #region 3. Creating a IIdentity

            var claimsIdentity = new ClaimsIdentity(claimsCollection);
            System.Console.WriteLine($"IIdentity with claims collection is authenticated : {claimsIdentity.IsAuthenticated}");

            #endregion

            #region 4. Creating an authenticated IIdentity

            var claimsIdentityAuth = new ClaimsIdentity(claimsCollection, "My asp.net website",ClaimTypes.Email,ClaimTypes.Role);
            System.Console.WriteLine($"IIdentity with claims collection and authentication type is authenticated : {claimsIdentityAuth.IsAuthenticated}");

            #endregion

            #region 5. Creating and IPrincipal with Claims

            var principal = new ClaimsPrincipal(claimsIdentityAuth);
            System.Console.WriteLine($"IPrincipal from IIdentity is authenticated : {principal.Identity.IsAuthenticated}");

            #endregion

            #region 6. Setting the principal of current thread

            var principalAnterior = Thread.CurrentPrincipal;
            Thread.CurrentPrincipal = principal;

            #endregion
        }

        private static void CheckCompatibility()
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            System.Console.WriteLine($"Principal Identity Name : {principal.Identity.Name}");
            System.Console.WriteLine($"Principal Identity is in role IT : {principal.IsInRole("IT")}");


        }
    }
}
