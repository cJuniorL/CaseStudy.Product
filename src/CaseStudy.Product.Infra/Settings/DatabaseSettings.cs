using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Product.Infra.Settings;

public class DatabaseSettings
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string Name { get; set; }
    public string Schema { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}
