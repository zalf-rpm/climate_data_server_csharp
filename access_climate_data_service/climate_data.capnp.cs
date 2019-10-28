using Capnp;
using Capnp.Rpc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mas.Rpc
{
    [TypeId(0xda39f0fcea893370UL)]
    public class Climate : ICapnpSerializable
    {
        public const UInt64 typeId = 0xda39f0fcea893370UL;
        void ICapnpSerializable.Deserialize(DeserializerState arg_)
        {
            var reader = READER.create(arg_);
            applyDefaults();
        }

        public void serialize(WRITER writer)
        {
        }

        void ICapnpSerializable.Serialize(SerializerState arg_)
        {
            serialize(arg_.Rewrap<WRITER>());
        }

        public void applyDefaults()
        {
        }

        public struct READER
        {
            readonly DeserializerState ctx;
            public READER(DeserializerState ctx)
            {
                this.ctx = ctx;
            }

            public static READER create(DeserializerState ctx) => new READER(ctx);
            public static implicit operator DeserializerState(READER reader) => reader.ctx;
            public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
        }

        public class WRITER : SerializerState
        {
            public WRITER()
            {
                this.SetStruct(0, 0);
            }
        }

        [TypeId(0x94f8be2e964f70c1UL)]
        public enum Element : ushort
        {
            tmin,
            tavg,
            tmax,
            precip,
            globrad,
            wind,
            sunhours,
            cloudamount,
            relhumid,
            airpress,
            vaporpress,
            co2,
            o3,
            et0,
            dewpointTemp
        }

        [TypeId(0xea67c62339c57fddUL), Proxy(typeof(Station_Proxy)), Skeleton(typeof(Station_Skeleton))]
        public interface IStation : Mas.Rpc.Common.IIdentifiable
        {
            Task<Mas.Rpc.Common.IdInformation> SimulationInfo(CancellationToken cancellationToken_ = default);
            Task<float> HeightNN(CancellationToken cancellationToken_ = default);
            Task<Mas.Rpc.Geo.Coord> GeoCoord(CancellationToken cancellationToken_ = default);
            Task<IReadOnlyList<Mas.Rpc.Climate.ITimeSeries>> AllTimeSeries(CancellationToken cancellationToken_ = default);
            Task<Mas.Rpc.Climate.ITimeSeries> TimeSeriesFor(string scenarioId, string realizationId, CancellationToken cancellationToken_ = default);
        }

        public class Station_Proxy : Proxy, IStation
        {
            public async Task<Mas.Rpc.Common.IdInformation> SimulationInfo(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Params_simulationInfo.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Station.Params_simulationInfo()
                {};
                arg_.serialize(in_);
                var d_ = await Call(16890686782071734237UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Station.Result_simulationInfo>(d_);
                return (r_.SimInfo);
            }

            public async Task<float> HeightNN(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Params_heightNN.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Station.Params_heightNN()
                {};
                arg_.serialize(in_);
                var d_ = await Call(16890686782071734237UL, 1, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Station.Result_heightNN>(d_);
                return (r_.HeightNN);
            }

            public async Task<Mas.Rpc.Geo.Coord> GeoCoord(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Params_geoCoord.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Station.Params_geoCoord()
                {};
                arg_.serialize(in_);
                var d_ = await Call(16890686782071734237UL, 2, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Station.Result_geoCoord>(d_);
                return (r_.GeoCoord);
            }

            public Task<IReadOnlyList<Mas.Rpc.Climate.ITimeSeries>> AllTimeSeries(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Params_allTimeSeries.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Station.Params_allTimeSeries()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(16890686782071734237UL, 3, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Station.Result_allTimeSeries>(d_);
                    return (r_.AllTimeSeries);
                }

                );
            }

            public Task<Mas.Rpc.Climate.ITimeSeries> TimeSeriesFor(string scenarioId, string realizationId, CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Params_timeSeriesFor.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Station.Params_timeSeriesFor()
                {ScenarioId = scenarioId, RealizationId = realizationId};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(16890686782071734237UL, 4, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Station.Result_timeSeriesFor>(d_);
                    return (r_.TimeSeries);
                }

                );
            }

            public async Task<Mas.Rpc.Common.IdInformation> Info(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Common.Identifiable.Params_info.WRITER>();
                var arg_ = new Mas.Rpc.Common.Identifiable.Params_info()
                {};
                arg_.serialize(in_);
                var d_ = await Call(15298557119806335142UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Common.Identifiable.Result_info>(d_);
                return (r_.Info);
            }
        }

        public class Station_Skeleton : Skeleton<IStation>
        {
            public Station_Skeleton()
            {
                SetMethodTable(SimulationInfo, HeightNN, GeoCoord, AllTimeSeries, TimeSeriesFor);
            }

            public override ulong InterfaceId => 16890686782071734237UL;
            Task<AnswerOrCounterquestion> SimulationInfo(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.SimulationInfo(cancellationToken_), simInfo =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Result_simulationInfo.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Station.Result_simulationInfo{SimInfo = simInfo};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> HeightNN(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.HeightNN(cancellationToken_), heightNN =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Result_heightNN.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Station.Result_heightNN{HeightNN = heightNN};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> GeoCoord(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.GeoCoord(cancellationToken_), geoCoord =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Result_geoCoord.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Station.Result_geoCoord{GeoCoord = geoCoord};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> AllTimeSeries(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.AllTimeSeries(cancellationToken_), allTimeSeries =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Result_allTimeSeries.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Station.Result_allTimeSeries{AllTimeSeries = allTimeSeries};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> TimeSeriesFor(DeserializerState d_, CancellationToken cancellationToken_)
            {
                var in_ = CapnpSerializable.Create<Mas.Rpc.Climate.Station.Params_timeSeriesFor>(d_);
                return Impatient.MaybeTailCall(Impl.TimeSeriesFor(in_.ScenarioId, in_.RealizationId, cancellationToken_), timeSeries =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Station.Result_timeSeriesFor.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Station.Result_timeSeriesFor{TimeSeries = timeSeries};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }
        }

        public static class Station
        {
            [TypeId(0x9ffe9b3a4f9ba168UL)]
            public class Params_simulationInfo : ICapnpSerializable
            {
                public const UInt64 typeId = 0x9ffe9b3a4f9ba168UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xbaf0760f2bc7f0e3UL)]
            public class Result_simulationInfo : ICapnpSerializable
            {
                public const UInt64 typeId = 0xbaf0760f2bc7f0e3UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    SimInfo = CapnpSerializable.Create<Mas.Rpc.Common.IdInformation>(reader.SimInfo);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    SimInfo?.serialize(writer.SimInfo);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Common.IdInformation SimInfo
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Common.IdInformation.READER SimInfo => ctx.ReadStruct(0, Mas.Rpc.Common.IdInformation.READER.create);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Common.IdInformation.WRITER SimInfo
                    {
                        get => BuildPointer<Mas.Rpc.Common.IdInformation.WRITER>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xda2728ad65227286UL)]
            public class Params_heightNN : ICapnpSerializable
            {
                public const UInt64 typeId = 0xda2728ad65227286UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xe2db1189d00d3b4aUL)]
            public class Result_heightNN : ICapnpSerializable
            {
                public const UInt64 typeId = 0xe2db1189d00d3b4aUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    HeightNN = reader.HeightNN;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.HeightNN = HeightNN;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public float HeightNN
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public float HeightNN => ctx.ReadDataFloat(0UL, 0F);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(1, 0);
                    }

                    public float HeightNN
                    {
                        get => this.ReadDataFloat(0UL, 0F);
                        set => this.WriteData(0UL, value, 0F);
                    }
                }
            }

            [TypeId(0xe190162c57dafc23UL)]
            public class Params_geoCoord : ICapnpSerializable
            {
                public const UInt64 typeId = 0xe190162c57dafc23UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0x91b00bd8ef269650UL)]
            public class Result_geoCoord : ICapnpSerializable
            {
                public const UInt64 typeId = 0x91b00bd8ef269650UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    GeoCoord = CapnpSerializable.Create<Mas.Rpc.Geo.Coord>(reader.GeoCoord);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    GeoCoord?.serialize(writer.GeoCoord);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Geo.Coord GeoCoord
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Geo.Coord.READER GeoCoord => ctx.ReadStruct(0, Mas.Rpc.Geo.Coord.READER.create);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Geo.Coord.WRITER GeoCoord
                    {
                        get => BuildPointer<Mas.Rpc.Geo.Coord.WRITER>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xa8c70892267351bdUL)]
            public class Params_allTimeSeries : ICapnpSerializable
            {
                public const UInt64 typeId = 0xa8c70892267351bdUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xae359a0ed256ef98UL)]
            public class Result_allTimeSeries : ICapnpSerializable
            {
                public const UInt64 typeId = 0xae359a0ed256ef98UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    AllTimeSeries = reader.AllTimeSeries;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.AllTimeSeries.Init(AllTimeSeries);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<Mas.Rpc.Climate.ITimeSeries> AllTimeSeries
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<Mas.Rpc.Climate.ITimeSeries> AllTimeSeries => ctx.ReadCapList<Mas.Rpc.Climate.ITimeSeries>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfCapsSerializer<Mas.Rpc.Climate.ITimeSeries> AllTimeSeries
                    {
                        get => BuildPointer<ListOfCapsSerializer<Mas.Rpc.Climate.ITimeSeries>>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xd8b63f3a8e4d605dUL)]
            public class Params_timeSeriesFor : ICapnpSerializable
            {
                public const UInt64 typeId = 0xd8b63f3a8e4d605dUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    ScenarioId = reader.ScenarioId;
                    RealizationId = reader.RealizationId;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.ScenarioId = ScenarioId;
                    writer.RealizationId = RealizationId;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public string ScenarioId
                {
                    get;
                    set;
                }

                public string RealizationId
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public string ScenarioId => ctx.ReadText(0, "");
                    public string RealizationId => ctx.ReadText(1, "");
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 2);
                    }

                    public string ScenarioId
                    {
                        get => this.ReadText(0, "");
                        set => this.WriteText(0, value, "");
                    }

                    public string RealizationId
                    {
                        get => this.ReadText(1, "");
                        set => this.WriteText(1, value, "");
                    }
                }
            }

            [TypeId(0xa8053e2875392e14UL)]
            public class Result_timeSeriesFor : ICapnpSerializable
            {
                public const UInt64 typeId = 0xa8053e2875392e14UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    TimeSeries = reader.TimeSeries;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.TimeSeries = TimeSeries;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.ITimeSeries TimeSeries
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.ITimeSeries TimeSeries => ctx.ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Climate.ITimeSeries TimeSeries
                    {
                        get => ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                        set => LinkObject(0, value);
                    }
                }
            }
        }

        [TypeId(0xc95a8b5c828c96edUL)]
        public enum TimeResolution : ushort
        {
            daily,
            hourly
        }

        [TypeId(0xc90a2df328812400UL), Proxy(typeof(TimeSeries_Proxy)), Skeleton(typeof(TimeSeries_Skeleton))]
        public interface ITimeSeries : IDisposable
        {
            Task<Mas.Rpc.Climate.TimeResolution> Resolution(CancellationToken cancellationToken_ = default);
            Task<(Mas.Rpc.Common.Date, Mas.Rpc.Common.Date)> Range(CancellationToken cancellationToken_ = default);
            Task<IReadOnlyList<Mas.Rpc.Climate.Element>> Header(CancellationToken cancellationToken_ = default);
            Task<IReadOnlyList<IReadOnlyList<float>>> Data(CancellationToken cancellationToken_ = default);
            Task<IReadOnlyList<IReadOnlyList<float>>> DataT(CancellationToken cancellationToken_ = default);
            Task<Mas.Rpc.Climate.ITimeSeries> Subrange(Mas.Rpc.Common.Date @from, Mas.Rpc.Common.Date to, CancellationToken cancellationToken_ = default);
            Task<Mas.Rpc.Climate.ITimeSeries> Subheader(IReadOnlyList<Mas.Rpc.Climate.Element> elements, CancellationToken cancellationToken_ = default);
        }

        public class TimeSeries_Proxy : Proxy, ITimeSeries
        {
            public async Task<Mas.Rpc.Climate.TimeResolution> Resolution(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_resolution.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_resolution()
                {};
                arg_.serialize(in_);
                var d_ = await Call(14486441673770476544UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_resolution>(d_);
                return (r_.Resolution);
            }

            public async Task<(Mas.Rpc.Common.Date, Mas.Rpc.Common.Date)> Range(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_range.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_range()
                {};
                arg_.serialize(in_);
                var d_ = await Call(14486441673770476544UL, 1, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_range>(d_);
                return (r_.StartDate, r_.EndDate);
            }

            public async Task<IReadOnlyList<Mas.Rpc.Climate.Element>> Header(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_header.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_header()
                {};
                arg_.serialize(in_);
                var d_ = await Call(14486441673770476544UL, 2, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_header>(d_);
                return (r_.Header);
            }

            public async Task<IReadOnlyList<IReadOnlyList<float>>> Data(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_data.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_data()
                {};
                arg_.serialize(in_);
                var d_ = await Call(14486441673770476544UL, 3, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_data>(d_);
                return (r_.Data);
            }

            public async Task<IReadOnlyList<IReadOnlyList<float>>> DataT(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_dataT.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_dataT()
                {};
                arg_.serialize(in_);
                var d_ = await Call(14486441673770476544UL, 4, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_dataT>(d_);
                return (r_.Data);
            }

            public Task<Mas.Rpc.Climate.ITimeSeries> Subrange(Mas.Rpc.Common.Date @from, Mas.Rpc.Common.Date to, CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_subrange.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_subrange()
                {From = @from, To = to};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(14486441673770476544UL, 5, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_subrange>(d_);
                    return (r_.TimeSeries);
                }

                );
            }

            public Task<Mas.Rpc.Climate.ITimeSeries> Subheader(IReadOnlyList<Mas.Rpc.Climate.Element> elements, CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Params_subheader.WRITER>();
                var arg_ = new Mas.Rpc.Climate.TimeSeries.Params_subheader()
                {Elements = elements};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(14486441673770476544UL, 6, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Result_subheader>(d_);
                    return (r_.TimeSeries);
                }

                );
            }
        }

        public class TimeSeries_Skeleton : Skeleton<ITimeSeries>
        {
            public TimeSeries_Skeleton()
            {
                SetMethodTable(Resolution, Range, Header, Data, DataT, Subrange, Subheader);
            }

            public override ulong InterfaceId => 14486441673770476544UL;
            Task<AnswerOrCounterquestion> Resolution(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Resolution(cancellationToken_), resolution =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_resolution.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_resolution{Resolution = resolution};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Range(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Range(cancellationToken_), (startDate, endDate) =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_range.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_range{StartDate = startDate, EndDate = endDate};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Header(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Header(cancellationToken_), header =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_header.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_header{Header = header};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Data(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Data(cancellationToken_), data =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_data.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_data{Data = data};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> DataT(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.DataT(cancellationToken_), data =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_dataT.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_dataT{Data = data};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Subrange(DeserializerState d_, CancellationToken cancellationToken_)
            {
                var in_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Params_subrange>(d_);
                return Impatient.MaybeTailCall(Impl.Subrange(in_.From, in_.To, cancellationToken_), timeSeries =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_subrange.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_subrange{TimeSeries = timeSeries};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Subheader(DeserializerState d_, CancellationToken cancellationToken_)
            {
                var in_ = CapnpSerializable.Create<Mas.Rpc.Climate.TimeSeries.Params_subheader>(d_);
                return Impatient.MaybeTailCall(Impl.Subheader(in_.Elements, cancellationToken_), timeSeries =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.TimeSeries.Result_subheader.WRITER>();
                    var r_ = new Mas.Rpc.Climate.TimeSeries.Result_subheader{TimeSeries = timeSeries};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }
        }

        public static class TimeSeries
        {
            [TypeId(0xaad518f935e5db79UL)]
            public class Params_resolution : ICapnpSerializable
            {
                public const UInt64 typeId = 0xaad518f935e5db79UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0x82ac0eafa3a057feUL)]
            public class Result_resolution : ICapnpSerializable
            {
                public const UInt64 typeId = 0x82ac0eafa3a057feUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Resolution = reader.Resolution;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Resolution = Resolution;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.TimeResolution Resolution
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.TimeResolution Resolution => (Mas.Rpc.Climate.TimeResolution)ctx.ReadDataUShort(0UL, (ushort)0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(1, 0);
                    }

                    public Mas.Rpc.Climate.TimeResolution Resolution
                    {
                        get => (Mas.Rpc.Climate.TimeResolution)this.ReadDataUShort(0UL, (ushort)0);
                        set => this.WriteData(0UL, (ushort)value, (ushort)0);
                    }
                }
            }

            [TypeId(0xde40c958c5f3a2caUL)]
            public class Params_range : ICapnpSerializable
            {
                public const UInt64 typeId = 0xde40c958c5f3a2caUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0x92cc2a26717f9ae8UL)]
            public class Result_range : ICapnpSerializable
            {
                public const UInt64 typeId = 0x92cc2a26717f9ae8UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    StartDate = CapnpSerializable.Create<Mas.Rpc.Common.Date>(reader.StartDate);
                    EndDate = CapnpSerializable.Create<Mas.Rpc.Common.Date>(reader.EndDate);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    StartDate?.serialize(writer.StartDate);
                    EndDate?.serialize(writer.EndDate);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Common.Date StartDate
                {
                    get;
                    set;
                }

                public Mas.Rpc.Common.Date EndDate
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Common.Date.READER StartDate => ctx.ReadStruct(0, Mas.Rpc.Common.Date.READER.create);
                    public Mas.Rpc.Common.Date.READER EndDate => ctx.ReadStruct(1, Mas.Rpc.Common.Date.READER.create);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 2);
                    }

                    public Mas.Rpc.Common.Date.WRITER StartDate
                    {
                        get => BuildPointer<Mas.Rpc.Common.Date.WRITER>(0);
                        set => Link(0, value);
                    }

                    public Mas.Rpc.Common.Date.WRITER EndDate
                    {
                        get => BuildPointer<Mas.Rpc.Common.Date.WRITER>(1);
                        set => Link(1, value);
                    }
                }
            }

            [TypeId(0x8c3caae5890d0734UL)]
            public class Params_header : ICapnpSerializable
            {
                public const UInt64 typeId = 0x8c3caae5890d0734UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0x9b93bf5f058d8499UL)]
            public class Result_header : ICapnpSerializable
            {
                public const UInt64 typeId = 0x9b93bf5f058d8499UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Header = reader.Header;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Header.Init(Header);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<Mas.Rpc.Climate.Element> Header
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<Mas.Rpc.Climate.Element> Header => ctx.ReadList(0).CastEnums(_0 => (Mas.Rpc.Climate.Element)_0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfPrimitivesSerializer<Mas.Rpc.Climate.Element> Header
                    {
                        get => BuildPointer<ListOfPrimitivesSerializer<Mas.Rpc.Climate.Element>>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0x9a820d6b481d6349UL)]
            public class Params_data : ICapnpSerializable
            {
                public const UInt64 typeId = 0x9a820d6b481d6349UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0x94778be55214f269UL)]
            public class Result_data : ICapnpSerializable
            {
                public const UInt64 typeId = 0x94778be55214f269UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Data = reader.Data;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Data.Init(Data, (_s2, _v2) => _s2.Init(_v2));
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<IReadOnlyList<float>> Data
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<IReadOnlyList<float>> Data => ctx.ReadList(0).Cast(_0 => _0.RequireList().CastFloat());
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfPointersSerializer<ListOfPrimitivesSerializer<float>> Data
                    {
                        get => BuildPointer<ListOfPointersSerializer<ListOfPrimitivesSerializer<float>>>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xb83dd1590a49e75eUL)]
            public class Params_dataT : ICapnpSerializable
            {
                public const UInt64 typeId = 0xb83dd1590a49e75eUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xc8d0f917b7ab4b28UL)]
            public class Result_dataT : ICapnpSerializable
            {
                public const UInt64 typeId = 0xc8d0f917b7ab4b28UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Data = reader.Data;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Data.Init(Data, (_s2, _v2) => _s2.Init(_v2));
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<IReadOnlyList<float>> Data
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<IReadOnlyList<float>> Data => ctx.ReadList(0).Cast(_0 => _0.RequireList().CastFloat());
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfPointersSerializer<ListOfPrimitivesSerializer<float>> Data
                    {
                        get => BuildPointer<ListOfPointersSerializer<ListOfPrimitivesSerializer<float>>>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xb44a4f86b0caa0e3UL)]
            public class Params_subrange : ICapnpSerializable
            {
                public const UInt64 typeId = 0xb44a4f86b0caa0e3UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    From = CapnpSerializable.Create<Mas.Rpc.Common.Date>(reader.From);
                    To = CapnpSerializable.Create<Mas.Rpc.Common.Date>(reader.To);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    From?.serialize(writer.From);
                    To?.serialize(writer.To);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Common.Date From
                {
                    get;
                    set;
                }

                public Mas.Rpc.Common.Date To
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Common.Date.READER From => ctx.ReadStruct(0, Mas.Rpc.Common.Date.READER.create);
                    public Mas.Rpc.Common.Date.READER To => ctx.ReadStruct(1, Mas.Rpc.Common.Date.READER.create);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 2);
                    }

                    public Mas.Rpc.Common.Date.WRITER From
                    {
                        get => BuildPointer<Mas.Rpc.Common.Date.WRITER>(0);
                        set => Link(0, value);
                    }

                    public Mas.Rpc.Common.Date.WRITER To
                    {
                        get => BuildPointer<Mas.Rpc.Common.Date.WRITER>(1);
                        set => Link(1, value);
                    }
                }
            }

            [TypeId(0xee6d5948a0bf5e04UL)]
            public class Result_subrange : ICapnpSerializable
            {
                public const UInt64 typeId = 0xee6d5948a0bf5e04UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    TimeSeries = reader.TimeSeries;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.TimeSeries = TimeSeries;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.ITimeSeries TimeSeries
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.ITimeSeries TimeSeries => ctx.ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Climate.ITimeSeries TimeSeries
                    {
                        get => ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                        set => LinkObject(0, value);
                    }
                }
            }

            [TypeId(0xf2dedc128498ceadUL)]
            public class Params_subheader : ICapnpSerializable
            {
                public const UInt64 typeId = 0xf2dedc128498ceadUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Elements = reader.Elements;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Elements.Init(Elements);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<Mas.Rpc.Climate.Element> Elements
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<Mas.Rpc.Climate.Element> Elements => ctx.ReadList(0).CastEnums(_0 => (Mas.Rpc.Climate.Element)_0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfPrimitivesSerializer<Mas.Rpc.Climate.Element> Elements
                    {
                        get => BuildPointer<ListOfPrimitivesSerializer<Mas.Rpc.Climate.Element>>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xb29381479fe30ecdUL)]
            public class Result_subheader : ICapnpSerializable
            {
                public const UInt64 typeId = 0xb29381479fe30ecdUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    TimeSeries = reader.TimeSeries;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.TimeSeries = TimeSeries;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.ITimeSeries TimeSeries
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.ITimeSeries TimeSeries => ctx.ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Climate.ITimeSeries TimeSeries
                    {
                        get => ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                        set => LinkObject(0, value);
                    }
                }
            }
        }

        [TypeId(0x9a6cbdf7826fcb50UL), Proxy(typeof(Test_Proxy)), Skeleton(typeof(Test_Skeleton))]
        public interface ITest : IDisposable
        {
            Task<Mas.Rpc.Common.ICapHolder<object>> TimeSeries(CancellationToken cancellationToken_ = default);
        }

        public class Test_Proxy : Proxy, ITest
        {
            public Task<Mas.Rpc.Common.ICapHolder<object>> TimeSeries(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Test.Params_timeSeries.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Test.Params_timeSeries()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(11127477650068589392UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Test.Result_timeSeries>(d_);
                    return (r_.CapHolder);
                }

                );
            }
        }

        public class Test_Skeleton : Skeleton<ITest>
        {
            public Test_Skeleton()
            {
                SetMethodTable(TimeSeries);
            }

            public override ulong InterfaceId => 11127477650068589392UL;
            Task<AnswerOrCounterquestion> TimeSeries(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.TimeSeries(cancellationToken_), capHolder =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Test.Result_timeSeries.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Test.Result_timeSeries{CapHolder = capHolder};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }
        }

        public static class Test
        {
            [TypeId(0xf25a109a65e8a126UL)]
            public class Params_timeSeries : ICapnpSerializable
            {
                public const UInt64 typeId = 0xf25a109a65e8a126UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xe5086a31997b8464UL)]
            public class Result_timeSeries : ICapnpSerializable
            {
                public const UInt64 typeId = 0xe5086a31997b8464UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    CapHolder = reader.CapHolder;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.CapHolder = CapHolder;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Common.ICapHolder<object> CapHolder
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Common.ICapHolder<object> CapHolder => ctx.ReadCap<Mas.Rpc.Common.ICapHolder<object>>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Common.ICapHolder<object> CapHolder
                    {
                        get => ReadCap<Mas.Rpc.Common.ICapHolder<object>>(0);
                        set => LinkObject(0, value);
                    }
                }
            }
        }

        [TypeId(0x8f2a480d441b3703UL), Proxy(typeof(Simulation_Proxy)), Skeleton(typeof(Simulation_Skeleton))]
        public interface ISimulation : Mas.Rpc.Common.IIdentifiable
        {
            Task<IReadOnlyList<Mas.Rpc.Climate.IScenario>> Scenarios(CancellationToken cancellationToken_ = default);
            Task<IReadOnlyList<Mas.Rpc.Climate.IStation>> Stations(CancellationToken cancellationToken_ = default);
        }

        public class Simulation_Proxy : Proxy, ISimulation
        {
            public Task<IReadOnlyList<Mas.Rpc.Climate.IScenario>> Scenarios(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Simulation.Params_scenarios.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Simulation.Params_scenarios()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(10316137118259951363UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Simulation.Result_scenarios>(d_);
                    return (r_.Scenarios);
                }

                );
            }

            public Task<IReadOnlyList<Mas.Rpc.Climate.IStation>> Stations(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Simulation.Params_stations.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Simulation.Params_stations()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(10316137118259951363UL, 1, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Simulation.Result_stations>(d_);
                    return (r_.Stations);
                }

                );
            }

            public async Task<Mas.Rpc.Common.IdInformation> Info(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Common.Identifiable.Params_info.WRITER>();
                var arg_ = new Mas.Rpc.Common.Identifiable.Params_info()
                {};
                arg_.serialize(in_);
                var d_ = await Call(15298557119806335142UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Common.Identifiable.Result_info>(d_);
                return (r_.Info);
            }
        }

        public class Simulation_Skeleton : Skeleton<ISimulation>
        {
            public Simulation_Skeleton()
            {
                SetMethodTable(Scenarios, Stations);
            }

            public override ulong InterfaceId => 10316137118259951363UL;
            Task<AnswerOrCounterquestion> Scenarios(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Scenarios(cancellationToken_), scenarios =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Simulation.Result_scenarios.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Simulation.Result_scenarios{Scenarios = scenarios};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Stations(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Stations(cancellationToken_), stations =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Simulation.Result_stations.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Simulation.Result_stations{Stations = stations};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }
        }

        public static class Simulation
        {
            [TypeId(0x8e21145dc8f6fa5aUL)]
            public class Params_scenarios : ICapnpSerializable
            {
                public const UInt64 typeId = 0x8e21145dc8f6fa5aUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xb1d863ffcd0964afUL)]
            public class Result_scenarios : ICapnpSerializable
            {
                public const UInt64 typeId = 0xb1d863ffcd0964afUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Scenarios = reader.Scenarios;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Scenarios.Init(Scenarios);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<Mas.Rpc.Climate.IScenario> Scenarios
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<Mas.Rpc.Climate.IScenario> Scenarios => ctx.ReadCapList<Mas.Rpc.Climate.IScenario>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfCapsSerializer<Mas.Rpc.Climate.IScenario> Scenarios
                    {
                        get => BuildPointer<ListOfCapsSerializer<Mas.Rpc.Climate.IScenario>>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xa5dcd34a6618139dUL)]
            public class Params_stations : ICapnpSerializable
            {
                public const UInt64 typeId = 0xa5dcd34a6618139dUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xd15b4d681308b807UL)]
            public class Result_stations : ICapnpSerializable
            {
                public const UInt64 typeId = 0xd15b4d681308b807UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Stations = reader.Stations;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Stations.Init(Stations);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<Mas.Rpc.Climate.IStation> Stations
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<Mas.Rpc.Climate.IStation> Stations => ctx.ReadCapList<Mas.Rpc.Climate.IStation>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfCapsSerializer<Mas.Rpc.Climate.IStation> Stations
                    {
                        get => BuildPointer<ListOfCapsSerializer<Mas.Rpc.Climate.IStation>>(0);
                        set => Link(0, value);
                    }
                }
            }
        }

        [TypeId(0xeda5978071f9baadUL), Proxy(typeof(Scenario_Proxy)), Skeleton(typeof(Scenario_Skeleton))]
        public interface IScenario : Mas.Rpc.Common.IIdentifiable
        {
            Task<Mas.Rpc.Climate.ISimulation> Simulation(CancellationToken cancellationToken_ = default);
            Task<IReadOnlyList<Mas.Rpc.Climate.IRealization>> Realizations(CancellationToken cancellationToken_ = default);
        }

        public class Scenario_Proxy : Proxy, IScenario
        {
            public Task<Mas.Rpc.Climate.ISimulation> Simulation(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Scenario.Params_simulation.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Scenario.Params_simulation()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(17124259736069978797UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Scenario.Result_simulation>(d_);
                    return (r_.Simulation);
                }

                );
            }

            public Task<IReadOnlyList<Mas.Rpc.Climate.IRealization>> Realizations(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Scenario.Params_realizations.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Scenario.Params_realizations()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(17124259736069978797UL, 1, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Scenario.Result_realizations>(d_);
                    return (r_.Realizations);
                }

                );
            }

            public async Task<Mas.Rpc.Common.IdInformation> Info(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Common.Identifiable.Params_info.WRITER>();
                var arg_ = new Mas.Rpc.Common.Identifiable.Params_info()
                {};
                arg_.serialize(in_);
                var d_ = await Call(15298557119806335142UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Common.Identifiable.Result_info>(d_);
                return (r_.Info);
            }
        }

        public class Scenario_Skeleton : Skeleton<IScenario>
        {
            public Scenario_Skeleton()
            {
                SetMethodTable(Simulation, Realizations);
            }

            public override ulong InterfaceId => 17124259736069978797UL;
            Task<AnswerOrCounterquestion> Simulation(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Simulation(cancellationToken_), simulation =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Scenario.Result_simulation.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Scenario.Result_simulation{Simulation = simulation};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> Realizations(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Realizations(cancellationToken_), realizations =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Scenario.Result_realizations.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Scenario.Result_realizations{Realizations = realizations};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }
        }

        public static class Scenario
        {
            [TypeId(0xbf6fc5c0410387cbUL)]
            public class Params_simulation : ICapnpSerializable
            {
                public const UInt64 typeId = 0xbf6fc5c0410387cbUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0x961302560b08da44UL)]
            public class Result_simulation : ICapnpSerializable
            {
                public const UInt64 typeId = 0x961302560b08da44UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Simulation = reader.Simulation;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Simulation = Simulation;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.ISimulation Simulation
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.ISimulation Simulation => ctx.ReadCap<Mas.Rpc.Climate.ISimulation>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Climate.ISimulation Simulation
                    {
                        get => ReadCap<Mas.Rpc.Climate.ISimulation>(0);
                        set => LinkObject(0, value);
                    }
                }
            }

            [TypeId(0xf785c988c3e2ed45UL)]
            public class Params_realizations : ICapnpSerializable
            {
                public const UInt64 typeId = 0xf785c988c3e2ed45UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xa0f6cc77317b3719UL)]
            public class Result_realizations : ICapnpSerializable
            {
                public const UInt64 typeId = 0xa0f6cc77317b3719UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Realizations = reader.Realizations;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Realizations.Init(Realizations);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public IReadOnlyList<Mas.Rpc.Climate.IRealization> Realizations
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public IReadOnlyList<Mas.Rpc.Climate.IRealization> Realizations => ctx.ReadCapList<Mas.Rpc.Climate.IRealization>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public ListOfCapsSerializer<Mas.Rpc.Climate.IRealization> Realizations
                    {
                        get => BuildPointer<ListOfCapsSerializer<Mas.Rpc.Climate.IRealization>>(0);
                        set => Link(0, value);
                    }
                }
            }
        }

        [TypeId(0xefe658a5bcadf576UL), Proxy(typeof(Realization_Proxy)), Skeleton(typeof(Realization_Skeleton))]
        public interface IRealization : Mas.Rpc.Common.IIdentifiable
        {
            Task<Mas.Rpc.Climate.IScenario> Scenario(CancellationToken cancellationToken_ = default);
            Task<Mas.Rpc.Climate.ITimeSeries> ClosestTimeSeriesAt(Mas.Rpc.Geo.Coord geoCoord, CancellationToken cancellationToken_ = default);
        }

        public class Realization_Proxy : Proxy, IRealization
        {
            public Task<Mas.Rpc.Climate.IScenario> Scenario(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Realization.Params_scenario.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Realization.Params_scenario()
                {};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(17286601688566592886UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Realization.Result_scenario>(d_);
                    return (r_.Scenario);
                }

                );
            }

            public Task<Mas.Rpc.Climate.ITimeSeries> ClosestTimeSeriesAt(Mas.Rpc.Geo.Coord geoCoord, CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Realization.Params_closestTimeSeriesAt.WRITER>();
                var arg_ = new Mas.Rpc.Climate.Realization.Params_closestTimeSeriesAt()
                {GeoCoord = geoCoord};
                arg_.serialize(in_);
                return Impatient.MakePipelineAware(Call(17286601688566592886UL, 1, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_), d_ =>
                {
                    var r_ = CapnpSerializable.Create<Mas.Rpc.Climate.Realization.Result_closestTimeSeriesAt>(d_);
                    return (r_.TimeSeries);
                }

                );
            }

            public async Task<Mas.Rpc.Common.IdInformation> Info(CancellationToken cancellationToken_ = default)
            {
                var in_ = SerializerState.CreateForRpc<Mas.Rpc.Common.Identifiable.Params_info.WRITER>();
                var arg_ = new Mas.Rpc.Common.Identifiable.Params_info()
                {};
                arg_.serialize(in_);
                var d_ = await Call(15298557119806335142UL, 0, in_.Rewrap<DynamicSerializerState>(), false, cancellationToken_).WhenReturned;
                var r_ = CapnpSerializable.Create<Mas.Rpc.Common.Identifiable.Result_info>(d_);
                return (r_.Info);
            }
        }

        public class Realization_Skeleton : Skeleton<IRealization>
        {
            public Realization_Skeleton()
            {
                SetMethodTable(Scenario, ClosestTimeSeriesAt);
            }

            public override ulong InterfaceId => 17286601688566592886UL;
            Task<AnswerOrCounterquestion> Scenario(DeserializerState d_, CancellationToken cancellationToken_)
            {
                return Impatient.MaybeTailCall(Impl.Scenario(cancellationToken_), scenario =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Realization.Result_scenario.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Realization.Result_scenario{Scenario = scenario};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }

            Task<AnswerOrCounterquestion> ClosestTimeSeriesAt(DeserializerState d_, CancellationToken cancellationToken_)
            {
                var in_ = CapnpSerializable.Create<Mas.Rpc.Climate.Realization.Params_closestTimeSeriesAt>(d_);
                return Impatient.MaybeTailCall(Impl.ClosestTimeSeriesAt(in_.GeoCoord, cancellationToken_), timeSeries =>
                {
                    var s_ = SerializerState.CreateForRpc<Mas.Rpc.Climate.Realization.Result_closestTimeSeriesAt.WRITER>();
                    var r_ = new Mas.Rpc.Climate.Realization.Result_closestTimeSeriesAt{TimeSeries = timeSeries};
                    r_.serialize(s_);
                    return s_;
                }

                );
            }
        }

        public static class Realization
        {
            [TypeId(0xf6f922f97a2686c7UL)]
            public class Params_scenario : ICapnpSerializable
            {
                public const UInt64 typeId = 0xf6f922f97a2686c7UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 0);
                    }
                }
            }

            [TypeId(0xc63858feeeae3328UL)]
            public class Result_scenario : ICapnpSerializable
            {
                public const UInt64 typeId = 0xc63858feeeae3328UL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    Scenario = reader.Scenario;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.Scenario = Scenario;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.IScenario Scenario
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.IScenario Scenario => ctx.ReadCap<Mas.Rpc.Climate.IScenario>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Climate.IScenario Scenario
                    {
                        get => ReadCap<Mas.Rpc.Climate.IScenario>(0);
                        set => LinkObject(0, value);
                    }
                }
            }

            [TypeId(0xb4f2f71a15b6f5ebUL)]
            public class Params_closestTimeSeriesAt : ICapnpSerializable
            {
                public const UInt64 typeId = 0xb4f2f71a15b6f5ebUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    GeoCoord = CapnpSerializable.Create<Mas.Rpc.Geo.Coord>(reader.GeoCoord);
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    GeoCoord?.serialize(writer.GeoCoord);
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Geo.Coord GeoCoord
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Geo.Coord.READER GeoCoord => ctx.ReadStruct(0, Mas.Rpc.Geo.Coord.READER.create);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Geo.Coord.WRITER GeoCoord
                    {
                        get => BuildPointer<Mas.Rpc.Geo.Coord.WRITER>(0);
                        set => Link(0, value);
                    }
                }
            }

            [TypeId(0xdac5aeaf78857f7dUL)]
            public class Result_closestTimeSeriesAt : ICapnpSerializable
            {
                public const UInt64 typeId = 0xdac5aeaf78857f7dUL;
                void ICapnpSerializable.Deserialize(DeserializerState arg_)
                {
                    var reader = READER.create(arg_);
                    TimeSeries = reader.TimeSeries;
                    applyDefaults();
                }

                public void serialize(WRITER writer)
                {
                    writer.TimeSeries = TimeSeries;
                }

                void ICapnpSerializable.Serialize(SerializerState arg_)
                {
                    serialize(arg_.Rewrap<WRITER>());
                }

                public void applyDefaults()
                {
                }

                public Mas.Rpc.Climate.ITimeSeries TimeSeries
                {
                    get;
                    set;
                }

                public struct READER
                {
                    readonly DeserializerState ctx;
                    public READER(DeserializerState ctx)
                    {
                        this.ctx = ctx;
                    }

                    public static READER create(DeserializerState ctx) => new READER(ctx);
                    public static implicit operator DeserializerState(READER reader) => reader.ctx;
                    public static implicit operator READER(DeserializerState ctx) => new READER(ctx);
                    public Mas.Rpc.Climate.ITimeSeries TimeSeries => ctx.ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                }

                public class WRITER : SerializerState
                {
                    public WRITER()
                    {
                        this.SetStruct(0, 1);
                    }

                    public Mas.Rpc.Climate.ITimeSeries TimeSeries
                    {
                        get => ReadCap<Mas.Rpc.Climate.ITimeSeries>(0);
                        set => LinkObject(0, value);
                    }
                }
            }
        }
    }
}