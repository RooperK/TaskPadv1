using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper Mapper;
        public BaseController(IMapper mapper)
        {
            Mapper = mapper;
        }

        private async Task<IActionResult> ProcessAction(Func<Task<IActionResult>> task)
        {
            try
            {
                return await task.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        protected async Task<IActionResult> DoAction(Func<Task> task)
        {
            return await ProcessAction(async () =>
            {
                await task.Invoke();
                return Ok();
            });
        }
        
        protected async Task<IActionResult> DoAction<T>(Func<Task<T>> task)
        {
            return await ProcessAction(async () => Ok(await task.Invoke()));
        }
    }
}