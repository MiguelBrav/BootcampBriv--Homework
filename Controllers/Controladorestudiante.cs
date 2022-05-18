using BootcampBrivé_Homework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBrivé_Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controladorestudiante : ControllerBase
    {
        //Creación de la lista y los estudiantes
        List<Estudiante> _lEstudiantes = new List<Estudiante>()
        {
            new Estudiante() { Id = 1, Name = "Miguel", LastName = "Segura", Career = "Sistemas Comp.", Email = "miguel@gmail.com", Egresado = false },
            new Estudiante() { Id = 2, Name = "Adolfo", LastName = "Viniegra", Career = "Administración", Email = "adolfo@gmail.com", Egresado = false },
            new Estudiante() { Id = 3, Name = "Jonathan", LastName = "Pacheco", Career = "Sistemas Comp.", Email = "jonathan@gmail.com", Egresado = false },
            new Estudiante() { Id = 4, Name = "Berenice", LastName = "Lugo", Career = "Civil", Email = "bere@gmail.com", Egresado = true },
            new Estudiante() { Id = 5, Name = "Vania", LastName = "Juárez", Career = "Industrial", Email = "vania@gmail.com", Egresado = true },


        };

        //Método Get
        [HttpGet]
        public IActionResult GetAllEstudiantes()
        {
            if (_lEstudiantes.Count == 0)
            {
                return NotFound("No hay lista de estudiantes");


            }
            return Ok(_lEstudiantes);
        }

        //Método Get a un estudiante mediante búsqueda del Id
        [HttpGet("GetEstudiante")]
        public IActionResult Get(int id)
        {
            var lEstudiante = _lEstudiantes.SingleOrDefault(x => x.Id == id);
            if (lEstudiante == null)
            {
                return NotFound("El estudiante no existe");
            }
            return Ok(lEstudiante);
        }


        //Método Get para verificar que estudiantes estan estudiando y cuales ya egresaron
        [HttpGet("GetEgresado")]
        public IActionResult Get(bool valor)
        {
            var lEstudianteEgresadoStatus = _lEstudiantes.FindAll(x => x.Egresado == valor);


            if (valor == true)
            {
                return Ok(lEstudianteEgresadoStatus);
            }

            if (_lEstudiantes.Count == 0)
            {
                return NotFound("No se encontró la lista");
            }
            return Ok(lEstudianteEgresadoStatus);


        }

        //Método Post para añadir un estudiante
        [HttpPost]
        public IActionResult SaveEstudiante(Estudiante lEstudiante)
        {
            _lEstudiantes.Add(lEstudiante);
            if (_lEstudiantes.Count == 0)
            {
                return NotFound("No se encontró la lista");
            }
            return Ok(_lEstudiantes);
        }

        //Método Delete para eliminar un estudiante
        [HttpDelete]
        public IActionResult DeleteEstudiante(int id)
        {
            var lEstudiante = _lEstudiantes.SingleOrDefault(x => x.Id == id);
            if (lEstudiante == null)
            {
                return NotFound("El estudiante no se encontró");

            }
            _lEstudiantes.Remove(lEstudiante);

            if(_lEstudiantes.Count == 0)
            {
                return NotFound("No se encontró la lista");
            }
            return Ok(_lEstudiantes);

        }
        
        //Método Delete para eliminar estudiantes egresados
        [HttpDelete("DeleteEgresados")]
        public IActionResult DeleteEstudgresad(bool valoregresado)
        {
            var lEstudiante = _lEstudiantes.RemoveAll(x => x.Egresado == valoregresado);
        
          
           if(valoregresado == true)
            {
                return Ok(_lEstudiantes);
            }
     

            if (_lEstudiantes.Count == 0)
            {
                return NotFound("No se encontró la lista");
            }
            return Ok(_lEstudiantes);
        }

 

    }

}