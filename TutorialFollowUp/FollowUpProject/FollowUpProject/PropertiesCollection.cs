using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FollowUpProject
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName

    }
    class PropertiesCollection { 
    
            // auto implemented property
            public static IWebDriver driver { get; set; }
    }
}
