using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Subir_Archivo_API.Models;

namespace Subir_Archivo_API.Controllers
{
        [EnableCors("ReglasCors")]
        [Route("api/[controller]")]
        [ApiController]
        public class ArchivosController : ControllerBase
        {
            public readonly string conexion;

            public readonly SubirArchivoApiContext context;
            public ArchivosController(SubirArchivoApiContext context)
            {
                this.context = context;
            }


            [HttpGet]
            public ActionResult Get()
            {
                try
                {
                    return Ok(context.Archivos.ToList());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost]
            public ActionResult PostArchivos([FromForm] List<IFormFile> files)
            {
                List<Archivo> archivos = new List<Archivo>();

                try
                {
                    if (files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            var filePath = "C:\\Users\\PC\\Downloads\\Prog\\C#\\Subir_Archivo_API\\WebApplication1\\ArchivosGuardados\\" + file.FileName;
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                file.CopyToAsync(stream);
                            }
                            double Tamaño = file.Length;
                            Tamaño = Tamaño / 1000000;
                            Tamaño = Math.Round(Tamaño, 2);
                            Archivo archivo = new Archivo();
                            archivo.Extension = Path.GetExtension(file.FileName).Substring(1);
                            archivo.Nombre = Path.GetFileNameWithoutExtension(file.FileName);
                            archivo.Tamaño = Tamaño;
                            archivo.Ubicacion = filePath;
                            archivos.Add(archivo);
                        }
                        context.Archivos.AddRange(archivos);
                        context.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(archivos);
            }

        }
    
}
