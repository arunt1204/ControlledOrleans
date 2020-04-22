using Xunit;
using NekaraManaged.Client;
using Nekara.Models;
using System.Runtime.InteropServices;
using Orleans.TestingHost;

namespace CtrlTaskUnitTest
{
    public interface IHello : Orleans.IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }

    public class HelloGrain : Orleans.Grain, IHello
    {
        Task<string> IHello.SayHello(string greeting)
        {
            return Task.FromResult($"Hello, World");
        }
    }

    public class SayHello
    {
        [Fact]
        public async void SayHelloCorrectly()
        {
            var nekara = new NekaraManagedClient();
            NekaraManaged.Client.RuntimeEnvironment.scheduler.Value = nekara;
            nekara.Api.CreateSession();
            nekara.Api.Attach();

            var _t1 = new TestClusterBuilder();
            var cluster = _t1.Build();
            cluster.Deploy();

            var friend = cluster.GrainFactory.GetGrain<IHello>(0);

            var greeting = await friend.SayHello("Good morning, my friend!");

            cluster.StopAllSilos();

            Assert.Equal("Hello, World", greeting);
        }
    }
}
