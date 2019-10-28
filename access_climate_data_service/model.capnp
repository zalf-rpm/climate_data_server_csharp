@0x9273388a9624d430;

using Cxx = import "c++.capnp";
$Cxx.namespace("mas::rpc");

using Common = import "common.capnp".Common;
using Geo = import "geo_coord.capnp".Geo;
using Climate = import "climate_data.capnp".Climate;

struct Model {

  struct XYResult {
    xs @0 :List(Float64); # x axis values
    ys @1 :List(Float64); # y axis values
  }

  struct Stat {
    # statistics

    enum Type {
      min @0; # maximum
      max @1; # minimum
      sd @2; # standard deviation
      avg @3; # average
      median @4; # median
    }

    type @0 :Type = avg; #type
    vs @1 :List(Float64); # values
  }

  struct XYPlusResult {
    # a result including potentially some statistical information like min, max and standard deviation

    xy @0 :XYResult; # xy result
    stats @1 :List(Stat); # additional results
  }
 

  interface ClimateInstance extends(Common.Identifiable) {
    # an interface to run a "climate" model, which is basically using just climate data

    run @0 (timeSeries :Climate.TimeSeries) -> (result :XYResult);
    # run model just on a single time series

    runSet @1 (dataset :List(Climate.TimeSeries)) -> (result :XYPlusResult);
    # run model on a set of time series
  }
  

  struct Env {

    rest @0 :Common.StructuredText;
    # rest of environment, encoded as some structured text format

    timeSeries @1 :Climate.TimeSeries;
    # climate data  

    #soilProfile @2 :Soil.Profile;
    # soil profile to use for a model run
  }
   
   
  interface EnvInstance extends(Common.Identifiable, Common.Stopable) {
    # an interface to run a model against an environment of input data

    run @0 (env :Env) -> (result :Common.StructuredText);
    # run a model via an input environment and return result as some structured text
  }


  interface EnvInstanceProxy extends(EnvInstance) {
    # the EnvInstance interface with the ability to forward run messages to registered EnvInstances

    registerEnvInstance @0 (instance :EnvInstance) -> (unregister :Common.Callback);
    # register an instance of an EnvInstance model to get jobs transparently forwarded to by the proxy
  }

}
