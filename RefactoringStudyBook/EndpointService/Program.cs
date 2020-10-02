using System;
using System.Reflection;

namespace EndpointService
{
    class Program
    {
        static void Main(string[] args)
        {

            //Type type = Assembly.LoadFrom(Environment.CurrentDirectory).GetType("Broading");

            var type = Type.GetType($"EndpointService.Broading, EndpointService");
            var endpoint = (IEndpoint)Activator.CreateInstance(type);

            Console.WriteLine(endpoint.AuthorizationUri);
            Console.WriteLine(endpoint.ScaMethodUri);

            Console.WriteLine("--------------------");

            //type = Assembly.LoadFrom(typeof(InternalTesting).Assembly.GetName().Name).GetType(typeof(InternalTesting).FullName);
            type = Type.GetType($"EndpointService.InternalTesting, EndpointService");
            endpoint = (IEndpoint)Activator.CreateInstance(type);

            Console.WriteLine(endpoint.AuthorizationUri);
            Console.WriteLine(endpoint.ScaMethodUri);

            Console.ReadLine();
        }

        
    }


    public interface IEndpoint
    {
        public string AuthorizationUri { get; }
        public string ScaMethodUri { get; }
    }
    public interface IBroading : IEndpoint { }

    public class Broading : IBroading
    {
        public string AuthorizationUri => "api/authorization";

        public string ScaMethodUri => "api/sca-method";
    }

    public interface IInternalTesting : IEndpoint { }

    public class InternalTesting : IInternalTesting
    {
        public string AuthorizationUri => "v2/authorization";

        public string ScaMethodUri => "v2/sca-method";
    }
}
