using CashFlow.Application.UserCases.Expenses.Register;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequesRegistertExpenseJson request)
    {
        try
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson(ex.Message);
            return BadRequest(errorResponse);
            
        }
        catch
        {
            var errorResponse = new ResponseErrorJson("Unknown");
            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        
        }
    }
}
