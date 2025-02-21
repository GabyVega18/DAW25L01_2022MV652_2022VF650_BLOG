using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2022VF650_2022MV652.Models;
using Microsoft.EntityFrameworkCore;


namespace L01_2022VF650_2022MV652.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blogDBController : ControllerBase
    {
        private readonly blogDBContext _blogDBContexto;
        public blogDBController(blogDBContext blogDBContexto)
        {
            _blogDBContexto = blogDBContexto;
        }
    }
}
