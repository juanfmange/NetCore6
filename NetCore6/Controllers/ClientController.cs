using Microsoft.AspNetCore.Mvc;
using NetCore6.Models;

namespace NetCore6.Controllers;

[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    [HttpGet]
    [Route("list")]
    public dynamic listarCliente()
    {
        List<Client> clients = new List<Client>
        {
            new Client
            {
                Id = 1,
                Name = "João",
                Email = "joao@gmail.com",
                Age = 20
            },

            new Client
            {
                Id = 2,
                Name = "Maria",
                Email = "maria@gmail.com",
                Age = 30
            }
            };

            return clients;
        }
    
    [HttpGet]
    [Route("list{id}")]
    public dynamic listarClienteId(int id)
    {
        return new Client
        {
            Id = id,
            Name = "João",
            Email = "joao@gmail.com",
            Age = 20
        };


    }

    [HttpPost]
    [Route("create")]
    public dynamic createClient(Client client)
    {
        client.Id = 3;
        return new
        {
            success = true,
            msg = "Cliente creado exitosamente",
            data = client
        };

    }
    
    [HttpPost]
    [Route("delete")]
    public dynamic deleteClient(Client client)
    {
        string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
        if (token != "123456")
        {
            return new
            {
                success = false,
                msg = "No tiene permisos para eliminar el cliente",
                data = ""
            };
        }
        return new
        {
            success = true,
            msg = "Cliente eliminado exitosamente",
            data = client
        };

    }
}