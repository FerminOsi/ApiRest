using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 800 },
            new Producto { Id = 2, Nombre = "Teléfono", Precio = 500 }
        };

        // GET: api/productos
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetProductos()
        {
            return productos;
        }

        // GET: api/productos/1
        [HttpGet("{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            return producto;
        }

        // GET: api/productos/buscar?nombre=Laptop
        [HttpGet("buscar")]
        public ActionResult<IEnumerable<Producto>> BuscarProducto(string nombre)
        {
            var resultados = productos.Where(p => p.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
            if (!resultados.Any())
                return NotFound("No se encontraron productos con ese nombre.");

            return resultados;
        }

        // GET: api/productos/precio?min=300&max=900
        [HttpGet("precio")]
        public ActionResult<IEnumerable<Producto>> FiltrarPorPrecio(double min, double max)
        {
            var resultados = productos.Where(p => p.Precio >= min && p.Precio <= max).ToList();
            if (!resultados.Any())
                return NotFound("No hay productos en ese rango de precios.");

            return resultados;
        }

        // POST: api/productos
        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto producto)
        {
            if (string.IsNullOrEmpty(producto.Nombre) || producto.Precio <= 0)
                return BadRequest("El nombre no puede estar vacío y el precio debe ser mayor a 0.");

            producto.Id = productos.Count + 1;
            productos.Add(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/1
        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] Producto productoActualizado)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            if (string.IsNullOrEmpty(productoActualizado.Nombre) || productoActualizado.Precio <= 0)
                return BadRequest("El nombre no puede estar vacío y el precio debe ser mayor a 0.");

            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            return NoContent();
        }

        // DELETE: api/productos/1
        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            productos.Remove(producto);
            return NoContent();
        }

        // DELETE: api/productos/eliminar-multiples
        [HttpDelete("eliminar-multiples")]
        public IActionResult EliminarMultiplesProductos([FromBody] List<int> ids)
        {
            productos.RemoveAll(p => ids.Contains(p.Id));
            return NoContent();
        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
    }
}
