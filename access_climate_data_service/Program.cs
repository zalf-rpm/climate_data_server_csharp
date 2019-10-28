using System;
using Capnp.Rpc;
using Mas.Rpc;
using System.Threading.Tasks;

namespace access_climate_data_service
{
    class Program
    {
        public static int TcpPort = 49153;

        static async Task Main(string[] args)
        {
            //var adminMaster = new TcpRpcClient("10.10.24.186", 8000);
            //var client = new TcpRpcClient("localhost", TcpPort);

            using (TcpRpcClient csvTimeSeriesClient = new TcpRpcClient("localhost", 11000),
                adminMasterClient = new TcpRpcClient("10.10.24.186", 8000))

            //using (client)
            {
                await Task.WhenAll(csvTimeSeriesClient.WhenConnected, adminMasterClient.WhenConnected);

                //csv_time_series = capnp.TwoPartyClient("localhost:11000").bootstrap().cast_as(
                //climate_data_capnp.Climate.TimeSeries)
                var adminMaster = adminMasterClient.GetMain<Cluster.IAdminMaster>();
                var factories = await adminMaster.AvailableModels();
                if(factories.Count > 0)
                {
                    var factory = factories[0];
                    var instanceCapHolder = factory.NewInstance().Eager<Mas.Rpc.Common.ICapHolder<object>>();
                    var envInstance = ((BareProxy)(await instanceCapHolder.Cap())).Cast<Mas.Rpc.Model.IEnvInstance>(true);
                    //var envInstance = ((BareProxy)(await instanceCapHolder.Cap())).Cast<Mas.Rpc.Model.IEnvInstance>(true);
                    var infos = await envInstance.Info();
                    Console.WriteLine(infos.ToString());
                    //modelRes.PseudoEager<Mas.Rpc.Model.IEnvInstance>();
                    //var x = modelRes.PseudoEager();

                    Console.WriteLine("Hello World!");

                    /*
                    auto monica = modelRes.getCap().getAs<rpc::Model::EnvInstance>();
                    //auto monica = cap.getAs<rpc::Model::EnvInstance>();
                    //auto monica = capHolder.capRequest().send().wait(waitScope).getCap(); //<rpc::Model::EnvInstance>().;
                    //auto monicaId = monica.infoRequest().send().wait(waitScope).getInfo().getId();
                    monica.infoRequest().send().then([](auto && res) {
                        cout << "monicaId: " << res.getInfo().getId().cStr() << endl;
                    }).wait(waitScope);
                    //auto monicaId = monicaRes.getInfo().getId().cStr();
                    //cout << "monicaId: " << monicaId << endl;
                    //auto sturdyRef = capHolder.saveRequest().send().wait(waitScope).getSturdyRef();
                    instanceCapHolder.saveRequest().send().then([](auto && res) {
                        cout << "sturdyRef: " << res.getSturdyRef().cStr() << endl;
                    }).wait(waitScope);
                    //auto sturdyRefP = instanceCapHolder.saveRequest().send().wait(waitScope);// .getSturdyRef();
                    */

                }

                /*
                var csvTimeSeries = csvTimeSeriesClient.GetMain<Climate.ITimeSeries>();
                var header = csvTimeSeries.Header();
                header.Wait();
                var elems = header.Result;
                foreach(var elem in elems)
                {
                    Console.WriteLine(elem);
                }
                //csvTimeSeries.WhenResolved.Wait(3000);
                */

                //SpinWait.SpinUntil(() => server.ConnectionCount > 0, MediumTimeout);
                //Assert.AreEqual(1, server.ConnectionCount);

                //server.Main = new ProvidedCapabilityMock();
                //var main = client.GetMain<BareProxy>();
                //var resolving = main as IResolvingCapability;
                //Assert.IsTrue(resolving.WhenResolved.Wait(MediumTimeout));
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
