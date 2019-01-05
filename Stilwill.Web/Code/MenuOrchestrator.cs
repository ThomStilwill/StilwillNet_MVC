using Stilwill.Web.Models;
using System.Collections.Generic;

namespace Stilwill.Web.Code
{
    public class MenuOrchestrator
    {

        public static List<Menu> GetMenu()
        {
            if (!HttpUtils.IsLocal())
            {
                return null;
            }

            return new List<Menu> { new Menu { Title = "Peoples United Bank", Href = "https://www.peoples.com" },
                                    new Menu { Title = "Fidelity", Href = "https://www.fidelity.com/" },
                                    new Menu { Title = "My UHC", Href = "https://www.myuhc.com" },
                                    new Menu { Title = "Express Scripts", Href = "https://www.express-scripts.com" },
                                    new Menu { Title = "Starling Physicians (Follow My Health)", Href = "https://cmgmds.followmyhealth.com" },
            };
        }
    }
}