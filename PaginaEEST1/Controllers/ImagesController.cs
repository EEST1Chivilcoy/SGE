using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Models.Images;

namespace PaginaEEST1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly PaginaDbContext _context;

        public ImagesController(PaginaDbContext context)
        {
            _context = context;
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAbstractImage(int id)
        {
            var abstractImage = await _context.Images.FindAsync(id);

            if (abstractImage == null)
            {
                return NotFound();
            }

            return File(abstractImage.ImageContent, abstractImage.TypeFile);
        }
    }
}
