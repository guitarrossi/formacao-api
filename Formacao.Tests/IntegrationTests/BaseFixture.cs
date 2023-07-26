using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formacao.Tests.IntegrationTests
{
    public class BaseFixture
    {
        public StringContent GenerateStringContent(object response)
        {
            var json = JsonConvert.SerializeObject(response);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
