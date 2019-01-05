using System.Web;

namespace Stilwill.Web.Code
{
    public class HttpUtils
    {
        public static bool IsLocal() {
            return HttpContext.Current.Request.UserHostAddress.StartsWith("192.168.1")
                || HttpContext.Current.Request.UserHostAddress.StartsWith("::1");  //Localhost
        }

        public static bool IpISInRange(string ipStringFrom = "192.168.1.0", string ipStringTo = "192.168.1.255")
        {
            string ipString = HttpContext.Current.Request.UserHostAddress;
            var ipBytes = System.Net.IPAddress.Parse(ipString).GetAddressBytes();
            int ip = System.BitConverter.ToInt32(ipBytes, 0);

            var ipBytesFrom = System.Net.IPAddress.Parse(ipStringFrom).GetAddressBytes();
            int ipFrom = System.BitConverter.ToInt32(ipBytesFrom, 0);
            
            var ipBytesTo = System.Net.IPAddress.Parse(ipStringTo).GetAddressBytes();
            int ipTo = System.BitConverter.ToInt32(ipBytesFrom, 0);

            return ipFrom >= ip && ip <= ipTo;
        }
    }
}