using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{
    public class SharedService
    {
        public void InitializeAppShell()
        {

            if (Application.Current?.Windows.Count > 0)
            {
                var currentPage = Application.Current.Windows[0].Page;
                if (currentPage is not AppShell)
                {
                    Application.Current.Windows[0].Page = new AppShell();
                }
            }
            else
            {

            }
        }
    }
}
