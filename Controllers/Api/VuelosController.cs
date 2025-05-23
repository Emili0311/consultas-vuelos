using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

[Route("api/vuelos")]
public class VuelosController : ControllerBase
{
    [HttpGet("ciudades-origen")]
    public IActionResult CiudadesOrigen()
    {
        var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("CiudadOrigen", FilterDefinition<Vuelo>.Empty).ToList();

        return Ok(lista);
    }

    [HttpGet("ciudades-destino")]
    public IActionResult CiudadesDestino()
    {
         var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("CiudadDestino", FilterDefinition<Vuelo>.Empty).ToList();

        return Ok(lista);
    }

    [HttpGet("estatus")]
    public IActionResult ListarEstatus()
    {
        var client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Vuelo>("Vuelos");

        var lista = collection.Distinct<string>("EstatusVuelo", FilterDefinition<Vuelo>.Empty).ToList();

        return Ok(lista);
    }

    [HttpGet("listar-vuelos")]
    public IActionResult ListarVuelos()
    {
        var lista = _vuelos.Find(FilterDefinition<Vuelo>.Empty).ToList();
        return Ok(lista);
    }
}