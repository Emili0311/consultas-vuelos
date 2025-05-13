using Microsoft.AspNetCore.Mvc;

[Route("api/vuelos")]
public class VuelosCotroller : ControllerBase {

    [HttpGet("ciudades-origen")]
    public IActionResult CiudadesOrigen(){
        var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("CiudadOrigen", FilterDefinition<Vuelo>.Empty).ToList();
        return Ok(lista);
    
    }

    [HttpGet("ciudades-destino")]
    public IActionResult CiudadesDestino(){
        var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("CiudadDestino", FilterDefinition<Vuelo>.Empty).ToList();
        return Ok(lista);
    
    }

    [HttpGet("estatus")]
    public IActionResult ListarEstatus(){
        var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("EstatusVuelo", FilterDefinition<Vuelo>.Empty).ToList();
        return Ok(lista);
    
    }

    [HttpGet("listar-vuelos")]
    public IActionResult ListarVuelos(){
         var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("ListarVuelo", FilterDefinition<Vuelo>.Empty).ToList();
        return Ok(lista);
    
    }
}
