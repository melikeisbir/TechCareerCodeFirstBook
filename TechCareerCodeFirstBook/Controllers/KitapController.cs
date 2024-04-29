using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerCodeFirstBook.Data;
using TechCareerCodeFirstBook.Models;

namespace TechCareerCodeFirstBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        ApplicationDbContext _context;

        //KitapController class ı ile ilgili bir işlep yaptığımda
        //ApplicationDbContext class ı tipinde bir nesneyi de oluştur
        //Constrctor Injection 
        public KitapController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitap>>> KitaplariGetir()
        {
            //
            List<Kitap> kitapListesi;
            // select * from Kitap 
            kitapListesi = await _context.Kitap.ToListAsync();

            return kitapListesi;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Kitap>>> KitapEkle(Kitap kitap)
        {
            try
            {
                _context.Kitap.Add(kitap); //insert into 
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Ok();//200
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kitap>> KitapDetayGetir(int id)
        {
            // select * from Kitap where Id=id
            var kitap = await _context.Kitap.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return kitap;
        }
        [HttpPut]

        public async Task<ActionResult<IEnumerable<Kitap>>> KitapGuncelle(Kitap kitap)
        {
            _context.Entry(kitap).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync(); //update 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()
                    );
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Kitap>> KitapSil(int id)
        {
            Kitap silinecekKitap = await _context.Kitap.FindAsync(id);
            _context.Kitap.Remove(silinecekKitap);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}