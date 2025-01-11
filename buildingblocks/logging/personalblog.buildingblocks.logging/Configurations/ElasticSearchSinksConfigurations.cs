using Microsoft.Extensions.Configuration;

namespace personalblog.buildingblocks.logging.Configurations;

public class ElasticSearchSinksConfigurations
{
    //public static ElasticsearchSinkOptions LoadOptions(IConfiguration configurations)
    //{
    //    string elasticNodeurl = configurations["elastic:url"]!;
    //    string username = configurations["elastic:username"]!;
    //    string password = configurations["elastic:password"]!;
    //    string indexPrefix = configurations["elastic:indexPrefix"]!;

    //    var options = new ElasticsearchSinkOptions(new Uri(elasticNodeurl))
    //    {
    //        ModifyConnectionSettings = x => x.BasicAuthentication(username, password),
    //    };
    //    options.ModifyConnectionSettings = x => x.ServerCertificateValidationCallback((a, b, c, d) => true);

    //    return options;
    //}
}
