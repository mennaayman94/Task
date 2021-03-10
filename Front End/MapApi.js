require([
  "esri/config",
  "esri/Map",
  "esri/views/MapView",
  "esri/layers/FeatureLayer",
  "esri/tasks/QueryTask",
  "esri/tasks/support/Query",
  "dojo/on",
  "esri/geometry/geometryEngineAsync",
  "esri/Graphic",
  "esri/symbols/SimpleFillSymbol",
  "esri/layers/GraphicsLayer",
], function (
  esriConfig,
  Map,
  MapView,
  FeatureLayer,
  QueryTask,
  Query,
  on,
  geometryEngineAsync,
  Graphic,
  SimpleFillSymbol,
  GraphicsLayer
) {
  const apiKey =
    "AAPK066b3f8062df426d83e1b437a5fae43e1cyvJ98T5uJmwwZsob78QgJjJ30GwvaeNC3WVigI11TnTIhGWGTDEnii8nycsbBk";
  esriConfig.apiKey = apiKey;

  const layerUrl =
    "https://sampleserver6.arcgisonline.com/arcgis/rest/services/DamageAssessmentStatePlane/MapServer/0";
  const DamageLayer = new FeatureLayer({
    url: layerUrl,
  });
  var mappedFeature;
  var res;
  var ConvertedDatetime;
  var c;

  var queryTask = new QueryTask({
    url: layerUrl,
  });
  var btn = document.getElementById("querybtn");
  btn.addEventListener("click", getData);
  //get data and populate it in the grid
  async function getData() {
    var userInput = document.getElementById("code").value;
    if (!(userInput >= 187530 && userInput <= 187536)) {
      alert("You must enter a number between 187530 and 187536");
    } else {
      //query to extract data
      var query = await new Query();
      query.returnGeometry = true;
      query.outFields = ["incidentnm", "firstname", "inspdate"];
      query.where = `objectid<${userInput}`;

      await queryTask.execute(query).then(
        await function (results) {
          console.log(results);
          res = results.features;
          mappedFeature = res.map((f) => f.attributes);
          ConvertedDatetime = mappedFeature.map((t) => t.inspdate);
//modify the object of data and replace esri date ime with humn data time 
          for (var i = 0; i < ConvertedDatetime.length; i++) {
            c = new Date(ConvertedDatetime[i]).toUTCString();
            console.log(c);

            mappedFeature[i].inspdate = c;
          }

          $(document).ready(function () {
            $("#grid").kendoGrid({
              dataSource: mappedFeature,

              selectable: "multiple row",
              navigatable: true,
              filterable: true,
              sortable: true,
              pageable: true,
              reorderable: true,
              groupable: true,
              columns: [
                {
                  field: "incidentnm",
                  width: 120,
                  title: "Incedent Name",
                },
                {
                  field: "firstname",
                  width: 120,
                  title: "First Name",
                },
                {
                  field: "inspdate",
                  title: "Date",
                  //template: '#= kendo.toString(1339113600000,"dd MMMM yyyy") #'
                },
                {
                  command: { text: "View Details" },
                  title: "",
                  width: "180px",
                },
              ],
            });

            $(document.body).keydown(function (e) {
              if (e.altKey && e.keyCode == 87) {
                $("#grid").data("kendoGrid").table.focus();
              }
            });
          });
        }
      );
    }
  }

  const map = new Map({
    basemap: "arcgis-topographic",
    layers: [DamageLayer],
    // Basemap layer service
  });

  const view = new MapView({
    map: map,
    center: [-88.151894, 41.789234], // Longitude, latitude
    zoom: 14, // Zoom level
    container: "viewDiv", // Div element
  });
  var buffBtn = document.getElementById("buf");
  buffBtn.addEventListener("click", dobuffer);
//function to get the map point of selected feature
  var clickedPoint;
  view.on("click", async function (evt) {
    clickedPoint = evt.mapPoint;
  });

  var graphicsLayer = new GraphicsLayer();
  var simpleFillSymbol = new SimpleFillSymbol();
  //function to excute buffer
  function dobuffer() {
    geometryEngineAsync
      .buffer(clickedPoint, 2, "kilometers", true)
      .then(function (response) {
        console.log(response.rings[0]);
        var bufferLayer = response.rings[0];
        const polygon = {
          type: "polygon",
          rings: bufferLayer,
        };

        simpleFillSymbol = {
          type: "simple-fill",
          color: [227, 139, 79, 0.8],
          outline: {
            color: "white",
            width: 1,
          },
        };
        console.log(simpleFillSymbol.color);
        const polygonGraphic = new Graphic({
          geometry: polygon,
          symbol: simpleFillSymbol,
        });

        graphicsLayer.add(polygonGraphic);
        map.add(graphicsLayer);
      });
  }
//add text boc div to the view
  view.ui.add("infoDiv", "top-right");
});
